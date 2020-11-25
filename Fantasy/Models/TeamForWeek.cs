using Fantasy.Models.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy.Models
{
    public class TeamForWeek
    {
        public Team Team { get; set; }
        public int OpposingTeamId { get; set; }
        public double Score { get; set; }
        public List<BoxscorePlayer> Lineup { get; set; }
    }

}
