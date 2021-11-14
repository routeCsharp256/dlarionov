using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate
{
    public class MerchReceiptApplication : Entity
    {
        public MerchReceiptApplication(ReceiptNumber receiptNumber,
            Employee emloyeeId,
            MerchPack merchPack,
            ClothingSize size,
            ApplicationStatus status,
            Date date)
        {
            ReceiptNumber = receiptNumber;
            EmployeeId = emloyeeId;
            MerchPack = merchPack;
            ClothingSize = size;
            SetApplicationStatus(status);
            Date = date;
        }

        public ReceiptNumber ReceiptNumber { get; }
        public Employee EmployeeId { get; }
        public MerchPack MerchPack { get; }
        public ClothingSize ClothingSize { get; }
        public ApplicationStatus ApplicationStatus { get; private set; }
        public Date Date { get; }

        public void SetApplicationStatus(ApplicationStatus status)
        {
            ApplicationStatus = status;
        }
    }
}
