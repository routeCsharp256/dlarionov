using System;
using System.Collections.Generic;
using System.Linq;
using OzonEdu.MerchandiseService.Domain.Events.MerchReceiptApplicationAggregate;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate
{
    /// <summary>
    /// Набор выдаваемого мерча
    /// </summary>
    public class MerchPack : Entity
    {
        public MerchPack(string name, IReadOnlyCollection<Merch> merchCollection)
        {
            Name = name;
            MerchCollection = merchCollection.ToList();
        }

        public string Name { get; private set; }
        public IReadOnlyCollection<Merch> MerchCollection { get; private set; }

        public MerchPack Create(string name, IReadOnlyCollection<Merch> merchCollection)
        {
            if (merchCollection.Count == 0)
            {
                throw new ArgumentException($"{nameof(merchCollection)} is empty");
            }

            var newMerchPack = new MerchPack(name, merchCollection);

            return newMerchPack;
        }

        /// <summary>
        /// Изменить комплектацию набора
        /// </summary>
        /// <param name="merchCollection"></param>
        public void ChangeMerchCollection(IReadOnlyCollection<Merch> merchCollection)
        {
            if (merchCollection.Count == 0)
            {
                throw new ArgumentException($"{nameof(merchCollection)} is empty");
            }

            MerchCollection = merchCollection;
            ChangeMerchCollectionDomainEvent(this.Id);
        }

        /// <summary>
        /// Изменение комплектации набора
        /// </summary>
        /// <param name="merchPackId"></param>
        private void ChangeMerchCollectionDomainEvent(int merchPackId)
        {
            var orderStartedDomainEvent = new MerchPackMerchCollectionChanged(merchPackId);
            AddDomainEvent(orderStartedDomainEvent);
        }
    }
}
