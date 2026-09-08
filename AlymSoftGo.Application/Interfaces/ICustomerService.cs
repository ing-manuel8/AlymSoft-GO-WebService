using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.DTOs.Customer;

namespace AlymSoftGo.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<RepositoryResponse<List<CustomerDto>>> GetCustomersAsync(string? search = null);
        Task<RepositoryResponse<CustomerDto>> GetCustomerByIdAsync(int customerId);
        Task<RepositoryResponse<EmptyDto>> SaveCustomerAsync(SaveCustomerRequestDto request);
        Task<RepositoryResponse<EmptyDto>> DeleteCustomerAsync(int customerId);
    }
}
