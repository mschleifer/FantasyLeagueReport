using System.Text.Json.Serialization;

namespace Fantasy.Models.ApiResponses
{
    public class League
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("isPublic")]
        public bool IsPublic { get; set; }

        [JsonPropertyName("draftSettings")]
        public DraftSettings DraftSettings { get; set; }

        [JsonPropertyName("rosterSettings")]
        public RosterSettings RosterSettings { get; set; }

        [JsonPropertyName("scheduleSettings")]
        public ScheduleSettings ScheduleSettings { get; set; }
    }
}