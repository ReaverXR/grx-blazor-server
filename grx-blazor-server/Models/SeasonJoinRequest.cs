using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace grx_blazor_server.Models
{
    public class SeasonJoinRequest
    {
        [Key]
        public Guid SeasonJoinRequestUid { get; set; }
        [ForeignKey("Season")]
        public Guid SeasonUid { get; set; }
        public Season Season { get; set; }
        [ForeignKey("User")]
        public Guid PlayerUid { get; set; }
        public Player Player { get; set; }
    }
}
