using Fantasy.Models.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy.Models
{
    public class PlayerForWeek
    {
        public BoxscorePlayer BoxScore { get; set; }
        public Team FantasyTeam { get; set; }
    }
}
