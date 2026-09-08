using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.DTOs.Modifier;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Domain.Interfaces.Services;
using AlymSoftGo.Domain.Params.Modifier;

namespace AlymSoftGo.Application.Services
{
    public class ModifierService : IModifierService
    {
        private readonly IModifierRepository _modifierRepository;
        private readonly IUserContextService _userContext;

        private static readonly JsonSerializerSettings CamelCaseSettings = new()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        public ModifierService(IModifierRepository modifierRepository, IUserContextService userContext)
        {
            _modifierRepository = modifierRepository;
            _userContext = userContext;
        }

        public async Task<RepositoryResponse<List<ModifierGroupDto>>> GetGroupsByCompanyAsync()
        {
            var @params = new GetModifierGroupsByCompanyParams
            {
                CompanyId = _userContext.GetCompanyId()
            };

            var (groups, modifiers) = await _modifierRepository.GetGroupsByCompanyAsync(@params);

            var modifierDict = modifiers.GroupBy(m => m.GroupId).ToDictionary(g => g.Key, g => g.ToList());
            foreach (var group in groups)
            {
                if (modifierDict.TryGetValue(group.Id, out var groupModifiers))
                {
                    group.Modifiers = groupModifiers;
                }
            }

            return RepositoryResponse<List<ModifierGroupDto>>.FromSuccess(groups);
        }

        public async Task<RepositoryResponse<List<ModifierGroupDto>>> GetGroupsByProductAsync(int productId)
        {
            var @params = new GetModifierGroupsByProductParams
            {
                ProductId = productId,
                CompanyId = _userContext.GetCompanyId()
            };

            var (groups, modifiers) = await _modifierRepository.GetGroupsByProductAsync(@params);

            var modifierDict = modifiers.GroupBy(m => m.GroupId).ToDictionary(g => g.Key, g => g.ToList());
            foreach (var group in groups)
            {
                if (modifierDict.TryGetValue(group.Id, out var groupModifiers))
                {
                    group.Modifiers = groupModifiers;
                }
            }

            return RepositoryResponse<List<ModifierGroupDto>>.FromSuccess(groups);
        }

        public async Task<RepositoryResponse<EmptyDto>> SaveGroupAsync(SaveModifierGroupRequestDto request)
        {
            string? optionsJson = null;
            if (request.Options != null && request.Options.Count > 0)
            {
                optionsJson = JsonConvert.SerializeObject(request.Options, CamelCaseSettings);
            }

            var @params = new SaveModifierGroupParams
            {
                Id = request.Id,
                CompanyId = _userContext.GetCompanyId(),
                Name = request.Name,
                Description = request.Description,
                IsRequired = request.IsRequired,
                MinSelect = request.MinSelect,
                MaxSelect = request.MaxSelect,
                AllowsPartition = request.AllowsPartition,
                OptionsJson = optionsJson,
                ProductId = request.ProductId,
                User = _userContext.GetUserIdentifier()
            };

            var result = await _modifierRepository.SaveGroupAsync(@params);
            return RepositoryResponse<EmptyDto>.FromSuccess(result);
        }

        public async Task<RepositoryResponse<EmptyDto>> DeleteGroupAsync(int groupId)
        {
            var @params = new DeleteModifierGroupParams
            {
                Id = groupId,
                CompanyId = _userContext.GetCompanyId(),
                User = _userContext.GetUserIdentifier()
            };

            var result = await _modifierRepository.DeleteGroupAsync(@params);
            return RepositoryResponse<EmptyDto>.FromSuccess(result);
        }

        public async Task<RepositoryResponse<EmptyDto>> AssignProductGroupsAsync(AssignProductModifiersRequestDto request)
        {
            string groupsJson = JsonConvert.SerializeObject(request.Groups ?? new List<ProductModifierAssignmentDto>(), CamelCaseSettings);

            var @params = new AssignProductModifiersParams
            {
                ProductId = request.ProductId,
                CompanyId = _userContext.GetCompanyId(),
                GroupsJson = groupsJson,
                User = _userContext.GetUserIdentifier()
            };

            var result = await _modifierRepository.AssignProductGroupsAsync(@params);
            return RepositoryResponse<EmptyDto>.FromSuccess(result);
        }
    }
}
