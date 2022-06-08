namespace TodoApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var config = new ServerConfig();
            Configuration.Bind(config);

            services.AddMvc();
        }
    }
}
