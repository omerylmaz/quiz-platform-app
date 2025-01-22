using Microsoft.AspNetCore.Routing;

namespace Quiz.Presentation.Categories;

public static class CategoryEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        //TODDO mapendpoints tekte olması lazım
        CreateCategory.MapEndpoint(app);
        GetCategory.MapEndpoint(app);
        UpdateCategory.MapEndpoint(app);
    }
}
