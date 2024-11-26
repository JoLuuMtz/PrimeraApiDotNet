using Mi_primera_api_dotnet.DTOs;
using System.Collections.Specialized;
using System.Text.Json;
using System.Xml;
using System.Net.Http;
using System.Data.Common;

namespace Mi_primera_api_dotnet.Services
{
    public class PostService : IPostService
    {
        private HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }
        // implementacion de mi Interfaz en mi services
        public async Task<IAsyncEnumerable<PostDTO>> GetPost()
        {

            // url a la que se hace la peticion 
                     
            // se hace la peticion a la url con el metodo get
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress);
            // obtenemos el contenido de la respuesta 
            var body = await response.Content.ReadAsStringAsync();

            // como las propiedades de mi DTO estan escritas en Upper Cammel case
            // y los de la APi estan en lower cammel case, se debe hacer una conversion
            // para que haya coincidencia en el DTO y la api

            var opcion = new JsonSerializerOptions()  // inicialzia el objeto de opciones
            {
                PropertyNameCaseInsensitive = true   // true para que no importe si
                                                     // es mayuscula o minuscula
            };

            // deserealizar el objeto porque viene serializado en json
            var post = JsonSerializer.
                Deserialize<IAsyncEnumerable<PostDTO>>(body,opcion);  // se le agrega el
                                                                      // parametro del objeto 
                                                                  // body,opcion

            // nota: Cuando el json viene de afuera se deserealiza,
            // cuando tu lo vas a mandar es serializar 

            return post; // retorna la lista de post

        }
    }
}
