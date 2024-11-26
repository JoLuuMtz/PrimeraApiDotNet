using System;
using System.Collections.Generic;
namespace Mi_primera_api_dotnet.Services
{
    public interface IPersonasService // contrato con mis servicios 
    {
        bool Validad(Persona persona);
    }
}
