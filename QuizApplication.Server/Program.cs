using Microsoft.EntityFrameworkCore;
using QuizApplication.BusinessLogic.Services;
using QuizApplication.BusinessLogic.Services.Contracts;
using QuizApplication.DataAccess.Context;
using QuizApplication.Server.Constants;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

#region Configuration setup
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile(builder.Environment.IsDevelopment() ? ConstantValues.DevelopmentConfig : ConstantValues.GeneralConfig)
    .AddEnvironmentVariables()
    .Build();
#endregion

#region Logger configuration
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .CreateLogger();
#endregion

#region Services/Repositories
builder.Services.AddControllers();

// EF Core
builder.Services.AddDbContext<QuizDbContext>(options => options.UseInMemoryDatabase(ConstantValues.InMemory));

// DI Containers
builder.Services.AddScoped<IQuestionsService, QuestionsService>();
builder.Services.AddScoped<IParticipantsService, ParticipantsService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS for React
builder.Services.AddCors(options =>
    options.AddPolicy(ConstantValues.DevelopmentCors, policy => policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
#endregion

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(ConstantValues.DevelopmentCors);
}
app.UseHttpsRedirection();

app.MapControllers();

app.MapFallbackToFile("/index.html");

await app.RunAsync();
await Log.CloseAndFlushAsync();