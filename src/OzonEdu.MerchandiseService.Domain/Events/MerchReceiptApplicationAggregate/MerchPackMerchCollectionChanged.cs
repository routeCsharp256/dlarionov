using MediatR;

namespace OzonEdu.MerchandiseService.Domain.Events.MerchReceiptApplicationAggregate
{
    /// <summary>
    /// Произошло изменение комплектации набора мерча
    /// </summary>
    public class MerchPackMerchCollectionChanged : INotification
    {
        /// <summary>
        /// Идентификатор набора мерча
        /// </summary>
        public int Id { get; }

        public MerchPackMerchCollectionChanged(int id)
        {
            Id = id;
        }
    }
}