using FakeRESTAPI.Web;
using FakeRESTAPI.Web.Models;
using FakeRESTAPI.Web.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo()
{
    Description = "FakeRESTAPI with .NET 6 Minimal API",
    Title = "FakeRESTAPI",
    Version = "v1",
    Contact = new OpenApiContact()
    {
        Name = "Emanuele Bartolesi",
        Url = new Uri("https://github.com/kasuken")
    }
}));

builder.Services.AddCors(options => options.AddPolicy("AnyOrigin", o => o.AllowAnyOrigin()));

builder.Services.AddScoped<IRepository, SimpleFakeRepository>();

var app = builder.Build();
app.UseCors();

app.UseHttpsRedirection();
app.RegisterActivitiesRoutes();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();