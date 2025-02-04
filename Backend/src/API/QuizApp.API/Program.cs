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

builder.Services.AddInfrastructure(
    [SubscriptionsModule.ConfigureConsumers],
    cacheConnectionString);

builder.Configuration.AddModuleConfiguration(["quizzes", "users", "subscriptions"]);

builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString)
    .AddRedis(cacheConnectionString)
    .AddUrlGroup(new Uri(builder.Configuration.GetValue<string>("KeyCloak:HealthUrl")!), HttpMethod.Get, "keycloak");


builder.Services.AddQuizModule(builder.Configuration);
builder.Services.AddUsersModule(builder.Configuration);
builder.Services.AddSubscriptionsModule(builder.Configuration);

WebApplication app = builder.Build();

app.MapOpenApi();


if (app.Environment.IsDevelopment())
{
    app.ApplyMigrations();
    app.MapScalarApiReference(options =>
    {
        options.Servers =
        [
            new($"http://localhost:5000"),
            new($"https://localhost:5001"),
    ];
    });
}

app.MapEndpoints();

app.MapHealthChecks("health", new HealthCheckOptions()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseAuthentication();

app.UseAuthorization();

app.Run();
