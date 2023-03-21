using Autofac;
using Autofac.Extensions.DependencyInjection;
using Mediator;
using MyCompany.Store.Application.Orders;
using MyCompany.Store.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultDatabase");

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediator();

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new DataAccessModule(connectionString));
    builder.RegisterModule(new OrderModule());
});
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
