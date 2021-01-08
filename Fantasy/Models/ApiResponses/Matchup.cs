using System.Text.Json.Serialization;

namespace Fantasy.Models.ApiResponses
{
    public class Matchup
    {
        [JsonPropertyName("matchupPeriodId")]
        public int MatchupPeriodId { get; set; }

        [JsonPropertyName("homeScore")]
        public double HomeScore { get; set; }

        [JsonPropertyName("homeTeamId")]
        public int HomeTeamId { get; set; }


        [JsonPropertyName("awayScore")]
        public double AwayScore { get; set; }

        [JsonPropertyName("awayTeamId")]
        public int AwayTeamId { get; set; }
    }
}
