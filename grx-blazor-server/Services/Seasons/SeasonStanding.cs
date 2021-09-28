using grx_blazor_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grx_blazor_server.Services.Seasons
{
    public class SeasonStanding
    {
        #region Properties
        public short Rank { get; set; }
        public Player Player { get; set; }
        public byte GamesPlayed { get; set; }
        public byte Wins { get; set; }
        public short Score { get; set; }
        #endregion
    }
}
