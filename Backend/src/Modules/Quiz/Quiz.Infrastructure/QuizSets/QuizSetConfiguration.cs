using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.Domain.QuizSets;

namespace Quiz.Infrastructure.QuizSets;

internal sealed class QuizSetConfiguration : IEntityTypeConfiguration<QuizSet>
{
    public void Configure(EntityTypeBuilder<QuizSet> builder)
    {
        builder.HasKey(q => q.Id);

        builder.Property(q => q.Title)
            .HasMaxLength(200)
            .IsRequired(false);

        builder.Property(q => q.Description)
            .HasMaxLength(1000)
            .IsRequired(false);

        builder.HasMany(q => q.Categories)
            .WithMany(c => c.QuizSets);
    }
}
