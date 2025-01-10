using Microsoft.EntityFrameworkCore;
using QuizApplication.DataAccess.Context;
using QuizApplication.DataAccess.Contracts;
using QuizApplication.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

#region Services/Repositories
builder.Services.AddControllers();

builder.Services.AddDbContext<QuizDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLite")));

builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
