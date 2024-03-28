﻿using System.Text.Json.Serialization;

namespace FlappyBird.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int ScoreValue {  get; set; }
        public decimal TimeInSeconds { get; set; }
        public DateTime? Date { get; set; }
        public bool IsPublic { get; set; }

        [JsonIgnore]
        public virtual User? User { get; set; }
    }
}
