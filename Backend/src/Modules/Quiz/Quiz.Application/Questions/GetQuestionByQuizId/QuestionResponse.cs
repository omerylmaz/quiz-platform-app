namespace Quiz.Application.Questions.GetQuestionByQuizId;

public sealed record QuestionResponse(
    Guid Id,
    Guid QuizId,
    string Text,
    IReadOnlyCollection<ChoiceResponse> Choices
    );

public sealed record ChoiceResponse(
    Guid Id,
    Guid QuestionId,
    string Text,
    bool IsCorrect
    );
