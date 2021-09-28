using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace grx_blazor_server.Models
{
    public class LeagueNight
    {
        #region Properties
        [Key]
        public Guid LeagueNightUid { get; set; }
        [Required]
        public DayOfWeek DayOfWeek { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
        [Required]
        public string Location { get; set; }
        [ForeignKey("League")]
        public Guid LeagueUid { get; set; }
        public League League { get; set; }
        #endregion
    }
}
