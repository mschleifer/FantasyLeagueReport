using System.Text.Json.Serialization;

namespace Fantasy.Models.ApiResponses
{
    public class PositionLimits
    {
        [JsonPropertyName("QB")]
        public int QB { get; set; }

        [JsonPropertyName("TQB")]
        public int TQB { get; set; }

        [JsonPropertyName("RB")]
        public int RB { get; set; }

        [JsonPropertyName("RB/WR")]
        public int RBWR { get; set; }

        [JsonPropertyName("WR")]
        public int WR { get; set; }

        [JsonPropertyName("WR/TE")]
        public int WRTE { get; set; }

        [JsonPropertyName("TE")]
        public int TE { get; set; }

        [JsonPropertyName("OP")]
        public int OP { get; set; }

        [JsonPropertyName("DT")]
        public int DT { get; set; }

        [JsonPropertyName("DE")]
        public int DE { get; set; }

        [JsonPropertyName("LB")]
        public int LB { get; set; }

        [JsonPropertyName("DL")]
        public int DL { get; set; }

        [JsonPropertyName("CB")]
        public int CB { get; set; }

        [JsonPropertyName("S")]
        public int S { get; set; }

        [JsonPropertyName("DB")]
        public int DB { get; set; }

        [JsonPropertyName("DP")]
        public int DP { get; set; }

        [JsonPropertyName("D/ST")]
        public int DST { get; set; }

        [JsonPropertyName("K")]
        public int K { get; set; }
    }
}