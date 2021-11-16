using FakeRESTAPI.Web.Services;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IRepository, SimpleFakeRepository>();
        return services;
    }
}