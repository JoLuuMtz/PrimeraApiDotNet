using Mi_primera_api_dotnet.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Mi_primera_api_dotnet.Data

{
    public class PruebaET : DbContext
    {

        public PruebaET(DbContextOptions<PruebaET> options) : base(options)
        { }  // constructor vacio de la clase para que se pueda instanciar
        //  para asi asignar la conexion a la base de datos en  el startup.cs/program.cs

        public DbSet<Beer> Beers { get; set; } // propiedad de mi clase
                                               // para la creacion de la tabla 
        public DbSet<Brand> Brands { get; set; } // propiedad de mi clase


    }

}

