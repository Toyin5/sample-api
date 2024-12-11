using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SampleAPI.Models;
using SampleAPI.Persistence;
using SampleAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MongoDbContext>(builder.Configuration);
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddScoped<UserRepository>();

// Add environment variables

// Test MongoDB Connection on Startup
try
{
    var mongoDbContext = new MongoDbContext(builder.Configuration);
    var testCollection = mongoDbContext.GetCollection<object>("test");
    testCollection.Find(_ => true).FirstOrDefault(); // Test query
    Console.WriteLine("MongoDB connection successful.");
}
catch (Exception ex)
{
    Console.WriteLine($"MongoDB connection failed: {ex.Message}");
    throw;
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapPost("/register", async ([FromBody]UserDto user, UserRepository userRepository) =>
{
    var result = await userRepository.CreateUser(user);
    return result;
})
.WithName("RegisterUser")
.WithOpenApi();

app.MapGet("/user", async ([FromQuery] string user, UserRepository userRepository) =>
{
    var result = await userRepository.GetUser(user);
    return result;
})
.WithName("Retrieve apikey")
.WithOpenApi();

app.MapPost("/upload", async ([FromHeader(Name ="x-api-key")] string apiKey, [FromBody]FileDto file, UserRepository userRepository) =>
{
    var result = await userRepository.UploadAsync(file);
    return result;
})
.WithName("Upload")
.WithOpenApi();


app.Run();