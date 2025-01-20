using Microsoft.EntityFrameworkCore;
using Quiz.Application.Abstractions.Data;

namespace Quiz.Infrastructure.Database;
public sealed class QuizDbContext(DbContextOptions<QuizDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Domain.Quizzes.Quiz> Quizzes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Constants.QuizzesSchema);
    }
}
