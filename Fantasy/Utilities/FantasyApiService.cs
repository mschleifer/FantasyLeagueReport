using Fantasy.Models;
using Fantasy.Models.ApiResponses;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fantasy.Utilities
{
    public class FantasyApiService
    {
        private readonly HttpClient _httpClient;
        private SimpleAppState _appState;

        public FantasyApiService(HttpClient httpClient, SimpleAppState appState)
        {
            this._httpClient = httpClient;
            this._appState = appState;
        }

        // TODO: New api call to get all matchup scores for entire season (to replace calling each week separately)
        // This will require creating a azure function and modifying the underlying espn api NPM package with a function
        // that calls https://fantasy.espn.com/apis/v3/games/ffl/seasons/2020/segments/0/leagues/<leagueId>?view=mMatchupScore

        public async Task<Dictionary<int, List<TeamForWeek>>> GetAllWeeksForSeason(int seasonId)
        {
            for(int i = 1; i < 17; i++)
            {
                if(!_appState.SeasonWeeksDictionary.ContainsKey(i))
                {
                    _appState.SetAllTeamsForWeek(await GetAllTeamsForWeek(seasonId, i), i);
                }
            }

            return _appState.SeasonWeeksDictionary;
        }

        public async Task<List<TeamForWeek>> GetAllTeamsForWeek(int seasonId, int weekId)
        {
            if (_appState.SeasonWeeksDictionary.TryGetValue(weekId, out var week))
            {
                return week;
            }

            var scores = await _httpClient.GetFromJsonAsync<List<Boxscore>>($"/api/boxscore/551600/{seasonId}/{weekId}");
            var teams = await _httpClient.GetFromJsonAsync<List<Team>>($"/api/teams/551600/{seasonId}/{weekId}");

            var result = new List<TeamForWeek>();
            foreach (var score in scores)
            {
                var homeTeamForWeek = new TeamForWeek
                {
                    Team = teams.Single(x => x.Id == score.HomeTeamId),
                    OpposingTeamId = score.AwayTeamId,
                    Score = score.HomeScore,
                    Lineup = score.HomeRoster
                };

                result.Add(homeTeamForWeek);

                var awayTeam = teams.SingleOrDefault(x => x.Id == score.AwayTeamId);
                if (awayTeam != null)
                {
                    var awayTeamForWeek = new TeamForWeek
                    {
                        Team = awayTeam,
                        OpposingTeamId = score.HomeTeamId,
                        Score = score.AwayScore,
                        Lineup = score.AwayRoster
                    };

                    result.Add(awayTeamForWeek);
                }
            }

            _appState.SetAllTeamsForWeek(result, weekId);

            return _appState.SeasonWeeksDictionary[weekId];
        }

        public async Task<int> GetCurrentWeek()
        {
            if (_appState.CurrentNFLSeasonWeek.HasValue)
            {
                return _appState.CurrentNFLSeasonWeek.Value;
            }

            var response = await _httpClient.GetAsync($"https://fantasy.espn.com/apis/v3/games/ffl/seasons/2020?view=kona_game_state");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                // Could throw an exception or just provide a reasonable default
                _appState.SetCurrentNFLSeasonWeek(1);
                return _appState.CurrentNFLSeasonWeek.Value;
            }

            using JsonDocument document = JsonDocument.Parse(content);
            JsonElement root = document.RootElement;
            JsonElement jsonElement = root.GetProperty("currentScoringPeriod").GetProperty("id");
            var week = jsonElement.GetInt32();
            _appState.SetCurrentNFLSeasonWeek(week);

            return _appState.CurrentNFLSeasonWeek.Value;
        }
    }

}
