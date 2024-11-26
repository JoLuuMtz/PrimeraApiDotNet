using Mi_primera_api_dotnet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mi_primera_api_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private IRandomService _randonSingleton;
        private IRandomService _randomScoped;
        private IRandomService _randomTransienT;

        private IRandomService _randon2Singleton;
        private IRandomService _random2Scoped;
        private IRandomService _random2Transient;


        public RandomController(    // implementando la inyeccion de dependencia
                                    // en mi controlador de 3 tipos de inyecciones 
         [FromKeyedServices("RandomSingleton")] IRandomService randonSingleton,
         [FromKeyedServices("RandomScoped")] IRandomService randomScoped,
         [FromKeyedServices("RandomTransiet")] IRandomService randomTransienT,
            [FromKeyedServices("RandomSingleton")] IRandomService random2Singleton,
         [FromKeyedServices("RandomScoped")] IRandomService random2Scoped,
         [FromKeyedServices("RandomTransiet")] IRandomService random2TransienT)

        {
            // inyeccionn de depedencia en mi controlador  o
            // asignacion de inyecion de parametros en el controlador 

            _randonSingleton = randonSingleton;
            _randomScoped = randomScoped;
            _randomTransienT = randomTransienT;

            _randon2Singleton = random2Singleton;
            _random2Scoped = random2Scoped;
            _random2Transient = random2TransienT;
        }


        [HttpGet]
        public ActionResult<Dictionary<string, int>> RandomData()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();

            // Primera llamada de las instancias 
            data.Add("Singleton1 ", _randonSingleton.Value);
            data.Add("Scoped 1 ", _randomScoped.Value);
            data.Add("Transient1 ", _randomTransienT.Value);


            // Segunda llamada  de las instancias 
            data.Add("Singleton 2  ", _randon2Singleton.Value);
            data.Add("Scoped 2  ", _random2Scoped.Value);
            data.Add("Transient 2 ", _random2Transient.Value);

            return Ok(data);
        }
    }
}
