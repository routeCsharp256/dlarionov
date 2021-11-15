using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.CreateMerchReceiptApplication
{
    public class CreateMerchReceiptApplicationCommand : IRequest<int>
    {
        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string EmployeeName { get; init; }

        /// <summary>
        /// Эл. почта сотрудника
        /// </summary>
        public string EmployeeEmail { get; init; }

        /// <summary>
        /// Тип набора мерча
        /// </summary>
        public int MerchPack { get; init; }

        /// <summary>
        /// Размер одежды
        /// </summary>
        public int ClothingSize { get; init; }
    }
}