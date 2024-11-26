using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Mi_primera_api_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {


        [HttpGet("async")]  // metodo asincrono prueba
        public async Task<IActionResult> metodoAsyncrono()
        {
            Task<string> miTarea = new Task<string>(() =>
            {
                Console.WriteLine("Pidiendo los datos ");

                Thread.Sleep(5000);

                Console.WriteLine(" datos obtenidos ");
                return "Dato 1 ,2 ,3 ,4 ,5";

            });
       
            miTarea.Start();

            string datosObtenidos = await miTarea;


            Console.WriteLine("Fin del proceso");

            return Ok(datosObtenidos);


        }

    }
}
