using AlymSoftGo.Domain.DTOs;

namespace AlymSoftGo.Domain.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        Task<TData> GetCompanyByIdAsync<TData>(int idEmpresa) where TData : class, new();
        Task<TData> GetCompanyBySlugAsync<TData>(string vDominioSlug) where TData : class, new();
        Task<EmptyDto> SaveCompanyAsync(object @params);
    }
}
