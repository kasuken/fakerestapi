using FakeRESTAPI.Web.Models;
using FakeRESTAPI.Web.Services;

namespace FakeRESTAPI.Web;

public static class RegisterMapRoutesActivities
{
    public static IEndpointRouteBuilder RegisterActivitiesRoutes(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/activities", (IRepository repository) =>
        {
            return Results.Ok(repository.LoadActivities());
        });

        builder.MapGet("/activities/{id}", (int id, IRepository repository) =>
        {
            var activity = repository.LoadActivities().Where(b => b.ID == id).FirstOrDefault();

            if (activity == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(activity);
        });

        builder.MapPost("/activities", (Activity activity, IRepository repository) =>
        {
            return Results.Ok(activity);
        });

        builder.MapPut("/activities", (int id, Activity activity, IRepository repository) =>
        {
            return Results.Ok(activity);
        });

        builder.MapDelete("/activities", (int id) => Results.Accepted());

        return builder;
    }
}
