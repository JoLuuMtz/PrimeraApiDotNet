using System.Net.Http;
namespace Mi_primera_api_dotnet.Services
{
    public class PersonaServices : IPersonasService
    {
        public bool Validad(Persona persona)
        {
            if (string.IsNullOrEmpty(persona.Nombre))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
