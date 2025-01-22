using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.Domain.Questions;

namespace Quiz.Infrastructure.Questions;

internal sealed class ChoiceConfiguration : IEntityTypeConfiguration<Choice>
{
    public void Configure(EntityTypeBuilder<Choice> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Text)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasOne<Question>()
            .WithMany(q => q.Choices)
            .HasForeignKey(c => c.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
