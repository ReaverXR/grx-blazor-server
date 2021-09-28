using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grx_blazor_server.Models
{
    public class LeagueSeason
    {
        #region Properties
        public Guid LeagueUid { get; set; }
        public Guid SeasonUid { get; set; }
        #endregion
    }
}
