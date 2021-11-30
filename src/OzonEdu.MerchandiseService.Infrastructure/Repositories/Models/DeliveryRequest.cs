using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Models
{
    public class DeliveryRequest
    {
        public long Id { get; set; }

        public long RequestId { get; set; }

        public int RequestStatus { get; set; }

        //public ICollection<DeliveryRequestSkuMap> DeliveryRequestSkuMaps { get; set; }
    }
}