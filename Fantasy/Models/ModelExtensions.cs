using System;
using System.Collections.Generic;
using System.Linq;
using Fantasy.Utilities;
using static MoreLinq.Extensions.MaxByExtension;
using static MoreLinq.Extensions.MinByExtension;

namespace Fantasy.Models
{
    /// <summary>
    /// Assumes the base list is a complete collection of all teams that played in a given week
    /// </summary>
    public static class ModelExtensions
    {
        public static TeamForWeek FindById(this IEnumerable<TeamForWeek> teams, int id)
        {
            // If we can't find a team assume that what we're looking up is a BYE week stand-in
            var team = teams.SingleOrDefault(x => x.Team.Id == id);
            return team ?? new TeamForWeek { Team = new ApiResponses.Team { Name = "BYE", _retrievedLogo = "/img/fantasy-logo.png" } };
        }

        public static IList<(TeamForWeek Team1, TeamForWeek Team2)> CreateBoxScores(this IEnumerable<TeamForWeek> teams)
        {
            var result = new List<(TeamForWeek Team1, TeamForWeek Team2)>();
            foreach (var team in teams)
            {
                if (!result.Any(x => x.Team1.Team.Id == team.Team.Id || x.Team2.Team.Id == team.Team.Id))
                {
                    var opposingTeam = teams.FindById(team.OpposingTeamId);
                    result.Add((Team1: team, Team2: opposingTeam));
                }
            }

            return result;
        }

        public static IEnumerable<TeamForWeek> GetWinningTeams(this IEnumerable<TeamForWeek> teams)
        {
            return teams.Where(x => x.Score > teams.Single(y => y.Team.Id == x.OpposingTeamId).Score);
        }

        public static IEnumerable<TeamForWeek> GetLosingTeams(this IEnumerable<TeamForWeek> teams)
        {
            return teams.Where(x => x.Score < teams.FindById(x.OpposingTeamId).Score);
        }

        public static IEnumerable<TeamForWeek> GetHighestScoring(this IEnumerable<TeamForWeek> teams)
        {
            return teams.MaxBy(x => x.Score);
        }

        /// <summary>
        /// The team (or teams if tied) with the highest points scored in defeat
        /// </summary>
        public static IEnumerable<TeamForWeek> GetUnluckiestLoss(this IEnumerable<TeamForWeek> teams)
        {
            var losingTeams = teams.GetLosingTeams();
            return losingTeams.MaxBy(x => x.Score);
        }

        public static IEnumerable<TeamForWeek> GetDominantVictory(this IEnumerable<TeamForWeek> teams)
        {
            return teams.MaxBy(x => x.Score - teams.FindById(x.OpposingTeamId).Score);
        }

        public static IEnumerable<TeamForWeek> GetNarrowestLoss(this IEnumerable<TeamForWeek> teams)
        {
            return teams.GetLosingTeams().MinBy(x => teams.FindById(x.OpposingTeamId).Score - x.Score);
        }

        /// <summary>
        /// The margin of victory or defeat for a team vs their opponent. Negative numbers represent a defeat.
        /// </summary>
        public static double GetMarginalScoreForTeam(this IEnumerable<TeamForWeek> teams, int teamId)
        {
            var team = teams.FindById(teamId);
            return team.Score - teams.FindById(team.OpposingTeamId).Score;
        }

        /// <summary>
        /// Return the top scoring player who is eligible to start in the position <paramref name="playerPosition"/>
        /// and we started in one of the positions listed in <paramref name="startingPositions"/>.
        /// </summary>
        /// <remarks>
        /// Requiring both parameters allows us to differentiate players of different positions when they're started in
        /// a FLEX sport. It also allows us to handle uncommon situations where players are eligible for more than 1 
        /// primary position (e.g. Taysom Hill in 2020 was eligible as both QB and TE)
        /// </remarks>
        public static IEnumerable<PlayerForWeek> GetTopScoringPlayer(this IEnumerable<TeamForWeek> teams, PositionType playerPosition, IEnumerable<PositionType> startingPositions)
        {

            var highestScore = teams.Max(x => x.Lineup.Where(y => startingPositions.Select(y => y.Value).Contains(y.Position)
                                                               && y.Player.EligiblePositions.Contains(playerPosition.Value))
                                                      .Max(y => y.TotalPoints));

            return teams.SelectMany(x => x.Lineup
                                          .Where(y => startingPositions.Select(y => y.Value).Contains(y.Position) && y.TotalPoints == highestScore)
                                          .Select(y => new PlayerForWeek { FantasyTeam = x.Team, BoxScore = y }));

        }

        public static IEnumerable<PlayerForWeek> GetTopScoringQB(this IEnumerable<TeamForWeek> teams)
        {
            return teams.GetTopScoringPlayer(PositionType.QB, new[] { PositionType.QB, PositionType.TQB });
        }

        public static IEnumerable<PlayerForWeek> GetTopScoringRB(this IEnumerable<TeamForWeek> teams)
        {
            return teams.GetTopScoringPlayer(PositionType.RB, new[] { PositionType.RB, PositionType.RBWR, PositionType.RBWRTE });
        }

        public static IEnumerable<PlayerForWeek> GetTopScoringWR(this IEnumerable<TeamForWeek> teams)
        {
            return teams.GetTopScoringPlayer(PositionType.WR, new[] { PositionType.WR, PositionType.RBWR, PositionType.RBWRTE });
        }

        public static IEnumerable<PlayerForWeek> GetTopScoringTE(this IEnumerable<TeamForWeek> teams)
        {
            return teams.GetTopScoringPlayer(PositionType.TE, new[] { PositionType.TE, PositionType.WRTE, PositionType.RBWRTE });
        }

        public static IEnumerable<PlayerForWeek> GetTopScoringDST(this IEnumerable<TeamForWeek> teams)
        {
            return teams.GetTopScoringPlayer(PositionType.DST, new[] { PositionType.DST });
        }

        public static IEnumerable<PlayerForWeek> GetTopScoringK(this IEnumerable<TeamForWeek> teams)
        {
            return teams.GetTopScoringPlayer(PositionType.K, new[] { PositionType.K });
        }

        public static IEnumerable<PlayerForWeek> GetTopScoringBenchPlayer(this IEnumerable<TeamForWeek> teams)
        {
            return teams.GetTopScoringPlayer(PositionType.Bench, new[] { PositionType.Bench });
        }

        public static IEnumerable<PlayerForWeek> GetZeroPointStarters(this IEnumerable<TeamForWeek> teams)
        {
            return teams.SelectMany(x => x.Lineup
                                          .Where(y => (y.Position != PositionType.Bench.Value && y.Position != PositionType.IR.Value)
                                                   && y.TotalPoints <= 0)
                                          .Select(y => new PlayerForWeek { FantasyTeam = x.Team, BoxScore = y }));
        }
    }
}
