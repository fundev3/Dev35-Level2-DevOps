namespace TodoApp
{
    public void ConfigureServices(IServiceCollection services)
    {
        var config = new ServerConfig();
        Configuration.Bind(config);    
        var todoContext = new TodoContext(config.MongoDB);
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }
}