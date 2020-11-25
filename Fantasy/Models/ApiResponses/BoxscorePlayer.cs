using System.Text.Json.Serialization;

namespace Fantasy.Models.ApiResponses
{
    public class BoxscorePlayer
    {
        [JsonPropertyName("player")]
        public Player Player { get; set; }

        [JsonPropertyName("position")]
        public string Position { get; set; }

        [JsonPropertyName("totalPoints")]
        public double TotalPoints { get; set; }

        [JsonPropertyName("pointBreakdown")]
        public PlayerStats PointBreakdown { get; set; }

        [JsonPropertyName("projectedPointBreakdown")]
        public PlayerStats ProjectedPointBreakdown { get; set; }

        [JsonPropertyName("rawStats")]
        public PlayerStats RawStats { get; set; }

        [JsonPropertyName("projectedRawStats")]
        public PlayerStats ProjectedRawStats { get; set; }
    }
}