namespace Mi_primera_api_dotnet.Services
{
    public class RandomService : IRandomService
    {
        private readonly int _value;
        public int Value => _value; //Propiedad de la interfaz a implementar


           public RandomService()
        {
             _value = new Random().Next(0, 100); // valor aleatorio entre 0 y 1000
        }

    }
}
