
using FluentValidation;
using Mi_primera_api_dotnet.Data;
using Mi_primera_api_dotnet.DTOs;
using Mi_primera_api_dotnet.Model;
using Mi_primera_api_dotnet.Repository;
using Mi_primera_api_dotnet.Services;
using Mi_primera_api_dotnet.Validators;
using Mi_primera_api_dotnet.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mi_primera_api_dotnet.AutoMappers;


namespace Mi_primera_api_dotnet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            RepositoryCollectionExt.AddRepository(builder.Services);
            ServicesColletionsExt.AddServices(builder.Services);

            //http Client
            builder.Services.AddHttpClient<IPostService, PostService>(c =>
            {
                c.BaseAddress = new Uri(builder.Configuration["BaseUrlPost"]);
            });

            //Entity FrameWork  and DB
            builder.Services.AddDbContext<PruebaET>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("PruebaETConnection"));
            });


            //Validator
            builder.Services.AddScoped<IValidator<CreatedBeerDTO>, BeerInsertValidator>();

            //AutoMapping 
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });



            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("AllowAllOrigins");
            app.MapControllers();
            app.Run();
        }
    }
}
