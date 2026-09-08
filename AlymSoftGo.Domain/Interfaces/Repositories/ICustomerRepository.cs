using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Params.Customer;

namespace AlymSoftGo.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<TData> GetByCompanyAsync<TData>(GetCustomersParams @params) where TData : class, new();
        Task<TData> GetByIdAsync<TData>(GetCustomerByIdParams @params) where TData : class, new();
        Task<EmptyDto> SaveAsync(SaveCustomerParams @params);
        Task<EmptyDto> DeleteAsync(DeleteCustomerParams @params);
    }
}
