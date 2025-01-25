using Common.Application;
using Common.Infrastructure;
using Quiz.Infrastructure;
using QuizApp.API.Extensions;
using QuizApp.API.Middlewares;
using Scalar.AspNetCore;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddProblemDetails();

builder.Services.AddOpenApi();

builder.Services.AddApplication([Quiz.Application.AssemblyReference.Assembly]);

builder.Services.AddInfrastructure();

builder.Configuration.AddModuleConfiguration(["quizzes"]);

builder.Services.AddQuizModule(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.ApplyMigrations();
}

QuizModule.MapEndpoints(app);

app.MapScalarApiReference();
app.MapOpenApi();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.Run();
