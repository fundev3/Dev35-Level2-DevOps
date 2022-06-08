using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using Microsoft.Extensions.Configuration;
namespace TodoApp{

	public class Startup {
		public Startup(IConfiguration configuration)//Constructor
		{
			Configuration = configuration;
		}
		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			var config = new ServerConfig();
			Configuration.Bind(config);

			services.AddMvc();
			var todoContext = new TodoContext(config.MongoDB);
			var repo = new TodoRepository(todoContext);
			services.AddSingleton<ITodoRepository>(repo); services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}
	}
   


}