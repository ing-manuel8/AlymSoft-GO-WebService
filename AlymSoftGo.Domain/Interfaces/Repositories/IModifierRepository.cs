using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.DTOs.Modifier;
using AlymSoftGo.Domain.Params.Modifier;

namespace AlymSoftGo.Domain.Interfaces.Repositories
{
    public interface IModifierRepository
    {
        Task<(List<ModifierGroupDto> Groups, List<ModifierDto> Modifiers)> GetGroupsByCompanyAsync(GetModifierGroupsByCompanyParams @params);
        Task<(List<ModifierGroupDto> Groups, List<ModifierDto> Modifiers)> GetGroupsByProductAsync(GetModifierGroupsByProductParams @params);
        Task<EmptyDto> SaveGroupAsync(SaveModifierGroupParams @params);
        Task<EmptyDto> DeleteGroupAsync(DeleteModifierGroupParams @params);
        Task<EmptyDto> AssignProductGroupsAsync(AssignProductModifiersParams @params);
    }
}
