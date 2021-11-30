using MediatR;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.CreateMerchReceiptApplication
{
    public class CreateMerchReceiptApplicationCommand : IRequest<long>
    {
        /// <summary>
        /// Эл. почта сотрудника
        /// </summary>
        public string EmployeeEmail { get; init; }

        /// <summary>
        /// Фио сотрудника
        /// </summary>
        public string EmployeeName { get; init; }

        /// <summary>
        /// Идентификатор набора мерча
        /// </summary>
        public int MerchPack { get; init; }

        /// <summary>
        /// Размер одежды
        /// </summary>
        public string ClothingSize  { get; init; }
    }
}