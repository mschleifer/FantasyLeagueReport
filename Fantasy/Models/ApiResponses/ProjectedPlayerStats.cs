using System.Text.Json.Serialization;

namespace Fantasy.Models.ApiResponses
{
    public class PlayerStats
    {
        [JsonPropertyName("usesPoints")]
        public bool UsesPoints { get; set; }

        [JsonPropertyName("rushingYards")]
        public double RushingYards { get; set; }

        [JsonPropertyName("rushingTouchdowns")]
        public double RushingTouchdowns { get; set; }

        [JsonPropertyName("rushing2PtConversions")]
        public double Rushing2PtConversions { get; set; }

        [JsonPropertyName("receivingYards")]
        public double ReceivingYards { get; set; }

        [JsonPropertyName("receivingTouchdowns")]
        public double ReceivingTouchdowns { get; set; }

        [JsonPropertyName("receiving2PtConversions")]
        public double Receiving2PtConversions { get; set; }

        [JsonPropertyName("receivingReceptions")]
        public double ReceivingReceptions { get; set; }

        [JsonPropertyName("lostFumbles")]
        public double LostFumbles { get; set; }

        [JsonPropertyName("madeFieldGoalsFrom40To49")]
        public double? MadeFieldGoalsFrom40To49 { get; set; }

        [JsonPropertyName("madeFieldGoalsFromUnder40")]
        public double? MadeFieldGoalsFromUnder40 { get; set; }

        [JsonPropertyName("missedFieldGoals")]
        public double? MissedFieldGoals { get; set; }

        [JsonPropertyName("madeExtraPoints")]
        public double? MadeExtraPoints { get; set; }

        [JsonPropertyName("missedExtraPoints")]
        public double? MissedExtraPoints { get; set; }

        [JsonPropertyName("kickoffReturnTouchdown")]
        public double? KickoffReturnTouchdown { get; set; }

        [JsonPropertyName("defensive0PointsAllowed")]
        public double? Defensive0PointsAllowed { get; set; }

        [JsonPropertyName("defensive1To6PointsAllowed")]
        public double? Defensive1To6PointsAllowed { get; set; }

        [JsonPropertyName("defensive7To13PointsAllowed")]
        public double? Defensive7To13PointsAllowed { get; set; }

        [JsonPropertyName("defensive14To17PointsAllowed")]
        public double? Defensive14To17PointsAllowed { get; set; }

        [JsonPropertyName("defensiveBlockedKickForTouchdowns")]
        public double? DefensiveBlockedKickForTouchdowns { get; set; }

        [JsonPropertyName("defensiveInterceptions")]
        public double? DefensiveInterceptions { get; set; }

        [JsonPropertyName("defensiveFumbles")]
        public double? DefensiveFumbles { get; set; }

        [JsonPropertyName("defensiveBlockedKicks")]
        public double? DefensiveBlockedKicks { get; set; }

        [JsonPropertyName("defensiveSafeties")]
        public double? DefensiveSafeties { get; set; }

        [JsonPropertyName("defensiveSacks")]
        public double? DefensiveSacks { get; set; }

        [JsonPropertyName("puntReturnTouchdown")]
        public double? PuntReturnTouchdown { get; set; }

        [JsonPropertyName("fumbleReturnTouchdown")]
        public double? FumbleReturnTouchdown { get; set; }

        [JsonPropertyName("interceptionReturnTouchdown")]
        public double? InterceptionReturnTouchdown { get; set; }

        [JsonPropertyName("defensive28To34PointsAllowed")]
        public double? Defensive28To34PointsAllowed { get; set; }

        [JsonPropertyName("defensive35To45PointsAllowed")]
        public double? Defensive35To45PointsAllowed { get; set; }

        [JsonPropertyName("defensive100To199YardsAllowed")]
        public double? Defensive100To199YardsAllowed { get; set; }

        [JsonPropertyName("defensive200To299YardsAllowed")]
        public double? Defensive200To299YardsAllowed { get; set; }

        [JsonPropertyName("defensive350To399YardsAllowed")]
        public double? Defensive350To399YardsAllowed { get; set; }

        [JsonPropertyName("defensive400To449YardsAllowed")]
        public double? Defensive400To449YardsAllowed { get; set; }

        [JsonPropertyName("defensive450To499YardsAllowed")]
        public double? Defensive450To499YardsAllowed { get; set; }

        [JsonPropertyName("defensive500To549YardsAllowed")]
        public double? Defensive500To549YardsAllowed { get; set; }

        [JsonPropertyName("defensiveOver550YardsAllowed")]
        public double? DefensiveOver550YardsAllowed { get; set; }

        [JsonPropertyName("passingYards")]
        public double? PassingYards { get; set; }

        [JsonPropertyName("passingTouchdowns")]
        public double? PassingTouchdowns { get; set; }

        [JsonPropertyName("passing2PtConversions")]
        public double? Passing2PtConversions { get; set; }

        [JsonPropertyName("passingInterceptions")]
        public double? PassingInterceptions { get; set; }
    }
}