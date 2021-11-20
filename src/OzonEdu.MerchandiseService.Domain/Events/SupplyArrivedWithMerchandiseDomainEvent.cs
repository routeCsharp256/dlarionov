using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    /// <summary>
    /// Пришла поставка с новыми товарами
    /// </summary>
    public class SupplyArrivedWithMerchandiseDomainEvent : INotification
    {
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public Sku StockItemSku { get; }

        /// <summary>
        /// Количество экземпляров
        /// </summary>
        public Quantity Quantity { get; }

        public SupplyArrivedWithMerchandiseDomainEvent(Sku stockItemSku, Quantity quantity)
        {
            StockItemSku = stockItemSku;
            Quantity = quantity;
        }
    }
}