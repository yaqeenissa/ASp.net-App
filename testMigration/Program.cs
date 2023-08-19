using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Runtime.InteropServices;
using testMigration;
using testMigration.Servises.courser;
using testMigration.Servises.Student;
using testMigration.Servises.StudentCourses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDBcontext>(c=>c.UseSqlServer(connStr));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStudent, impStudent>();
builder.Services.AddScoped<ICourse, impCourses>();
builder.Services.AddScoped<IstuCou, impStuCou>();
builder.Services.AddDbContext<AppDBcontext>(options =>
    options.UseSqlServer(connStr));
builder.Services.AddMemoryCache();

//builder.Services.AddAutoMapper();

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
