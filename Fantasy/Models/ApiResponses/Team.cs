using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Fantasy.Models.ApiResponses
{
    public class Team
    {
        [JsonPropertyName("leagueId")]
        public int LeagueId { get; set; }

        [JsonPropertyName("seasonId")]
        public int SeasonId { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("logoURL")]
        public string _retrievedLogo { get; set; }

        [JsonIgnore]
        public string LogoURL => string.IsNullOrEmpty(_retrievedLogo) ? $"https://placekitten.com/100/100?image={new Random().Next(17)}" : _retrievedLogo;

        [JsonPropertyName("waiverRank")]
        public int WaiverRank { get; set; }

        [JsonPropertyName("roster")]
        public List<Player> Roster { get; set; }

        [JsonPropertyName("wins")]
        public int Wins { get; set; }

        [JsonPropertyName("losses")]
        public int Losses { get; set; }

        [JsonPropertyName("ties")]
        public int Ties { get; set; }

        [JsonPropertyName("divisionWins")]
        public int DivisionWins { get; set; }

        [JsonPropertyName("divisionLosses")]
        public int DivisionLosses { get; set; }

        [JsonPropertyName("divisionTies")]
        public int DivisionTies { get; set; }

        [JsonPropertyName("homeWins")]
        public int HomeWins { get; set; }

        [JsonPropertyName("homeLosses")]
        public int HomeLosses { get; set; }

        [JsonPropertyName("homeTies")]
        public int HomeTies { get; set; }

        [JsonPropertyName("awayWins")]
        public int AwayWins { get; set; }

        [JsonPropertyName("awayLosses")]
        public int AwayLosses { get; set; }

        [JsonPropertyName("awayTies")]
        public int AwayTies { get; set; }

        [JsonPropertyName("totalPointsScored")]
        public double TotalPointsScored { get; set; }

        [JsonPropertyName("regularSeasonPointsFor")]
        public double RegularSeasonPointsFor { get; set; }

        [JsonPropertyName("regularSeasonPointsAgainst")]
        public double RegularSeasonPointsAgainst { get; set; }

        [JsonPropertyName("winningPercentage")]
        public double WinningPercentage { get; set; }

        [JsonPropertyName("playoffSeed")]
        public int PlayoffSeed { get; set; }

        [JsonPropertyName("finalStandingsPosition")]
        public int FinalStandingsPosition { get; set; }
    }
}