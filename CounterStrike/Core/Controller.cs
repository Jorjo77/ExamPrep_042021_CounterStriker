using CounterStrike.Core.Contracts;
using CounterStrike.Models;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using System;
using System.Linq;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;

        public Controller()
        {
            guns = new GunRepository();
            players = new PlayerRepository();
            map = new Map();
        }
        public string AddGun(string type, string name, int bulletsCount)
        {
            string message = string.Empty;

            if (type == "Pistol")
            {
                var gun = new Pistol(name, bulletsCount);
                guns.Add(gun);
                return message = $"Successfully added gun {gun.Name}.";
            }
            else if (type == "Rifle")
            {
                var gun = new Rifle(name, bulletsCount);
                guns.Add(gun);
                return message = $"Successfully added gun {gun.Name}.";
            }
            else
            {
                throw new ArgumentException("Invalid gun type.");
            }
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {

            string message = string.Empty;

            if (type == "Terrorist")
            {
                IGun gun = guns.FindByName(gunName);
                if (gun == null)
                {
                    throw new ArgumentException("Gun cannot be found!");
                }
                else
                {
                    var player = new Terrorist(username, health, armor, gun);
                    players.Add(player);
                    return message = $"Successfully added player {player.Username}.";
                }

            }
            else if (type == "CounterTerrorist")
            {
                IGun gun = guns.FindByName(gunName);
                if (gun == null)
                {
                    throw new ArgumentException("Gun cannot be found!");
                }
                else
                {
                    var player = new CounterTerrorist(username, health, armor, gun);
                    players.Add(player);
                    return message = $"Successfully added player {player.Username}.";
                }
            }
            else
            {
                throw new ArgumentException("Invalid player type!");
            }
        }

        public string Report()
        {
            throw new System.NotImplementedException();
        }

        public string StartGame()
        {
            //Functionality 
            //    Game starts with all players that are alive! Returns the result from the Start() method.
        }
    }
}
