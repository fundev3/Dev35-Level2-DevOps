using System.Configuration;
using TodoApp.Models;

namespace TodoApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var config = new ServerConfig();
            Configuration.Bind(config); 
            var todoContext = new TodoContext(config.MongoDB); 
            var repo = new TodoRepository(todoContext); 
            services.AddSingleton<ITodoRepository>(repo); 
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
    }
}
