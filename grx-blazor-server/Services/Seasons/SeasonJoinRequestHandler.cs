using grx_blazor_server.Data;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grx_blazor_server.Services.Seasons
{
    public class SeasonJoinRequestHandler : ISeasonJoinRequestHandler
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public SeasonJoinRequestHandler(
            ApplicationDbContext context,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _context = context;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task JoinSeason(Guid seasonUid)
        {
            // If user is a member of the league, approve the request automatically.

            // Otherwise, create a request to join.
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        }
    }
}
