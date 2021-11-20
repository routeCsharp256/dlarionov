using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptRequestAggregate
{
    /// <summary>
    /// Заявка на бронирование мерча для выдачи
    /// </summary>
    public class MerchReceiptRequest : Entity
    {
        public MerchReceiptRequest(
            RequestNumber requestNumber,
            RequestStatus requestStatus,
            IReadOnlyList<Sku> skuCollection)
        {
            RequestNumber = requestNumber;
            RequestStatus = requestStatus;
            SkuCollection = skuCollection;
        }

        /// <summary>
        /// Номер заявки
        /// </summary>
        public RequestNumber RequestNumber { get; private set; }

        /// <summary>
        /// Статус заявки
        /// </summary>
        public RequestStatus RequestStatus { get; private set; }

        /// <summary>
        /// Идентификаторы позиций в заявке
        /// </summary>
        public IReadOnlyList<Sku> SkuCollection { get; }

        public void SetRequestNumber(RequestNumber number)
        {
            RequestNumber = number;
        }

        /// <summary>
        /// Смена статуса у заявки на  склада
        /// </summary>
        /// <param name="status"></param>
        /// <exception cref="Exception"></exception>
        public void ChangeStatus(RequestStatus status)
        {
            RequestStatus = status;
        }
    }
}