using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Domain.Categories;

namespace Quiz.Application.QuizSets.GetQuizSet;

public sealed record QuizSetResponse(
    Guid Id,
    string Title,
    string Description,
    List<string> Categories
    );
