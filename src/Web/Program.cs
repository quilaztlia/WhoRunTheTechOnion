using Services;
using Services.Abstractions;
using Persistance;
using Web.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Diagnostics;
using Domain.Repository.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReferenceController).Assembly);

builder.Services.AddSwaggerGen(options => 
    options.SwaggerDoc("v1", new OpenApiInfo{Title="WebApi"}));

builder.Services.AddScoped<IServiceManager, ManagerService>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

IConfiguration configuration = builder.Configuration;
Console.WriteLine(configuration);
Debug.WriteLine(configuration);

builder.Services.AddDbContextPool<DBContext>(builder => {
    var connectionString = configuration.GetConnectionString("Database");
    builder.UseSqlServer(connectionString);
});

builder.Services.AddTransient<ErrorHandling>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//http://localhost:5189/swagger/v1/swagger.json
//http://localhost:5189/index.html
if (app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();

    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "");
        options.RoutePrefix = string.Empty;
        });
}

//app.UseMiddleware<ErrorHandling>();

app.UseHttpsRedirection();
//app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());
//app.MapRazorPages();

app.Run();
