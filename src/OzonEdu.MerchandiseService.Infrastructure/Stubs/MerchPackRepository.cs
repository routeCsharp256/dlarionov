using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;

namespace OzonEdu.MerchandiseService.Infrastructure.Stubs
{
    public class MerchPackRepository : IMerchPackRepository
    {
        public async Task<MerchPack> FindById(int id, CancellationToken cancellationToken)
        {
            var merchPen = new Merch(Sku.Create(123), "pen", MerchType.Stationery);
            var merchPack = new MerchPack($"merch_pack_{id}", new List<Merch>() { merchPen });
            return merchPack;
        }

        public async Task<IReadOnlyCollection<MerchPack>> FindByIds(IReadOnlyCollection<int> id, CancellationToken cancellationToken)
        {
            var merchPen = new Merch(Sku.Create(123), "pen", MerchType.Stationery);
            var merchPacks = new List<MerchPack>();
            foreach (var currentId in id)
            {
                merchPacks.Add(new MerchPack($"merch_pack_{currentId}", new List<Merch>() { merchPen }));
            }
            return merchPacks;
        }

        public async Task<IReadOnlyCollection<MerchPack>> GetAll(CancellationToken cancellationToken)
        {
            var merchPen = new Merch(Sku.Create(123), "pen", MerchType.Stationery);
            var merchPacks = new List<MerchPack>();
            for(int i = 0; i < 100; i++)
            {
                merchPacks.Add(new MerchPack($"merch_pack_{i}", new List<Merch>() { merchPen }));
            }
            return merchPacks;
        }

        public async Task<MerchPack> Create(MerchPack merchPackToCreate, CancellationToken cancellationToken)
        {
            return merchPackToCreate;
        }

        public async Task<MerchPack> Update(MerchPack merchPackToUpdate, CancellationToken cancellationToken)
        {
            return merchPackToUpdate;
        }
    }
}