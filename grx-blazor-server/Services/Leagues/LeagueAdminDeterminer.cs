using grx_blazor_server.Data;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace grx_blazor_server.Services.Leagues
{
    public class LeagueAdminDeterminer : ILeagueAdminDeterminer
    {
        private ApplicationDbContext _applicationDbContext;
        private AuthenticationStateProvider _authenticationStateProvider;

        public LeagueAdminDeterminer(
            ApplicationDbContext applicationDbContext,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _applicationDbContext = applicationDbContext;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> IsUserLeagueAdmin(Guid leagueUid)
        {
            var league = _applicationDbContext.Leagues.FirstOrDefault(l => l.LeagueUid == leagueUid);

            if(league == null)
            {
                return false;
            }

            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();

            if(!authState.User.Identity.IsAuthenticated)
            {
                return false;
            }

            var userUid = new Guid(authState.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

            return league.OwningUserUid == userUid
                || league.Admins.Select(a => a.UserUid).Contains(userUid);
        }
    }
}
