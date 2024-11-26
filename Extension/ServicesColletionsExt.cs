
using Mi_primera_api_dotnet.Services;

namespace Mi_primera_api_dotnet.Extension
{
    public static class ServicesColletionsExt
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
                                                                            
            services.AddScoped<IBeerService, BeerService>();
            services.AddScoped<IBrandServices, BrandServices>();

            // EJEMPLO DE INYECCION DE LAS 3 TIPOS DE INSTANCIAS CON KEY

            services.AddKeyedSingleton<IRandomService, RandomService>("RandomSingleton");
            services.AddKeyedTransient<IRandomService, RandomService>("RandomTransiet");
            services.AddKeyedScoped<IRandomService, RandomService>("RandomScoped");


            services.AddScoped<IPostService, PostService>();
            services.AddSingleton<IPersonasService, PersonaServices>();
            services.AddKeyedSingleton<IPersonasService, PersonaServices>("MikeyInjection");
     


            return services;
        }

    }
}
