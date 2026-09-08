using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.DTOs.Branch;

namespace AlymSoftGo.Application.Interfaces
{
    public interface IBranchService
    {
        Task<RepositoryResponse<List<BranchDto>>> GetBranchesAsync();
        Task<RepositoryResponse<BranchDto>> GetBranchByIdAsync(int branchId);
        Task<RepositoryResponse<List<BranchUserDto>>> GetAssignableUsersAsync();
        Task<RepositoryResponse<EmptyDto>> SaveBranchAsync(SaveBranchRequestDto request);
        Task<RepositoryResponse<EmptyDto>> DeleteBranchAsync(int branchId);
    }
}
