using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate
{
    public class Employee : Entity
    {
        public Email Email { get; }
        public string Name { get; }

        public Employee(Email email, string name)
        {
            Email = email;
            Name = name;
        }
    }
}
