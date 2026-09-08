using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;

namespace AlymSoftGo.Application.Interfaces
{
    public interface IBranchService
    {
        Task<RepositoryResponse<List<BranchDto>>> GetBranchesAsync();
        Task<RepositoryResponse<BranchDto>> GetBranchByIdAsync(int branchId);
    }
}
