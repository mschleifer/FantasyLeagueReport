using Fantasy.Models.ApiResponses;
using System.Collections.Generic;

namespace Fantasy.Models
{
    public class MatchupForWeek
    {
        public int MatchupPeriodId { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public double HomeTeamScore { get; set; }
        public double AwayTeamScore { get; set; }
    }
}