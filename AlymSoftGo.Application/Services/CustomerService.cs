using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.DTOs.Customer;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Domain.Interfaces.Services;
using AlymSoftGo.Domain.Params.Customer;

namespace AlymSoftGo.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserContextService _userContext;

        public CustomerService(ICustomerRepository customerRepository, IUserContextService userContext)
        {
            _customerRepository = customerRepository;
            _userContext = userContext;
        }

        public async Task<RepositoryResponse<List<CustomerDto>>> GetCustomersAsync(string? search = null)
        {
            var @params = new GetCustomersParams
            {
                CompanyId = _userContext.GetCompanyId(),
                Search = string.IsNullOrWhiteSpace(search) ? null : search.Trim()
            };

            var data = await _customerRepository.GetByCompanyAsync<List<CustomerDto>>(@params);
            return RepositoryResponse<List<CustomerDto>>.FromSuccess(data);
        }

        public async Task<RepositoryResponse<CustomerDto>> GetCustomerByIdAsync(int customerId)
        {
            var @params = new GetCustomerByIdParams
            {
                CustomerId = customerId,
                CompanyId = _userContext.GetCompanyId()
            };

            var data = await _customerRepository.GetByIdAsync<CustomerDto>(@params);
            return RepositoryResponse<CustomerDto>.FromSuccess(data);
        }

        public async Task<RepositoryResponse<EmptyDto>> SaveCustomerAsync(SaveCustomerRequestDto request)
        {
            var @params = new SaveCustomerParams
            {
                CustomerId = request.CustomerId,
                CompanyId = _userContext.GetCompanyId(),
                FullName = request.FullName.Trim(),
                Phone = request.Phone.Trim(),
                Email = string.IsNullOrWhiteSpace(request.Email) ? null : request.Email.Trim(),
                DefaultAddress = string.IsNullOrWhiteSpace(request.DefaultAddress) ? null : request.DefaultAddress.Trim(),
                Notes = string.IsNullOrWhiteSpace(request.Notes) ? null : request.Notes.Trim(),
                User = _userContext.GetUserIdentifier()
            };

            var result = await _customerRepository.SaveAsync(@params);
            return RepositoryResponse<EmptyDto>.FromSuccess(result);
        }

        public async Task<RepositoryResponse<EmptyDto>> DeleteCustomerAsync(int customerId)
        {
            var @params = new DeleteCustomerParams
            {
                CustomerId = customerId,
                CompanyId = _userContext.GetCompanyId(),
                User = _userContext.GetUserIdentifier()
            };

            var result = await _customerRepository.DeleteAsync(@params);
            return RepositoryResponse<EmptyDto>.FromSuccess(result);
        }
    }
}
