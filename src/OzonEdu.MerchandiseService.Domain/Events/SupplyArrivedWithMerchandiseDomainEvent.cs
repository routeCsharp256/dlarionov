using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    /// <summary>
    /// Пришла поставка с новыми товарами
    /// </summary>
    public class SupplyArrivedWithMerchandiseDomainEvent : INotification
    {
        public Sku StockItemSku { get; }
        public Quantity Quantity { get; }

        public SupplyArrivedWithMerchandiseDomainEvent(Sku stockItemSku, Quantity quantity)
        {
            StockItemSku = stockItemSku;
            Quantity = quantity;
        }
    }
}