using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.DTOs.Modifier;

namespace AlymSoftGo.Application.Interfaces
{
    public interface IModifierService
    {
        Task<RepositoryResponse<List<ModifierGroupDto>>> GetGroupsByCompanyAsync();
        Task<RepositoryResponse<List<ModifierGroupDto>>> GetGroupsByProductAsync(int productId);
        Task<RepositoryResponse<EmptyDto>> SaveGroupAsync(SaveModifierGroupRequestDto request);
        Task<RepositoryResponse<EmptyDto>> DeleteGroupAsync(int groupId);
        Task<RepositoryResponse<EmptyDto>> AssignProductGroupsAsync(AssignProductModifiersRequestDto request);
    }
}
