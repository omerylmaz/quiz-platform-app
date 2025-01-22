using Quiz.Infrastructure;
using QuizApp.API.Extensions;
using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddQuizModule(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.ApplyMigrations();
}

QuizModule.MapEndpoints(app);

app.MapScalarApiReference();
app.MapOpenApi();

app.Run();
