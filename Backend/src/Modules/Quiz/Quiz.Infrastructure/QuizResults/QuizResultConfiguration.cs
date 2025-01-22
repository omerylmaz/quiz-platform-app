using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.Domain.QuizResults;
using Quiz.Domain.QuizSets;

namespace Quiz.Infrastructure.QuizResults;

internal sealed class QuizResultConfiguration : IEntityTypeConfiguration<QuizResult>
{
    public void Configure(EntityTypeBuilder<QuizResult> builder)
    {
        builder.HasKey(qr => qr.Id);

        builder.HasOne<QuizSet>()
            .WithMany()
            .HasForeignKey(x => x.QuizSetId);
    }
}
