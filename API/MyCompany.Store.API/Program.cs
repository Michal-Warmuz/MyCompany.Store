using Autofac;
using Autofac.Extensions.DependencyInjection;
using Mediator;
using MyCompany.Store.API.Middlewares;
using MyCompany.Store.Application.Orders;
using MyCompany.Store.Infrastructure.Database;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultDatabase");

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(new StringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGenNewtonsoftSupport();

builder.Services.AddMediator();

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new DataAccessModule(connectionString));
    builder.RegisterModule(new OrderModule());
});
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddCors(o => o.AddPolicy("Policy", builder =>
{
    builder.WithOrigins("http://localhost:5240")
           .AllowAnyMethod()
           .AllowAnyHeader();
           
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Policy");

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
