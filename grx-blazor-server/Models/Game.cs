using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace grx_blazor_server.Models
{
    public class Game
    {
        #region Properties
        [Key]
        public Guid GameUid { get; set; }
        public DateTime Date { get; set; }
        public List<GameResult> GameResults { get; set; }
        [ForeignKey("Season")]
        public Guid SeasonUid { get; set; }
        public Season Season { get; set; }
        #endregion

        public Player GetWinner()
        {
            var tieBreakerWinner = GameResults.SingleOrDefault(gr => gr.TieBreakerWin)?.Player;
            if(tieBreakerWinner != null)
            {
                return tieBreakerWinner;
            }

            return GameResults.OrderByDescending(gr => gr.Score).First().Player;
        }
    }
}
