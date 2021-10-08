using System;
using System.Collections.Generic;

#nullable disable

namespace USCivilWarBattles_DB.Models
{
    public partial class Battle
    {
        public Battle()
        {
            Commanders = new HashSet<Commander>();
        }

        public int Id { get; set; }
        public string BattleCode { get; set; }
        public string BattleName { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string Theatre { get; set; }
        public string Victor { get; set; }

        public virtual ICollection<Commander> Commanders { get; set; }
    }
}
