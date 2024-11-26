using Mi_primera_api_dotnet.Repository;
using Mi_primera_api_dotnet.Data;
using Mi_primera_api_dotnet.Model;
using System;
namespace Mi_primera_api_dotnet.Extension
{

    public static class RepositoryCollectionExt

    {
   
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Beer>, BeerRepository>();

            return services;
        }
    }
}
