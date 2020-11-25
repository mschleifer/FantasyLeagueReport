using System.Text.Json.Serialization;

namespace Fantasy.Models.ApiResponses
{
    public class ScheduleSettings
    {
        [JsonPropertyName("numberOfRegularSeasonMatchups")]
        public int NumberOfRegularSeasonMatchups { get; set; }

        [JsonPropertyName("regularSeasonMatchupLength")]
        public int RegularSeasonMatchupLength { get; set; }

        [JsonPropertyName("numberOfPlayoffMatchups")]
        public int NumberOfPlayoffMatchups { get; set; }

        [JsonPropertyName("playoffMatchupLength")]
        public int PlayoffMatchupLength { get; set; }

        [JsonPropertyName("numberOfPlayoffTeams")]
        public int NumberOfPlayoffTeams { get; set; }
    }
}