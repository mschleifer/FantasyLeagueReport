using System.Text.Json.Serialization;

namespace Fantasy.Models.ApiResponses
{
    public class RosterSettings
    {
        [JsonPropertyName("lineupPositionCount")]
        public LineupPositionCount LineupPositionCount { get; set; }

        [JsonPropertyName("positionLimits")]
        public PositionLimits PositionLimits { get; set; }

        [JsonPropertyName("locktime")]
        public string Locktime { get; set; }
    }
}