using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.DTOs.Branch;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Domain.Interfaces.Services;
using AlymSoftGo.Domain.Params.Branch;

namespace AlymSoftGo.Application.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IUserContextService _userContext;

        public BranchService(IBranchRepository branchRepository, IUserContextService userContext)
        {
            _branchRepository = branchRepository;
            _userContext = userContext;
        }

        public async Task<RepositoryResponse<List<BranchDto>>> GetBranchesAsync()
        {
            var @params = new GetBranchesParams
            {
                CompanyId = _userContext.GetCompanyId()
            };

            var data = await _branchRepository.GetBranchesByCompanyAsync<List<BranchDto>>(@params);
            return RepositoryResponse<List<BranchDto>>.FromSuccess(data);
        }

        public async Task<RepositoryResponse<BranchDto>> GetBranchByIdAsync(int branchId)
        {
            var @params = new GetBranchByIdParams
            {
                BranchId = branchId,
                CompanyId = _userContext.GetCompanyId()
            };

            var data = await _branchRepository.GetBranchByIdAsync<BranchDto>(@params);
            return RepositoryResponse<BranchDto>.FromSuccess(data);
        }

        public async Task<RepositoryResponse<List<BranchUserDto>>> GetAssignableUsersAsync()
        {
            var @params = new GetBranchUsersParams
            {
                CompanyId = _userContext.GetCompanyId()
            };

            var data = await _branchRepository.GetAssignableUsersAsync(@params);
            return RepositoryResponse<List<BranchUserDto>>.FromSuccess(data);
        }

        public async Task<RepositoryResponse<EmptyDto>> SaveBranchAsync(SaveBranchRequestDto request)
        {
            var @params = new SaveBranchParams
            {
                BranchId = request.Id,
                CompanyId = _userContext.GetCompanyId(),
                Name = request.Name.Trim(),
                Address = string.IsNullOrWhiteSpace(request.Address) ? null : request.Address.Trim(),
                Phone = string.IsNullOrWhiteSpace(request.Phone) ? null : request.Phone.Trim(),
                ContactEmail = string.IsNullOrWhiteSpace(request.ContactEmail) ? null : request.ContactEmail.Trim(),
                OperatingHours = string.IsNullOrWhiteSpace(request.OperatingHours) ? null : request.OperatingHours.Trim(),
                AllowsDelivery = request.AllowsDelivery,
                AllowsPickup = request.AllowsPickup,
                TimeZone = string.IsNullOrWhiteSpace(request.TimeZone) ? "Central Standard Time (Mexico)" : request.TimeZone.Trim(),
                TimeZoneIANA = string.IsNullOrWhiteSpace(request.TimeZoneIANA) ? "America/Mexico_City" : request.TimeZoneIANA.Trim(),
                Currency = string.IsNullOrWhiteSpace(request.Currency) ? null : request.Currency.Trim(),
                Culture = string.IsNullOrWhiteSpace(request.Culture) ? null : request.Culture.Trim(),
                User = _userContext.GetUserIdentifier()
            };

            var result = await _branchRepository.SaveAsync(@params);
            return RepositoryResponse<EmptyDto>.FromSuccess(result);
        }

        public async Task<RepositoryResponse<EmptyDto>> DeleteBranchAsync(int branchId)
        {
            var @params = new DeleteBranchParams
            {
                BranchId = branchId,
                CompanyId = _userContext.GetCompanyId(),
                User = _userContext.GetUserIdentifier()
            };

            var result = await _branchRepository.DeleteAsync(@params);
            return RepositoryResponse<EmptyDto>.FromSuccess(result);
        }
    }
}
