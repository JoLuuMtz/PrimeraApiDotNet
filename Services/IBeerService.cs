using Mi_primera_api_dotnet.DTOs;
using Microsoft.AspNetCore.Mvc;
namespace Mi_primera_api_dotnet.Services

{
    public interface IBeerService
    {
        public List<string> errores { get; }




        public Task<IEnumerable<BeersDTO>> GetAll();
        public Task<BeersDTO> GetById(int id);

        public Task<BeersDTO> InsertBeer(CreatedBeerDTO beer);
        public Task<BeersDTO> UpdateBeer(int id, UpdateBeerDTO? beer);

        public Task<BeersDTO> DeleteBeer(int id);

        public bool ValideInsert(CreatedBeerDTO dto);
        public bool ValideUpdate(UpdateBeerDTO dto);


    }
}
