using Fantasy.Models.ApiResponses;
using System.Collections.Generic;

namespace Fantasy.Models
{
    public class TeamForWeek
    {
        public Team Team { get; set; }
        public int OpposingTeamId { get; set; }
        public double Score { get; set; }
        public List<BoxscorePlayer> Lineup { get; set; }

        public TeamForWeek()
        {
            Lineup = new List<BoxscorePlayer>();
        }
    }
}