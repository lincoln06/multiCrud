using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using multiCRUD.Interfaces;
using multiCRUD.Model;
using multiCRUD.View;

var host =Host.CreateDefaultBuilder().ConfigureServices(Configure).Build();
var app = ActivatorUtilities.CreateInstance<App>(host.Services);
app.Start();

void Configure(IServiceCollection service)
{
    service.AddTransient<IMenu, Menu>();
    service.AddTransient<IResponseProvider, ResponseProvider>();
    service.AddTransient<IViewer, Viewer>();
}