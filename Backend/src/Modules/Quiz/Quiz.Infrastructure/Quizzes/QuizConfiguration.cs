using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Quiz.Infrastructure.Quizzes;
internal sealed class QuizConfiguration : IEntityTypeConfiguration<Domain.Quizzes.Quiz>
{
    public void Configure(EntityTypeBuilder<Domain.Quizzes.Quiz> builder)
    {
        Console.WriteLine();
    }
}
