using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee : Entity
    {
        public Employee(Email email, ClothingSize? clothingSize, string name)
        {
            Email = email;
            ClothingSize = clothingSize;
            Name = name;
        }

        /// <summary>
        /// Почта сотрудника
        /// </summary>
        public Email Email { get; }
        
        /// <summary>
        /// Размер одежды, которую носит сотрудник
        /// </summary>
        public ClothingSize? ClothingSize { get; private set; }
        
        /// <summary>
        /// Фио сотрудника
        /// </summary>
        public string Name { get; }

        public static Employee Create(Email email, ClothingSize? clothingSize, string name)
        {
            var newEmployee = new Employee(email, clothingSize, name);

            return newEmployee;
        }

        public void SetClothingSize(ClothingSize size)
        {
            ClothingSize = size;
        }
    }
}
