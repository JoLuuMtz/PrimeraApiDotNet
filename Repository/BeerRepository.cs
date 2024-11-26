using Mi_primera_api_dotnet.Controllers;
using Mi_primera_api_dotnet.Data;
using Mi_primera_api_dotnet.Model;
using Microsoft.EntityFrameworkCore;

namespace Mi_primera_api_dotnet.Repository
{
    public class BeerRepository : IRepository<Beer>
    {
        private readonly PruebaET _context;
        public BeerRepository(PruebaET context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Beer>> GetAll()
        {
            return await _context.Beers.ToListAsync();
        }
        public async Task<Beer> GetById(int id)
        {
            return await _context.Beers.FindAsync(id);
        }
        public async Task Insert(Beer entity)
        {
            _context.Beers.Add(entity);
            await _context.SaveChangesAsync();
        }
        public void Update(Beer entity)
        {

            _context.Beers.Update(entity);  // actualiza de forma consisa 

            /* mandejo de estado de la entidad 
            _context.Beers.Attach(entity);
                 Controla el esatdo de la entidad y lo modifica
            _context.Beers.Entry(entity).State = EntityState.Modified; */
        }
        public void Delete(Beer Entity)
        {
            _context.Beers.Remove(Entity);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public IEnumerable<Beer> GetByBrand(int id)
        {

            return _context.Beers.Where(b => b.BrandId == id).ToList();

        }
    }
   

}

