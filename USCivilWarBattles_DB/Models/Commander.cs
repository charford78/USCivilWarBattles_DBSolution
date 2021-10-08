using System;
using System.Collections.Generic;

#nullable disable

namespace USCivilWarBattles_DB.Models
{
    public partial class Commander
    {
        public int Id { get; set; }
        public string Commander1 { get; set; }
        public string Army { get; set; }
        public int BattleId { get; set; }

        public virtual Battle Battle { get; set; }
    }
}
