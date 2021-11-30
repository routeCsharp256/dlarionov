using System.Collections.Concurrent;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Infrastructure.Interfaces;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Infrastructure
{
    public class ChangeTracker : IChangeTracker
    {
        public IDictionary<int, Entity> TrackedEntities => _usedEntitiesBackingField;

        // Можно заменить на любую другую имплементацию. Не только через ConcurrentBag
        private readonly ConcurrentDictionary<int, Entity> _usedEntitiesBackingField;

        public ChangeTracker()
        {
            _usedEntitiesBackingField = new ConcurrentDictionary<int, Entity>();
        }
        
        public void Track(Entity entity)
        {
            _usedEntitiesBackingField.TryAdd(entity.GetHashCode(), entity);
        }
    }
}