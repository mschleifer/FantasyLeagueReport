using Fantasy.Models;
using Fantasy.Models.ApiResponses;
using System;
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

        public async Task<IEnumerable<Team>> GetAllTeams(int seasonId)
        {
            var currentWeek = await GetCurrentWeek();
            return await _httpClient.GetFromJsonAsync<List<Team>>($"/api/teams/551600/{seasonId}/{currentWeek}");
        }

        public async Task<IEnumerable<MatchupForWeek>> GetAllSeasonMatchups(int seasonId)
        {
            if (_appState.SeasonSummary == null)
            {
                var result = new List<MatchupForWeek>();
                var matchups = await _httpClient.GetFromJsonAsync<List<Matchup>>($"/api/season/551600/{seasonId}");
                var teams = await GetAllTeams(seasonId);

                foreach (var matchup in matchups)
                {
                    if (!teams.Any(x => x.Id == matchup.HomeTeamId)) { Console.WriteLine($"No team entry found for home team id {matchup.HomeTeamId} - week {matchup.MatchupPeriodId}"); }
                    if (!teams.Any(x => x.Id == matchup.AwayTeamId)) { Console.WriteLine($"No team entry found for away team id {matchup.AwayTeamId} - week {matchup.MatchupPeriodId}"); }

                    var detailedMatchup = new MatchupForWeek
                    {
                        MatchupPeriodId = matchup.MatchupPeriodId,
                        HomeTeam = teams.SingleOrDefault(x => x.Id == matchup.HomeTeamId), // Exception
                        AwayTeam = teams.SingleOrDefault(x => x.Id == matchup.AwayTeamId),
                        HomeTeamScore = matchup.HomeScore,
                        AwayTeamScore = matchup.AwayScore
                    };

                    result.Add(detailedMatchup);
                }

                _appState.SetSeasonSummary(result);
            }

            return _appState.SeasonSummary;
        }

        public async Task<IEnumerable<MatchupForWeek>> GetRegularSeasonMatchups(int seasonId)
        {
            return (await GetAllSeasonMatchups(seasonId)).Where(x => x.MatchupPeriodId <= 13);

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
