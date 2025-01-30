using Common.Application;
using Common.Infrastructure;
using Common.Presentation.Endpoints;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Quiz.Infrastructure;
using QuizApp.API.Extensions;
using QuizApp.API.Middlewares;
using Scalar.AspNetCore;
using Serilog;
using Subscriptions.Infrustructure;
using Users.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddProblemDetails();

builder.Services.AddOpenApi();

builder.Services.AddApplication([
    Quiz.Application.AssemblyReference.Assembly,
    Users.Application.AssemblyReference.Assembly,
    Subscriptions.Application.AssemblyReference.Assembly]);

string cacheConnectionString = builder.Configuration.GetConnectionString("Cache")!;
string databaseConnectionString = builder.Configuration.GetConnectionString("Database")!;

builder.Services.AddInfrastructure(cacheConnectionString);

builder.Configuration.AddModuleConfiguration(["quizzes", "users", "subscriptions"]);

builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString)
    .AddRedis(cacheConnectionString);

builder.Services.AddQuizModule(builder.Configuration);
builder.Services.AddUsersModule(builder.Configuration);
builder.Services.AddSubscriptionsModule(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.ApplyMigrations();
}

app.MapEndpoints();

app.MapHealthChecks("health", new HealthCheckOptions()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapOpenApi();
app.MapScalarApiReference();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.Run();
