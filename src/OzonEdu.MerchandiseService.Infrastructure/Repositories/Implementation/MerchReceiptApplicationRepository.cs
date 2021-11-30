using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Infrastructure.Interfaces;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Implementation
{
    public class MerchReceiptApplicationRepository : IMerchReceiptApplicationRepository
    {
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        private readonly IQueryExecutor _queryExecutor;
        private const int Timeout = 5;

        public MerchReceiptApplicationRepository(IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory, IQueryExecutor queryExecutor)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _queryExecutor = queryExecutor;
        }

        public async Task<IReadOnlyCollection<MerchReceiptApplication>> FindByEmployeeEmail(Email email, CancellationToken cancellationToken)
        {
           throw new NotImplementedException();
        }

        public async Task<MerchReceiptApplication> FindById(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<MerchReceiptApplication>> FindByIds(IReadOnlyList<int> id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<MerchReceiptApplication>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<MerchReceiptApplication> Create(MerchReceiptApplication merchReceiptAppToCreate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<MerchReceiptApplication> Update(MerchReceiptApplication merchReceiptAppToUpdate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}