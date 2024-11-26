namespace Mi_primera_api_dotnet.DTOs
{
    public class PostDTO     // permite hacer la transferencia de los datos del modelo 
                             // en diferentes capas del proyecto
    {
        private int _id;
        private int _userId;
        private string _title;
        private string _body;

        public int Id { get => _id; set => _id = value; }
        public int UserId { get => _userId; set => _userId = value; }
        public string Title { get => _title; set => _title = value; }
        public string Body { get => _body; set => _body = value; }

    }
}
