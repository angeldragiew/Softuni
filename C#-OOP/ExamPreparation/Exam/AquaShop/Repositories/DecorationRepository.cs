using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using AquaShop.Models.Decorations.Contracts;
using System.Linq;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> models;

        public DecorationRepository()
        {
            models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => models.AsReadOnly();

        public void Add(IDecoration model)
        {
            models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            IDecoration decoration = models.FirstOrDefault(d => d.GetType().Name == type);
            return decoration;
        }

        public bool Remove(IDecoration model)
        {
            return models.Remove(model);
        }
    }
}
