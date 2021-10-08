using System;
using USCivilWarBattles_DB.Controllers;

namespace USCivilWarBattles_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            var batCtrl = new BattlesController();
            var battles = batCtrl.GetAll();

            foreach(var b in battles)
            {
                Console.WriteLine($"{b.Id} | {b.BattleCode} | {b.BattleName} " +
                    $"| {b.Date} | {b.Location} | {b.Theatre} | {b.Victor}");
            }
        }
    }
}
