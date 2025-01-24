using Common.Domain;
using Quiz.Domain.QuizSets;

namespace Quiz.Domain.Categories;

public sealed class Category : Entity
{
    private Category() { }

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public ICollection<QuizSet> QuizSets { get; private set; }

    public static Category Create(string Name)
    {
        var category = new Category()
        {
            Id = Guid.NewGuid(),
            Name = Name
        };

        return category;
    }

    public void ChangeName(string name)
    {
        if (Name == name)
            return;

        Name = name;
    }
}
