using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.Domain.QuizSets;

namespace Quiz.Infrastructure.Quizzes;

internal sealed class QuizConfiguration : IEntityTypeConfiguration<Domain.Quizzes.Quiz>
{
    public void Configure(EntityTypeBuilder<Domain.Quizzes.Quiz> builder)
    {
        builder.HasKey(q => q.Id);

        builder.Property(q => q.Title)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(q => q.Description)
            .HasColumnType("TEXT")
            .IsRequired(false);

        builder.Property(q => q.CreatedByAI)
            .IsRequired();

        builder.Property(q => q.Difficulty)
            .HasConversion<string>()
            .IsRequired();

        builder.HasOne<QuizSet>()
            .WithMany()
            .HasForeignKey(q => q.QuizSetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
