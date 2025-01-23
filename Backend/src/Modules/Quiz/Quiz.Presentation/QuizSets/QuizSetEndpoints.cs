using Microsoft.AspNetCore.Routing;

namespace Quiz.Presentation.QuizSets;

public static class QuizSetEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        //TODDO mapendpoints tekte olması lazım
        GetQuizSetsByUserId.MapEndpoint(app);
        CreateQuizSet.MapEndpoint(app);
        GetQuizSet.MapEndpoint(app);
    }
}
