using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Quiz.Application.Abstractions.Data;
using Quiz.Domain.Categories;
using Quiz.Domain.Questions;
using Quiz.Domain.QuizResults;
using Quiz.Domain.QuizSets;

namespace Quiz.Infrastructure.Database;
public sealed class QuizDbContext(DbContextOptions<QuizDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Domain.Quizzes.Quiz> Quizzes { get; set; }
    internal DbSet<Category> Categories { get; set; }
    internal DbSet<QuizSet> QuizSets { get; set; }
    internal DbSet<Question> Questions { get; set; }
    internal DbSet<Choice> Choices { get; set; }
    internal DbSet<QuizResult> QuizResults { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Constants.QuizzesSchema);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
