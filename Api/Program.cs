using Data;
using NLog;
using NLog.Web;
using Microsoft.EntityFrameworkCore;
using Webframework.Configuration;

var logger = NLog.LogManager.Setup().LoadConfigurationFromFile("/nlog.config").GetCurrentClassLogger();
logger.Debug("init main");

try
{

    var builder = WebApplication.CreateBuilder(args);

    // add mvc to project
    builder.Services.AddControllersWithViews();
    // add sql server 
    builder.Services.AddDbContext<Context>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDbConnection"));
    });

    builder.Services.AddDependencyInjections();
    var app = builder.Build();



    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}