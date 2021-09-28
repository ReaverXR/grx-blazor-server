using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace grx_blazor_server.Models
{
    public class Season
    {
        #region Properties
        [Key]
        public Guid SeasonUid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime EndDateUtc { get; set; }
        public int MaxGamesPerPlayer { get; set; }
        public List<Game> Games { get; set; }
        public List<Player> Players { get; set; }
        [ForeignKey("League")]
        public Guid LeagueUid { get; set; }
        public League League { get; set; }
        #endregion
    }
}
