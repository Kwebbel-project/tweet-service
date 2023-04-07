using Confluent.Kafka;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using tweet_service.Common.Kafka;
using tweet_service.Common.Kafka.Interfaces;
using tweet_service.Data;
using tweet_service.Repositories;
using tweet_service.Repositories.Interfaces;
using tweet_service.Services;
using tweet_service.Services.interfaces;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).AddEnvironmentVariables();

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<ITweetRepository, TweetRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null) ;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITweetService, TweetService>();
builder.Services.AddSingleton<IKafkaProducerHandler, KafkaProducerHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
