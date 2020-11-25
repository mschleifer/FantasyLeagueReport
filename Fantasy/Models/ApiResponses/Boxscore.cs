using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Fantasy.Models.ApiResponses
{
    public class Boxscore
    {
        [JsonPropertyName("homeScore")]
        public double HomeScore { get; set; }

        [JsonPropertyName("homeTeamId")]
        public int HomeTeamId { get; set; }

        [JsonPropertyName("homeRoster")]
        public List<BoxscorePlayer> HomeRoster { get; set; }

        [JsonPropertyName("awayScore")]
        public double AwayScore { get; set; }

        [JsonPropertyName("awayTeamId")]
        public int AwayTeamId { get; set; }

        [JsonPropertyName("awayRoster")]
        public List<BoxscorePlayer> AwayRoster { get; set; }
    }
}