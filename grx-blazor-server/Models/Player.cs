using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace grx_blazor_server.Models
{
    public class Player
    {
        #region Properties
        [Key]
        public Guid PlayerUid { get; set; }
        public Guid UserUid { get; set; }
        public string DisplayName { get; set; }
        public ICollection<GameResult> GameResults { get; set; }
        public ICollection<Season> Seasons { get; set; }
        #endregion
    }
}
