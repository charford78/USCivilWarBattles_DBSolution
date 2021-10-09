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

        public bool Create(Battle battle)
        {
            if(battle.Id != 0)
            {
                throw new Exception("You must enter 0 for Id!");
            }
            _context.Battles.Add(battle);
            var rowsAffected = _context.SaveChanges(); 
            if(rowsAffected != 1)
            {
                throw new Exception("Create failed!");
            }
            return true;
        }

        public bool Change(int Id, Battle battle)
        {
            if(Id != battle.Id)
            {
                throw new Exception("Id's do not match");
            }
            _context.Entry(battle).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected != 1)
            {
                throw new Exception("Update failed!");
            }
            return true;
        }

        public bool Remove(int Id)
        {
            var battle = _context.Battles.Find(Id);
            if(battle == null)
            {
                return false;
            }
            _context.Battles.Remove(battle);
            _context.SaveChanges();
            return true;
        }
    }
}
