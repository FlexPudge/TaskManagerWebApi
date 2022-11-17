global using TaskManagerWebApi.Data;
global using TaskManagerWebApi.Model;
global using Microsoft.EntityFrameworkCore;
using TaskManagerWebApi.Interface;
using TaskManagerWebApi.Repository;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository<User>, UserObjectRepository>();
builder.Services.AddTransient<IRepository<User>, UserObjectRepository>();
builder.Services.AddScoped<IRepository<User>, UserObjectRepository>();
builder.Services.AddTransient<UserObjectRepository>(); 
builder.Services.AddMvcCore();
builder.Services.AddMvc();

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
