using FluentValidation;
using Mi_primera_api_dotnet.Data;
using Mi_primera_api_dotnet.DTOs;
using Mi_primera_api_dotnet.Model;
using Mi_primera_api_dotnet.Services;
using Mi_primera_api_dotnet.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mi_primera_api_dotnet.Controllers
{
    [Route("Beer")]
    [ApiController]


    public class BeersController : ControllerBase
    {

        private readonly IValidator<CreatedBeerDTO> _validatorInsertBeer;
        private readonly IBeerService _beerService;

        public BeersController(
                                IValidator<CreatedBeerDTO> validatorInsertBeer,
                                IBeerService beerService)
        {

            _validatorInsertBeer = validatorInsertBeer;   //D.I del validaor de 
            _beerService = beerService;
        }

        [HttpGet("getId/{id}")]
        public async Task<ActionResult<BeersDTO>> GetById(int id)
        {
            var beer = await _beerService.GetById(id);

            if (beer == null)
            {
                return NotFound("No se encontró la cerveza");
            }
            await _beerService.GetById(id);
            
            return beer;

            // return onlye one beer
        }


        [HttpGet("get")]     // retorna todas las cervezas
        public async Task<IEnumerable<BeersDTO>> get() => await _beerService.GetAll();


        [HttpPost("post")]
        public async Task<ActionResult<BeersDTO>> post(CreatedBeerDTO beer)
        {
            // variable que recibe el resultado de la validacion del DTO
            var result = _validatorInsertBeer.Validate(beer);

            if (result.IsValid)
            {
                await _beerService.InsertBeer(beer);
                return CreatedAtAction(nameof(GetById), new { id = beer.BeerId }, beer);
            }
            else
            {

                //try
                //{
                //    if (_beerService.ValideInsert(beer))
                //    {
                //        return BadRequest(_beerService.errores);
                //    }
                //}
                //catch (Exception)
                //{
                //    return StatusCode(StatusCodes.Status400BadRequest, "Error al insertar la cerveza");
                //};
                return BadRequest(result.Errors);

            }


        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var x = await _beerService.GetById(id);

            if (x == null)
            {
                return NotFound("No se encontró la cerveza");
            }
            await _beerService.DeleteBeer(id);

            return Ok($"Se eliminó la cerveza {x.Name}");

        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, UpdateBeerDTO updateBeer)
        {
            // valida si esta en la base de datos
            var x = await _beerService.GetById(id);

            if (!_beerService.ValideUpdate(updateBeer))
            {
                return BadRequest(_beerService.errores);
            }
            if (!(x == null))
            {
                await _beerService.UpdateBeer(id, updateBeer);
                return Ok($"se actualizó la cerveza {id}");
            }
            return NotFound("no se encontró la cerveza");

        }

    }

}


