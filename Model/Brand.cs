using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mi_primera_api_dotnet.Model
{
    public class Brand
    {
        [Key]       // toma el atributo como llave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // autoincrementable                                                 // en la DB
        public int BrandId { get; set; }
        public string Name { get; set; }


    }
}
