using mechanico.Interfaces;

namespace mechanico.Context;

public abstract class DependencyRegistration
{
    public static void RegisterDependencies(IServiceCollection services)
    {
        services.AddScoped<IMechanicRepository, MechanicRepository>();
        services.AddAutoMapper(typeof(Program));

    }
}