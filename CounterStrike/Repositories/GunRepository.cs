using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> models;

        public GunRepository()
        {
            models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.models.AsReadOnly();

        public void Add(IGun model)
        {

            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Gun Repository");
            }
            models.Add(model);
        }

        public IGun FindByName(string name)
        {
            var searchedGun = this.models.FirstOrDefault(m => m.Name == name);
            if (searchedGun == null)
            {
                return null;
            }
            return searchedGun;
        }

        public bool Remove(IGun model)
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
