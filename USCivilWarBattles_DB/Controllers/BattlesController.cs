using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCivilWarBattles_DB.Models;

namespace USCivilWarBattles_DB.Controllers
{
    class BattlesController
    {
        private readonly USCivilWarBattlesContext _context;

        public BattlesController()
        {
            _context = new USCivilWarBattlesContext();
        }

        public List<Battle> GetAll()
        {
            return _context.Battles.ToList();
        }
        public Battle GetbyPk(int id)
        {
            return _context.Battles.Find(id);
        }
    }
}
