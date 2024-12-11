using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;  // to set up Swagger UI
using StudentManagementAPI.Data; // to access data context

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// configuring Swagger
builder.Services.AddSwaggerGen(c =>
    {
        // set info to display in UI
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Student Management API",
            Version = "v1",
            Description = "API for managing Students, Teachers, and Courses",
        });
    });

// adding connection to database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 0))
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //setting up endpoint
    app.UseSwaggerUI(c => {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student Management API v1");
        });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
