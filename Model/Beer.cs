using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mi_primera_api_dotnet.Model
{
    public class Beer

    {
        [Key]         //    toma el atributo como llave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //autoincrementable
                                                               // en la DB
        public int BeerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }    // propiedad donde estara la
                                            // primari key d e la tabla  Brand

        [ForeignKey("BrandId")]    // llave foranea de Brand
        public virtual Brand Brand { get; set; }// propiedad virtual para que
                                                // Entity Framework Core pueda
                                                // hacer seguimiento de la relación

    }
}
