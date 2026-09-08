using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.DTOs.Modifier;
using AlymSoftGo.Domain.Interfaces.Persistence;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Domain.Params.Modifier;
using AlymSoftGo.Infrastructure.Repositories.Base;

namespace AlymSoftGo.Infrastructure.Repositories
{
    public class ModifierRepository : GenericRepository, IModifierRepository
    {
        public ModifierRepository(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public async Task<(List<ModifierGroupDto> Groups, List<ModifierDto> Modifiers)> GetGroupsByCompanyAsync(GetModifierGroupsByCompanyParams @params)
        {
            return await ResolveSpAsync<List<ModifierGroupDto>, List<ModifierDto>>(@params);
        }

        public async Task<(List<ModifierGroupDto> Groups, List<ModifierDto> Modifiers)> GetGroupsByProductAsync(GetModifierGroupsByProductParams @params)
        {
            return await ResolveSpAsync<List<ModifierGroupDto>, List<ModifierDto>>(@params);
        }

        public async Task<EmptyDto> SaveGroupAsync(SaveModifierGroupParams @params)
        {
            return await ResolveSpAsync<EmptyDto>(@params);
        }

        public async Task<EmptyDto> DeleteGroupAsync(DeleteModifierGroupParams @params)
        {
            return await ResolveSpAsync<EmptyDto>(@params);
        }

        public async Task<EmptyDto> AssignProductGroupsAsync(AssignProductModifiersParams @params)
        {
            return await ResolveSpAsync<EmptyDto>(@params);
        }
    }
}
