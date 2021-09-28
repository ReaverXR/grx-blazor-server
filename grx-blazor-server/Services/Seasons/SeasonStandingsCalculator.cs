using grx_blazor_server.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grx_blazor_server.Services.Seasons
{
    public class SeasonStandingsCalculator : ISeasonStandingsCalculator
    {
        private readonly ApplicationDbContext _context;

        public SeasonStandingsCalculator(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public IOrderedEnumerable<SeasonStanding> CalculateSeasonStandings(Guid seasonUid)
        {
            var season = _context.Seasons
                .Include(s => s.Games)
                .ThenInclude(g => g.GameResults)
                .ThenInclude(gr => gr.Player)
                .First(s => s.SeasonUid == seasonUid);

            if(season.Players == null
                || !season.Players.Any())
            {
                // Lol
                return new List<SeasonStanding>().OrderBy(s => s.Rank);
            }

            List<SeasonStanding> standings = season.Players.Select(p => new SeasonStanding { Player = p }).ToList();
            
            if(season.Games == null
                || !season.Games.Any())
            {
                // Lol
                return standings.OrderBy(s => s.Rank);
            }

            foreach(var game in season.Games)
            {
                var orderedGameResults = game.GameResults.OrderBy(gr => gr.Score).ThenBy(gr => gr.TieBreakerWin);

                foreach (var gameResult in orderedGameResults)
                {
                    var standing = standings.FirstOrDefault(s => s.Player.PlayerUid == gameResult.PlayerUid);

                    if(standing == null)
                    {
                        continue;
                    }

                    // If this is the first result, then this is a win.
                    if(orderedGameResults.First() == orderedGameResults)
                    {
                        standing.Wins++;
                    }

                    standing.Score += gameResult.Score;
                }
            }

            var orderedStandings = standings.OrderBy(s => s.Wins).ThenBy(s => s.Score).ToList();

            // Assign ranks
            short rank = 1;
            foreach(var orderedStanding in orderedStandings)
            {
                if(orderedStanding == orderedStandings.First())
                {
                    orderedStanding.Rank = rank;
                }
                else
                {
                    var orderedStandingIndex = orderedStandings.IndexOf(orderedStanding);
                    var leadingStanding = orderedStandings[orderedStandingIndex - 1];
                    if(orderedStanding.Wins == leadingStanding.Wins
                        && orderedStanding.Score == leadingStanding.Score)
                    {
                        orderedStanding.Rank = leadingStanding.Rank;
                    }
                    else
                    {
                        orderedStanding.Rank = rank;
                    }
                }

                rank++;
            }

            return standings.OrderBy(s => s.Rank).ThenBy(s => s.Player.DisplayName);
        }
    }
}
