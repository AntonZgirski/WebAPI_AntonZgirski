using Lab16_WebAPI.Data;
using Lab16_WebAPI.Model;
using Lab16_WebAPI.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.Swagger;
using System.ComponentModel;
using Contact = Swashbuckle.Swagger.Contact;
using License = Swashbuckle.Swagger.License;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApiTestContext>(options => options.UseInMemoryDatabase("ContactsDB"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSingleton<IContactService, ContactService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.ConfigureSwaggerGen(options =>
//  {
//  options.SwaggerDoc("Doc1",new Microsoft.OpenApi.Models.OpenApiInfo
//  {
//    Version = "v1",
//    Title = "ToDo API",
//    Description = "A simple example ASP.NET Core Web API",
//    TermsOfService = new Uri("http://url.com"),
//    Contact = new OpenApiContact { Name = "Shayne Boyer", Email = "", Url = new Uri("http://twitter.com/spboyer")},
//    License = new OpenApiLicense { Name = "Use under LICX", Url = new Uri("http://url.com")}
//  });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
