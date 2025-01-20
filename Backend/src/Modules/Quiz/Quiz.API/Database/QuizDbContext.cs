using Microsoft.EntityFrameworkCore;

namespace Quiz.API.Database;
public sealed class QuizDbContext(DbContextOptions<QuizDbContext> options) : DbContext(options)
{
    internal DbSet<Quiz.API.Quizzes.Quiz> Quizzes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Constants.QuizzesSchema);
    }
}
