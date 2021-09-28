using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grx_blazor_server.Services.Leagues
{
    public interface ILeagueAdminDeterminer
    {
        Task<bool> IsUserLeagueAdmin(Guid leagueUid);
    }
}
