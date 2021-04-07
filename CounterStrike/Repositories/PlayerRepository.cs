using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> models;

        public PlayerRepository()
        {
            models = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => this.models.AsReadOnly();

        public void Add(IPlayer model)
        {

            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Player Repository");
            }
            models.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            var searchedGun = this.models.FirstOrDefault(m => m.Username == name);
            if (searchedGun == null)
            {
                return null;
            }
            return searchedGun;
        }

        public bool Remove(IPlayer model)
        {
            if (!this.models.Contains(model))
            {
                return false;
            }
            this.models.Remove(model);
            return true;
        }
    }
}
