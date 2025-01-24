using Common.Application.Messaging;

namespace Quiz.Application.Quizzes.SolveQuiz;

public sealed record SolveQuizCommand(Guid QuizId, List<SolveQuizQuestion> Questions) : ICommand<SolveQuizResponse>;

public sealed record SolveQuizQuestion(Guid QuestionId, Guid ChoiceId);

public sealed record SolveQuizResponse(int Score);
