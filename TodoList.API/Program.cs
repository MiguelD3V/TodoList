using Microsoft.EntityFrameworkCore;
using TodoList.API.Data;
using TodoList.API.Data.Interfaces;
using TodoList.API.Data.Repositories;
using TodoList.API.Workers.Services;
using TodoList.API.Workers.Services.Interface;
using TodoList.API.Workers.Validators;
using TodoList.API.Workers.Validators.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("TodoListDb"
));

builder.Services.AddControllers();

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>(); 
builder.Services.AddScoped<ITaskValidator, TaskValidator>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserValidator, UserValidator>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryValidator, CategoryValidator>();

builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{

    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
