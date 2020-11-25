using System;
using System.Text.Json.Serialization;

namespace Fantasy.Models.ApiResponses
{
    public class DraftSettings
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("timePerPick")]
        public int TimePerPick { get; set; }

        [JsonPropertyName("canTradeDraftPicks")]
        public bool CanTradeDraftPicks { get; set; }
    }
}