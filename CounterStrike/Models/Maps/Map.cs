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
            //Separates the players in two types -Terrorist and Counter Terrorist. The game continues until one of the teams is
            //completely dead (all players have 0 health). The terrorists attack first and after that the counter terrorists. The
            //attack happens like that: Each terrorist(if he is alive) shoots on each counter terrorist once and inflicts damage
            //equal to the bullets fired and after that each counter terrorist(if he is alive) shoots on each terrorist.
            //Return a string that says which of the teams won:
            // &quot; Counter Terrorist wins! & quot;
            // &quot; Terrorist wins!&quot;

            var terrorists = players.Where(p => p.GetType().Name == "Terrorist");
            var counterTerrorists = players.Where(p => p.GetType().Name == "CounterTerrorist");

            while (terrorists.Sum(t => t.Health) > 0 || counterTerrorists.Sum(t => t.Health) > 0)
            {
                foreach (var terrorist in terrorists)
                {
                    if (terrorist.IsAlive)
                    {
                        foreach (var CounterTerrorist in counterTerrorists)
                        {
                            terrorist.TakeDamage()
                        }
                    }
                }
            }
        }
    }
}
