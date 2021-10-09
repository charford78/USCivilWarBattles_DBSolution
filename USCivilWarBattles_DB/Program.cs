using System;
using USCivilWarBattles_DB.Controllers;
using USCivilWarBattles_DB.Models;

namespace USCivilWarBattles_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            var batCtrl = new BattlesController();
            
            var richmt = new Battle()
            {
                Id = 0,
                BattleCode = "RICHMT",
                BattleName = "Battle of Rich Mountain",
                Date = "July 11th, 1861",
                Location = "Randolph County, VA (now WV)",
                Theatre = "Eastern",
                Victor = "USA"
            };
            batCtrl.Create(richmt);

            var battles = batCtrl.GetAll();
            foreach (var b in battles)
            {
                Console.WriteLine($"{b.Id} | {b.BattleCode} | {b.BattleName} " +
                    $"| {b.Date} | {b.Location} | {b.Theatre} | {b.Victor}");
            }

            //var battle = batCtrl.GetbyPk(2);
            //if(battle == null)
            //{
            //    Console.WriteLine("Not found!");
            //}
            //Console.WriteLine($"{battle.BattleName} | {battle.Date} | {battle.Location} " +
            //                    $"| {battle.Theatre} | {battle.Victor}");
        }
    }
}
