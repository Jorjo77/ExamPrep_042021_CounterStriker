using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {

            string message = string.Empty;
            IList<IPlayer> terrorists = players.Where(p => p.GetType().Name == "Terrorist").ToList();
            IList<IPlayer> counterTerrorists = players.Where(p => p.GetType().Name == "CounterTerrorist").ToList();

            while (terrorists.Sum(t => t.Health) > 0 || counterTerrorists.Sum(t => t.Health) > 0)
            {
                foreach (var terrorist in terrorists)
                {
                    if (terrorist.IsAlive)
                    {
                        foreach (var CounterTerrorist in counterTerrorists)
                        {
                            terrorist.Gun.Fire();
                        }
                    }
                }
                foreach (var counterTerrorist in counterTerrorists)
                {
                    if (counterTerrorist.IsAlive)
                    {
                        foreach (var CounterTerrorist in counterTerrorists)
                        {
                            counterTerrorist.Gun.Fire();
                        }
                    }
                }
            }
            if (terrorists.Sum(t => t.Health) == 0)
            {
                return message = "Counter Terrorist wins!";
            }
            else 
            {
                return message = "Terrorist wins!";
            }
        }
    }
}
