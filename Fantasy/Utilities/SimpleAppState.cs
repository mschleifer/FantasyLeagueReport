using Fantasy.Models;
using System.Collections.Generic;
using System.Linq;

namespace Fantasy.Utilities
{
    /// <summary>
    /// Using a simple app state class primarily to provide basic caching for API calls
    /// </summary>
    public class SimpleAppState
    {
        public int? CurrentNFLSeasonWeek { get; private set; }

        public Dictionary<int, List<TeamForWeek>> SeasonWeeksDictionary { get; private set; }

        public List<MatchupForWeek> SeasonSummary { get; private set; }

        public SimpleAppState()
        {
            SeasonWeeksDictionary = new Dictionary<int, List<TeamForWeek>>();
        }

        public void SetCurrentNFLSeasonWeek(int week)
        {
            CurrentNFLSeasonWeek = week;
        }

        public List<TeamForWeek> GetAllTeamsForWeek(int week)
        {
            return SeasonWeeksDictionary[week];
        }

        public TeamForWeek GetTeamforWeek(int teamId, int week)
        {
            return SeasonWeeksDictionary[week].SingleOrDefault(x => x.Team.Id == teamId);
        }

        public void SetTeamForWeek(TeamForWeek team, int week)
        {
            if (SeasonWeeksDictionary.ContainsKey(week))
            {
                SeasonWeeksDictionary[week].Add(team);
            }
            else
            {
                SeasonWeeksDictionary[week] = new List<TeamForWeek>() { team };
            }

        }

        public void SetAllTeamsForWeek(List<TeamForWeek> teams, int week)
        {
            SeasonWeeksDictionary[week] = teams;
        }

        public void SetSeasonSummary(List<MatchupForWeek> matchups)
        {
            SeasonSummary = matchups;
        }
    }
}
