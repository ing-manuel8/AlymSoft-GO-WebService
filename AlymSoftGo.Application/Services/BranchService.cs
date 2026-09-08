using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Domain.Interfaces.Services;

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
            var companyId = _userContext.GetCompanyId();
            var data = await _branchRepository.GetBranchesByCompanyAsync<List<BranchDto>>(companyId);
            return RepositoryResponse<List<BranchDto>>.FromSuccess(data);
        }

        public async Task<RepositoryResponse<BranchDto>> GetBranchByIdAsync(int branchId)
        {
            var data = await _branchRepository.GetBranchByIdAsync<BranchDto>(branchId);
            return RepositoryResponse<BranchDto>.FromSuccess(data);
        }
    }
}
