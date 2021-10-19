using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCivilWarBattles_DB.Models;

namespace USCivilWarBattles_DB.Controllers
{
    class CommandersController
    {
        private readonly USCivilWarBattlesContext _context;

        public CommandersController()
        {
            _context = new USCivilWarBattlesContext();
        }

        public List<Commander> GetAll()
        {
            return _context.Commanders.ToList();
        }

        public Commander GetbyPk(int id)
        {
            return _context.Commanders.Find(id);
        }

        public bool Create(Commander commander)
        {
            if(commander.Id != 0)
            {
                throw new Exception("You must enter 0 for Id!");
            }
            _context.Commanders.Add(commander);
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected != 1)
            {
                throw new Exception("Create failed!");
            }
            return true;
        }

        public bool Change(int id, Commander commander)
        {
            if(id != commander.Id)
            {
                throw new Exception("Id's do not match!");
            }
            _context.Entry(commander).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected != 1)
            {
                throw new Exception("Update failed!");
            }
            return true;
        }

        public bool Remove(int id)
        {
            var commander = _context.Commanders.Find(id);
            if(commander == null)
            {
                return false;
            }
            _context.Commanders.Remove(commander);
            _context.SaveChanges();
            return true;
        }
    }
}
