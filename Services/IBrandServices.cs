using Mi_primera_api_dotnet.DTOs;

namespace Mi_primera_api_dotnet.Services
{
    public interface IBrandServices
    {
        public  Task<IEnumerable<BrandDTO>> GetAllBrands();

    }
}
