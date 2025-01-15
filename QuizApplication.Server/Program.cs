using Microsoft.EntityFrameworkCore;
using QuizApplication.BusinessLogic.Services;
using QuizApplication.BusinessLogic.Services.Contracts;
using QuizApplication.DataAccess.Context;
using QuizApplication.Server.Constants;

var builder = WebApplication.CreateBuilder(args);

#region Services/Repositories
builder.Services.AddControllers();

// EF Core
builder.Services.AddDbContext<QuizDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString(ConstantValues.DefaultConnection)));

// DI Containers
builder.Services.AddScoped<IQuestionsService, QuestionsService>();
builder.Services.AddScoped<IParticipantsService, ParticipantsService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS for React
builder.Services.AddCors(options =>
    options.AddPolicy(ConstantValues.DevelopmentCORS, policy => policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
#endregion

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(ConstantValues.DevelopmentCORS);
}
app.UseHttpsRedirection();

app.MapControllers();

app.MapFallbackToFile("/index.html");

await app.RunAsync();
