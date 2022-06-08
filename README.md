**Step 1: get MongoDB**

Now that you have Docker up and running, it is pretty easy to start up MongoDB. Create an empty directory somewhere (or go to your project directory if You already have one) and create a docker-compose.yml file inside it. We can take a look at the official Mongo Docker image to see what we should put there.

	version: '3.1'services:mongo:
		image: mongo
		restart: always
		environment:
		  MONGO_INITDB_ROOT_USERNAME: root
		  MONGO_INITDB_ROOT_PASSWORD: example
		ports:
		  - 27017:27017mongo-express:
		image: mongo-express
		restart: always
		ports:
		  - 8081:8081
		environment:
		  ME_CONFIG_MONGODB_ADMINUSERNAME: root
		  ME_CONFIG_MONGODB_ADMINPASSWORD: example
		depends_on:
		  - mongo

This will bring up the latest MongoDB database as well as a nice admin panel that You’ll be able to use to see what is actually happening. To get started, run:

	$ docker-compose up -d

With that command, You should now have a MongoDB database running! You can check what’s in there using the Express web server on http://localhost:8081. Note, that if You had to use the Docker Toolbox approach, the IP address will be different (as localhost is only available on the host). To determine Your Docker “localhost” address, use

	$ docker-machine ip default

To see all running containers, use docker ps command. For a GUI, you can use the Kitematic software. This comes bundled with Docker Toolbox, but can be set up for native Docker as well.

Setting up WebAPI

Now that we have MongoDB up and running, it’s time to set up a .NET Core project. In these examples I’ll be using a CLI approach together with VS Code, to make sure that this tutorial is relevant for all platforms.

**Step 2: set up a new project**

This is pretty straightforward. First, make sure that you have Dotnet Core SDK set up.

	$ dotnet --version

	$ dotnet new webapi -o TodoApp

**Step 3: connect to MongoDB**

Now that we have an actual project, it’s time to set up MongoDB on .NET Core! The first thing that You’ll need to do is add a nuget reference for MongoDB Driver. At the time of writing this, the newest version is 2.7:

	dotnet add package MongoDB.Driver

The next step is to set up the configuration necessary to establish MongoDB connection. First, amend *appsettings.json* to something like this:

	{
	  "MongoDB": {
		"Database": "TodoDB",
		"Host": "localhost",
		"Port": 27017,
		"User": "root",
		"Password": "example"
	  },
	  "Logging": {
		"LogLevel": {
		  "Default": "Warning"
		}
	  },
	  "AllowedHosts": "*"
	}

We’ll create the connection string at runtime. Doing that will allow us to make use of the specified usernames, passwords, hosts and ports for docker later. The User and Password in this example are what’s being used by MongoDB docker image.

There are multiple ways to bind this config to some settings on runtime. I Like to keep my settings in code organized to somewhat resemble the settings in JSON file. To this end, I created two new files:

*ServerConfig.cs*:

	namespace TodoApp
	{
		public class ServerConfig
		{
			public MongoDBConfig MongoDB { get; set; } = new MongoDBConfig();
		}
	}

*MongoDbConfig.cs*:

	namespace TodoApp
	{
		public class MongoDBConfig
		{
			public string Database { get; set; }
			public string Host { get; set; }
			public int Port { get; set; }
			public string User { get; set; }
			public string Password { get; set; }        public string ConnectionString 
			{
				get 
				{
					if (string.IsNullOrEmpty(User) || string.IsNullOrEmpty(Password))
						return $@"mongodb://{Host}:{Port}";                return $@"mongodb://{User}:{Password}@{Host}:{Port}";
				}
			}
		}
	}

I put both of those in a new Config folder. Now we can go to *Startup.cs* and get that config in a variable like this

	public void ConfigureServices(IServiceCollection services)
	{
		var config = new ServerConfig();
		Configuration.Bind(config);
		
		services.AddMvc();
	}

With that config set up, we can create a MongoDB context that will use it. In a new Models folder, create the following files:

*ITodoContext.cs*

	namespace TodoApp.Models
	{
		using MongoDB.Driver;    public interface ITodoContext
		{
			IMongoCollection<Todo> Todos { get; }
		}
	}

*TodoContext.cs*

	namespace TodoApp.Models
	{
		using TodoApp;
		using MongoDB.Driver;
		using System;    public class TodoContext: ITodoContext
		{
			private readonly IMongoDatabase _db;        public TodoContext(MongoDBConfig config)
			{
				var client = new MongoClient(config.ConnectionString);
				_db = client.GetDatabase(config.Database);
			}        public IMongoCollection<Todo> Todos => _db.GetCollection<Todo>("Todos");
		}
	}

Now we can make use of the context in Startup.cs and connect to the DB at startup:

	public void ConfigureServices(IServiceCollection services)
	{
		var config = new ServerConfig();
		Configuration.Bind(config);    var todoContext = new TodoContext(config.MongoDB);services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
	}

**Step 4: query the database**

Since we have a working connection, we can now set up a repository that will hold the methods for querying the database. We’ll then be able to use this repository in our controller to fetch and return data. First, We’ll need an actual model of the data that we’ll store and fetch from DB.

*Todo.cs*

	namespace TodoApp.Models
	{
		using MongoDB.Bson;
		using MongoDB.Bson.Serialization.Attributes;    public class Todo
		{
			[BsonId]
			public ObjectId InternalId { get; set; }
			public long Id { get; set; }
			public string Title { get; set; }
			public string Content { get; set; }
		}
	}

Since this will be a document in MongoDB, it requires an ObjectId id. This is a unique identifier that is used internally in the database. While we could use that as the Id in our API as well, that is a bit of a chore, when you want to fetch something simply by calling /api/{id} . That is why we set up a second Id that is just an integer. We will have to deal with incrementing this ourselves though.

Next, let’s create an interface that will sum up all the actions that we expect to do with our todos, as well as the actual implementation:

*ITodoRepository.cs*

	namespace TodoApp.Models
	{
		using System.Collections.Generic;
		using System.Threading.Tasks;    public interface ITodoRepository
		{
			// api/[GET]
			Task<IEnumerable<Todo>> GetAllTodos();        // api/1/[GET]
			Task<Todo> GetTodo(long id);        // api/[POST]
			Task Create(Todo todo);        // api/[PUT]
			Task<bool> Update(Todo todo);        // api/1/[DELETE]
			Task<bool> Delete(long id);        Task<long> GetNextId();
		}
	}

*TodoRepository.cs*

	namespace TodoApp.Models
	{
		using System.Collections.Generic;
		using System.Threading.Tasks;
		using MongoDB.Driver;
		using MongoDB.Bson;
		using System.Linq;    public class TodoRepository : ITodoRepository
		{
			private readonly ITodoContext _context;        public TodoRepository(ITodoContext context)
			{
				_context = context;
			}        public async Task<IEnumerable<Todo>> GetAllTodos()
			{
				return await _context
								.Todos
								.Find(_ => true)
								.ToListAsync();
			}
			public Task<Todo> GetTodo(long id)
			{
				FilterDefinition<Todo> filter = Builders<Todo>.Filter.Eq(m => m.Id, id);
				return _context
						.Todos
						.Find(filter)
						.FirstOrDefaultAsync();
			}        public async Task Create(Todo todo)
			{
				await _context.Todos.InsertOneAsync(todo);
			}
			public async Task<bool> Update(Todo todo)
			{
				ReplaceOneResult updateResult =
					await _context
							.Todos
							.ReplaceOneAsync(
								filter: g => g.Id == todo.Id,
								replacement: todo);
				return updateResult.IsAcknowledged
						&& updateResult.ModifiedCount > 0;
			}
			public async Task<bool> Delete(long id)
			{
				FilterDefinition<Todo> filter = Builders<Todo>.Filter.Eq(m => m.Id, id);
				DeleteResult deleteResult = await _context
													.Todos
												  .DeleteOneAsync(filter);
				return deleteResult.IsAcknowledged
					&& deleteResult.DeletedCount > 0;
			}        public async Task<long> GetNextId()
			{
				return await _context.Todos.CountDocumentsAsync(new BsonDocument()) + 1;
			}
		}
	}

Now we can hook up that repository in our Startup.cs and make a Singleton that we can inject in our controller (that we’ll create next):

	public void ConfigureServices(IServiceCollection services)
	{
		var config = new ServerConfig();
		Configuration.Bind(config);    var todoContext = new TodoContext(config.MongoDB);    var repo = new TodoRepository(todoContext);    services.AddSingleton<ITodoRepository>(repo);services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
	}

Step 5: the controller

Time to bring it all together. Create a new controller that will handle all of the actions set up in Todo Repository:

*TodoController.cs*

	namespace TodoApp.Controllers
	{
		using TodoApp.Models;
		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Threading.Tasks;
		using Microsoft.AspNetCore.Mvc;    [Produces("application/json")]
		[Route("api/[Controller]")]
		public class TodosController: Controller
		{
			private readonly ITodoRepository _repo;        public TodosController(ITodoRepository repo)
			{
				_repo = repo;
			}        // GET api/todos
			[HttpGet]
			public async Task<ActionResult<IEnumerable<Todo>>> Get()
			{
				return new ObjectResult(await _repo.GetAllTodos());
			}        // GET api/todos/1
			[HttpGet("{id}")]
			public async Task<ActionResult<Todo>> Get(long id)
			{
				var todo = await _repo.GetTodo(id);            if (todo == null)
					return new NotFoundResult();
				
				return new ObjectResult(todo);
			}        // POST api/todos
			[HttpPost]
			public async Task<ActionResult<Todo>> Post([FromBody] Todo todo)
			{
				todo.Id = await _repo.GetNextId();
				await _repo.Create(todo);
				return new OkObjectResult(todo);
			}        // PUT api/todos/1
			[HttpPut("{id}")]
			public async Task<ActionResult<Todo>> Put(long id, [FromBody] Todo todo)
			{
				var todoFromDb = await _repo.GetTodo(id);            if (todoFromDb == null)
					return new NotFoundResult();            todo.Id = todoFromDb.Id;
				todo.InternalId = todoFromDb.InternalId;            await _repo.Update(todo);            return new OkObjectResult(todo);
			}        // DELETE api/todos/1
			[HttpDelete("{id}")]
			public async Task<IActionResult> Delete(long id)
			{
				var post = await _repo.GetTodo(id);            if (post == null)
					return new NotFoundResult();            await _repo.Delete(id);            return new OkResult();
			}
		}
	}

Assuming that a MongoDB instance is still running in Docker, You can now start the API dotnet run , and visit localhost:5000/api/todos.
Looks like everything is working as intended.

Congratulations, the controller told the repository to query the MongoDB database! Of course, since there is nothing in the database, nothing was found. But the absence of any Mongo query errors means that We are in business.

Step 6: visualize the API

We’ve got our API running, neat! How do we make requests? We could use Postman. That is the best choice for making various web requests to test and stress your API. However, sometimes You just want a simple interface for your API that allows you to quickly see that everything is working.

Enter Swagger. Swagger UI allows you to easily set up API visualization in a couple of steps. First, we need to add a dependency that will pull in swagger:

	dotnet add package Swashbuckle.AspNetCore --version 3.0.0

The only additional configuration we need to do is in our Startup.cs file.

In ConfigureServices(…) method, add this service configuration:

	services.AddSwaggerGen(c =>
	{
		c.SwaggerDoc("v1", new Info
		{
			Title = "Todo API",
			Version = "v1",
			Description = "Todo API tutorial using MongoDB",
		});
	});

And in Configure(…) method, add these lines to the app configuration:

	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
	});

With that, swagger is ready to run. To see it in action, You can now visit localhost:5000/swagger/index.html 

**Dockerize!**

Now that We have a working API, it makes sense to add that to our docker-compose file so we can easily bring it up together with the MognoDB database. First, 

We’ll need a Dockerfile that will specify, how our API is built.
Next, we can add a service to our docker-compose.yml file:

This is your task.