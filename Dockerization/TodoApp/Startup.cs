namespace TodoApp
{
    public void ConfigureServices(IServiceCollection services)
    {
        var config = new ServerConfig();
        Configuration.Bind(config);    
        var todoContext = new TodoContext(config.MongoDB);    
        var repo = new TodoRepository(todoContext);    
        services.AddSingleton<ITodoRepository>(repo);
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Info
            {
                Title = "Todo API",
                Version = "v1",
                Description = "Todo API tutorial using MongoDB",
            });
        });

    }
}