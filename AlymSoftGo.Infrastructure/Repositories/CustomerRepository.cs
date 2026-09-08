using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Persistence;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Domain.Params.Customer;
using AlymSoftGo.Infrastructure.Repositories.Base;

namespace AlymSoftGo.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository, ICustomerRepository
    {
        public CustomerRepository(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public async Task<TData> GetByCompanyAsync<TData>(GetCustomersParams @params) where TData : class, new()
        {
            return await ResolveSpAsync<TData>(@params);
        }

        public async Task<TData> GetByIdAsync<TData>(GetCustomerByIdParams @params) where TData : class, new()
        {
            return await ResolveSpAsync<TData>(@params);
        }

        public async Task<EmptyDto> SaveAsync(SaveCustomerParams @params)
        {
            return await ResolveSpAsync<EmptyDto>(@params);
        }

        public async Task<EmptyDto> DeleteAsync(DeleteCustomerParams @params)
        {
            return await ResolveSpAsync<EmptyDto>(@params);
        }
    }
}
