using Mi_primera_api_dotnet.Data;
using Mi_primera_api_dotnet.DTOs;
using Mi_primera_api_dotnet.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Runtime.InteropServices.Marshalling;

namespace Mi_primera_api_dotnet.Controllers
{
    [Route("/Brand")]
    [ApiController]

    public class BrandController : ControllerBase
    {
        private readonly PruebaET _context;


        public BrandController(PruebaET context)
        {
            _context = context;
        }

        [HttpGet("get")]
        public async Task<IEnumerable<BrandDTO>> Get()
        {
            return await _context.Brands.Select(x => new BrandDTO
            {
                BrandId/*colum db*/ = x./*propiedad DTO*/BrandId,
                Name = x.Name
            }).ToListAsync();
          
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = await _context.Brands.FindAsync(id);

            if (brand == null)
            {
                return NotFound("No se encontró la marca");
            }
            _context.Brands.Remove(brand);
            _context.SaveChangesAsync();

            return Ok("Se elimino el objeto");

        }

        [HttpPost("add")]
        public async Task<ActionResult<BrandDTO>> Post(int id, CreatedBrandDTO Create)
        {
            var x = await _context.Brands.FindAsync(Create.BrandId);

            if (x == null)
            {
                var brand = new Brand
                {
                    Name = Create.Name,
                    BrandId = Create.BrandId
                };


                await _context.Brands.AddAsync(brand);
                await _context.SaveChangesAsync();

                return Ok("Se inserto la marca");
            }
            return BadRequest("Esta marca ya existe");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateBrand(int id, UpdateBrandDTO Brand)
        {

            var brand = await _context.Brands.FindAsync(id);

            if (brand == null)
            {
                return NotFound("No se encontro la marca");
            }
            else
            {
                brand.Name = Brand.Name;
                _context.Brands.Update(brand);
                await _context.SaveChangesAsync();
                return Ok($"se actualizo el id {id}");
            }




        }

    }


}


