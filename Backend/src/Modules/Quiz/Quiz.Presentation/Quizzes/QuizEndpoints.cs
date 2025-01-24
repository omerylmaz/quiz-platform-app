using Microsoft.AspNetCore.Routing;

namespace Quiz.Presentation.Quizzes;
public static class QuizEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CreateQuiz.MapEndpoint(app);
        GetQuiz.MapEndpoint(app);
        SolveQuiz.MapEndpoint(app);
    }
}
