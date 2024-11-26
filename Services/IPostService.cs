using Mi_primera_api_dotnet.DTOs;

namespace Mi_primera_api_dotnet.Services
{
    public interface IPostService
    {
        // estoy usando Enumerable para poder recorrer una lista de objetos
        // en este caso es una api de post
        public Task<IAsyncEnumerable<PostDTO>> GetPost();
       
    }
}
