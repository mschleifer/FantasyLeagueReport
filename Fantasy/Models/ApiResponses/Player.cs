using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Fantasy.Models.ApiResponses
{
    public class Player
    {
        [JsonPropertyName("seasonId")]
        public int SeasonId { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("jerseyNumber")]
        public object JerseyNumber { get; set; }

        [JsonPropertyName("proTeam")]
        public string ProTeam { get; set; }

        [JsonPropertyName("proTeamAbbreviation")]
        public string ProTeamAbbreviation { get; set; }

        [JsonPropertyName("defaultPosition")]
        public string DefaultPosition { get; set; }

        [JsonPropertyName("eligiblePositions")]
        public List<string> EligiblePositions { get; set; }

        [JsonPropertyName("averageDraftPosition")]
        public decimal AverageDraftPosition { get; set; }

        [JsonPropertyName("averageAuctionValue")]
        public decimal AverageAuctionValue { get; set; }

        [JsonPropertyName("percentChange")]
        public decimal PercentOwnershipChange { get; set; }

        [JsonPropertyName("percentStarted")]
        public decimal PercentStarted { get; set; }

        [JsonPropertyName("percentOwned")]
        public decimal PercentOwned { get; set; }

        [JsonPropertyName("acquiredDate")]
        public DateTime AcquiredDate { get; set; }

        [JsonPropertyName("availabilityStatus")]
        public string AvailabilityStatus { get; set; }

        [JsonPropertyName("isDroppable")]
        public bool IsDroppable { get; set; }

        [JsonPropertyName("isInjured")]
        public bool IsInjured { get; set; }

        [JsonPropertyName("injuryStatus")]
        public string InjuryStatus { get; set; }
    }
}