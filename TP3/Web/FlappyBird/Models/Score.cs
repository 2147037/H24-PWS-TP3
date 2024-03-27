namespace FlappyBird.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int Point {  get; set; }
        public decimal Temps { get; set; }
        public DateTime Date { get; set; }
        public bool Visibilité { get; set; }
    }
}
