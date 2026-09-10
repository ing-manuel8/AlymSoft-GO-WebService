using System.Threading.Tasks;
using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs.Client;

namespace AlymSoftGo.Application.Interfaces
{
    public interface IClientStoreService
    {
        Task<RepositoryResponse<ClientStoreInfoDto>> GetStoreBySlugAsync(string slug, int? branchId = null);
        Task<RepositoryResponse<ClientCatalogDto>> GetCatalogAsync(string slug, int? branchId = null, int? categoryId = null, string? search = null);
        Task<RepositoryResponse<ClientProductDetailDto>> GetProductDetailAsync(int productId, int? branchId = null);
        Task<RepositoryResponse<ClientOrderResultDto>> CreateOrderAsync(ClientCreateOrderRequestDto request);
        Task<RepositoryResponse<ClientOrderStatusDto>> GetOrderStatusAsync(string folio, string? phone = null);
    }
}
