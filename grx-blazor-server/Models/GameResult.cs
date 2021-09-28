using grx_blazor_server.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace grx_blazor_server.Models
{
    public class GameResult
    {
        #region Properties
        [Key]
        public Guid GameResultUid { get; set; }
        [ForeignKey("Player")]
        public Guid PlayerUid { get; set; }
        public Player Player { get; set; }
        public short Score { get; set; }
        public Faction Faction { get; set; }
        public bool TieBreakerWin { get; set; }
        [ForeignKey("Game")]
        public Guid GameUid { get; set; }
        public Game Game { get; set; }
        #endregion
    }
}
