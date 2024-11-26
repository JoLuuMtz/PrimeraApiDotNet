using Mi_primera_api_dotnet.Services;
using Microsoft.AspNetCore.Mvc;
namespace Mi_primera_api_dotnet.Controllers
{
    [Route("/Personas")]
    [ApiController]
    public class PersonaController : ControllerBase
    {

        private IPersonasService _personasServices; // inyeccion de dependencias

        public PersonaController([FromKeyedServices("MikeyInjection")] IPersonasService personasServices)
        {
            _personasServices = personasServices;// implementacion de la 
                                                 // en el constructor

        }

        [HttpGet("personas")]
        public List<Persona> Get()
        {
            return ListaPersonaas.Persona;

        }
        [HttpGet("personasPares")]
        public List<Persona> GetPares(int id)
        {
            var personasPorId = (from personas in ListaPersonaas.Persona
                                 where personas.Id % 2 == 0
                                 select personas).ToList();

            return personasPorId; //retorna mi api con los id pares

        }
        [HttpGet("Filtro/{id}")]
        public IActionResult ObtenerPersona(int id)
        {
            var personasPorId = (from personas in ListaPersonaas.Persona
                                 where personas.Id == id
                                 select personas);   // encuentra una lista de items
                                                     // que cumplan la codicion

            var reponseId = ListaPersonaas.
                            Persona.
                            First(p => p.Id == id); // encuenta el primero y ya 




            var sinId = personasPorId.FirstOrDefault(p => p.Id == id);// si no hay nada devuelve null 
            if (sinId == null)
            {
                return NotFound("No se encontró la persona");

            }
            return Ok(personasPorId);   // retorna una serializacion de json 


        }
        [HttpGet("nombres/{name}")]
        public IActionResult ObtenerNombre(string name)
        {

            var NombresPersonas = from personas in ListaPersonaas.Persona
                                  where personas.Nombre.ToLower() == name.ToLower()
                                  select personas;

            if (!NombresPersonas.Any())  // valida si no encuentra nada en la consulta LINQ
            {
                return NotFound("nadie se llama asi ");
            }

            return Ok(NombresPersonas);// Serializado Json 
        }

        // agregar 
        [HttpPost("add")]     // agrega usuario 
        public IActionResult Agregar(Persona persona)
        {
            if (!_personasServices.Validad(persona))
            {
                return BadRequest("El nombre es requerido");
            }
            else
            {
                ListaPersonaas.Persona.Add(persona);
                return NoContent();  // no retorna contenido porque es una accion post
            }




        }

    }
}

public class Persona
{
    private int _id;
    private int _edad;
    private string _nombre;
    private DateTime _fechaNacimiento;


    public int Id { get => _id; set => _id = value; }
    public int Edad { get => _edad; set => _edad = value; }
    public string Nombre { get => _nombre; set => _nombre = value; }
    public DateTime FechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }

}

public class ListaPersonaas

{

    public static List<Persona> Persona = new List<Persona>()
        {
            new Persona
            {
                Id = 1,
                Nombre = "Juan",
                Edad = 20,
                FechaNacimiento = new DateTime(2000, 1, 1)
            },
            new Persona
            {
                Id = 1,
                Nombre = "Juan",
                Edad = 20,
                FechaNacimiento = new DateTime(2000, 1, 1)

            },
            new Persona
            {
                Id = 2,
                Nombre = "Pedro",
                Edad = 30,
                FechaNacimiento = new DateTime(1990, 1, 1)
            },
            new Persona
            {
                    Id = 3,
                Nombre = "Maria",
                Edad = 40,
                FechaNacimiento = new DateTime(1980, 1, 1)
            },
            new Persona
            {
                Id = 4,
                Nombre = "Jose",
                Edad = 50,
                FechaNacimiento = new DateTime(1970, 1, 1)

            }

        };




}




