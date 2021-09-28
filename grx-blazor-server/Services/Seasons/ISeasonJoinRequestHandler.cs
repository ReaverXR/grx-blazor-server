using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grx_blazor_server.Services.Seasons
{
    public interface ISeasonJoinRequestHandler
    {
        Task JoinSeason(Guid seasonUid);
    }
}
