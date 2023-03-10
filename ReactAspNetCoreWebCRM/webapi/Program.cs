//using Microsoft.Extensions.Caching.Distributed;
//using Microsoft.Extensions.Caching.StackExchangeRedis;

using Microsoft.EntityFrameworkCore;
using WebCRM.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddStackExchangeRedisCache(options =>
//{
//    options.Configuration = "redis:6379"; // redis is the container name of the redis service. 6379 is the default port
//    options.InstanceName = "WebCRMRedisInstance";
//});
builder.Services.AddDbContext<CRMDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

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
