using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using multiCrud;
using multiCRUD.Interfaces;
using multiCRUD.Model;
using multiCRUD.Model.Crud;
using multiCRUD.Model.Elements;
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