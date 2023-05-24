namespace API.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Release_Year { get; set; }
        public string Gender { get; set; }
        public string Duration { get; set; }
        public int Director { get; set; }
    }
}