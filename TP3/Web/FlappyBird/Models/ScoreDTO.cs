namespace FlappyBird.Models
{
    public class ScoreDTO
    {
        public int Id { get; set; }

        public int ScoreValue { get; set; }
        public double TimeInSeconds { get; set; }
        public DateTime? Date { get; set; }
        public bool IsPublic { get; set; }
        public string Pseudo { get; set; }

    }
}
