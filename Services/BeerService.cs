using AutoMapper;
using Mi_primera_api_dotnet.Data;
using Mi_primera_api_dotnet.DTOs;
using Mi_primera_api_dotnet.Model;
using Mi_primera_api_dotnet.Repository;

namespace Mi_primera_api_dotnet.Services
{
    public class BeerService : IBeerService
    {
        public List<string> errores { get; }

        private readonly IRepository<Beer> _repository;
        private readonly IMapper _mapper;



        public BeerService(PruebaET context, IRepository<Beer> repository, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;

        }


        public async Task<BeersDTO> DeleteBeer(int id)
        {
            var beer = await _repository.GetById(id);
            if (beer == null)
            {
                return null;
            }
            _repository.Delete(beer);
            await _repository.Save();
            return new BeersDTO();

        }

        public async Task<IEnumerable<BeersDTO>> GetAll()
        {
            var beers = await _repository.GetAll();  // hace la opracion del metodo  

            return beers.Select(b => _mapper.Map<BeersDTO>(b));  // mapea la entidad Beer con el DTO BeersDTO

        }

        public async Task<BeersDTO> GetById(int id)
        {
            var OnlyOnebeer = await _repository.GetById(id);

            if (OnlyOnebeer != null)
            {
                var x = _mapper.Map<BeersDTO>(OnlyOnebeer); // retorna el objeto mapeado que es de tipo BeersDTO
                return x;

            }
            return null;
        }


        public async Task<BeersDTO> InsertBeer(CreatedBeerDTO beer)
        {
            var beer1 = _mapper.Map<Beer>(beer);  // mape la entidad Beer con el DTO CreatedBeerDTO

            await _repository.Insert(beer1);  // inserto la entiedad mapeada en la base de datos
            await _repository.Save();

            var beer1DTO = _mapper.Map<BeersDTO>(beer1);  // mapeo el beer1 con el DTO
                                                          // BeersDTO para retornar el objeto
            return beer1DTO;

            //return new BeersDTO    // forma sin automappers de crear objetos de tipo BeersDTO
            //{
            //    BeerId = newBeer.BeerId,
            //    Name = newBeer.Name,
            //    Description = newBeer.Description,
            //    BrandId = newBeer.BrandId
            //};

        }
        public async Task<BeersDTO> UpdateBeer(int id, UpdateBeerDTO? update)
        {
            var x = await _repository.GetById(id);

            if (x == null) return null;

            if (!string.IsNullOrEmpty(update.Name)) x.Name = update.Name;

            if (!string.IsNullOrEmpty(update.Description)) x.Description = update.Description;

            var mapping = _mapper.Map<BeersDTO>(x);
            _repository.Update(x);
            await _repository.Save();

            return mapping;
        }

        // validadores de Insert Y Update
        public bool  ValideInsert(CreatedBeerDTO dto)
        {

            return true;
         
        }

        public bool ValideUpdate(UpdateBeerDTO dto)
        {
            return true;
        }

    }
}

