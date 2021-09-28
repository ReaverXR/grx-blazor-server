using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace grx_blazor_server.Models
{
    public class League
    {
        #region Properties
        [Key]
        public Guid LeagueUid { get; set; }
        public Guid OwningUserUid { get; set; }
        public ICollection<Player> Admins { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Name must be under 25 characters.", MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<Season> Seasons { get; set; }
        public ICollection<LeagueNight> LeagueNights { get; set; }
        #endregion
    }
}
