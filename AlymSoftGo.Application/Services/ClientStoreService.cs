using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs.Client;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Domain.Params.Client;

namespace AlymSoftGo.Application.Services
{
    public class ClientStoreService : IClientStoreService
    {
        private readonly IClientStoreRepository _clientRepository;

        public ClientStoreService(IClientStoreRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<RepositoryResponse<ClientStoreInfoDto>> GetStoreBySlugAsync(string slug, int? branchId = null)
        {
            if (string.IsNullOrWhiteSpace(slug))
            {
                return RepositoryResponse<ClientStoreInfoDto>.FromError(ResponseCode.ValidationFailed, "Slug de tienda requerido.");
            }

            var store = await _clientRepository.GetStoreBySlugAsync(new GetStoreBySlugParams
            {
                vDominioSlug = slug.Trim(),
                idSucursal = branchId
            });

            if (store == null || store.CompanyId == 0)
            {
                return RepositoryResponse<ClientStoreInfoDto>.FromError(ResponseCode.ValidationFailed, "Tienda no encontrada.");
            }

            return RepositoryResponse<ClientStoreInfoDto>.FromSuccess(store);
        }

        public async Task<RepositoryResponse<ClientCatalogDto>> GetCatalogAsync(string slug, int? branchId = null, int? categoryId = null, string? search = null)
        {
            if (string.IsNullOrWhiteSpace(slug))
            {
                return RepositoryResponse<ClientCatalogDto>.FromError(ResponseCode.ValidationFailed, "Slug de tienda requerido.");
            }

            var store = await _clientRepository.GetStoreBySlugAsync(new GetStoreBySlugParams
            {
                vDominioSlug = slug.Trim(),
                idSucursal = branchId
            });

            if (store == null || store.CompanyId == 0)
            {
                return RepositoryResponse<ClientCatalogDto>.FromError(ResponseCode.ValidationFailed, "Tienda no encontrada.");
            }

            var content = await _clientRepository.GetCatalogAsync(new GetCatalogParams
            {
                vDominioSlug = slug.Trim(),
                idSucursal = branchId,
                idCategoria = categoryId,
                vSearch = search?.Trim()
            });

            var catalog = new ClientCatalogDto
            {
                Store = store,
                Categories = content?.Categories ?? new(),
                Products = content?.Products ?? new()
            };

            return RepositoryResponse<ClientCatalogDto>.FromSuccess(catalog);
        }

        public async Task<RepositoryResponse<ClientProductDetailDto>> GetProductDetailAsync(int productId, int? branchId = null)
        {
            if (productId <= 0)
            {
                return RepositoryResponse<ClientProductDetailDto>.FromError(ResponseCode.ValidationFailed, "ID de producto inválido.");
            }

            var product = await _clientRepository.GetProductDetailAsync(new GetProductDetailParams
            {
                idProducto = productId,
                idSucursal = branchId
            });

            if (product == null || product.Id == 0)
            {
                return RepositoryResponse<ClientProductDetailDto>.FromError(ResponseCode.ValidationFailed, "Producto no encontrado.");
            }

            return RepositoryResponse<ClientProductDetailDto>.FromSuccess(product);
        }

        public async Task<RepositoryResponse<ClientOrderResultDto>> CreateOrderAsync(ClientCreateOrderRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.StoreSlug))
            {
                return RepositoryResponse<ClientOrderResultDto>.FromError(ResponseCode.ValidationFailed, "Slug de tienda requerido.");
            }

            if (string.IsNullOrWhiteSpace(request.CustomerName) || string.IsNullOrWhiteSpace(request.CustomerPhone))
            {
                return RepositoryResponse<ClientOrderResultDto>.FromError(ResponseCode.ValidationFailed, "Nombre y teléfono del cliente requeridos.");
            }

            if (request.Items == null || request.Items.Count == 0)
            {
                return RepositoryResponse<ClientOrderResultDto>.FromError(ResponseCode.ValidationFailed, "El pedido debe contener al menos un producto.");
            }

            // Normalizar JSON de items y modificadores para el SP
            var itemsListForJson = request.Items.Select(item => new
            {
                idProducto = item.ProductId,
                vProductoNombre = item.ProductName,
                vSKU = item.Sku,
                vCodigoBarras = item.Barcode,
                idCatTipoUnidad = item.UnitTypeId ?? 1,
                dPrecioUnitario = item.UnitPrice,
                dCantidad = item.Quantity,
                dImporteTotal = item.Total,
                vInstruccionesEspeciales = item.SpecialInstructions,
                vModificadoresJSON = item.Modifiers != null && item.Modifiers.Count > 0 ? (object)item.Modifiers.Select(m => new
                {
                    idModificador = m.ModifierId,
                    vGrupoNombre = m.GroupName,
                    vModificadorNombre = m.ModifierName,
                    dPrecioExtra = m.ExtraPrice,
                    nCantidad = m.Quantity,
                    vSeccion = m.Section
                }).ToList() : null
            }).ToList();

            var itemsJson = JsonConvert.SerializeObject(itemsListForJson);

            var @params = new CreateOrderParams
            {
                vDominioSlug = request.StoreSlug.Trim(),
                idSucursal = request.BranchId,
                vClienteNombre = request.CustomerName.Trim(),
                vClienteTelefono = request.CustomerPhone.Trim(),
                vClienteEmail = request.CustomerEmail?.Trim(),
                idCatTipoEntrega = request.FulfillmentType,
                vDireccionEntrega = request.DeliveryAddress?.Trim(),
                vComentariosPedido = request.Comments?.Trim(),
                idCatMedioPago = request.PaymentMethodId,
                dSubtotal = request.Subtotal,
                dCostoEnvio = request.DeliveryFee,
                dDescuento = request.Discount,
                dTotal = request.Total,
                vItemsJSON = itemsJson
            };

            var result = await _clientRepository.CreateOrderAsync(@params);
            return RepositoryResponse<ClientOrderResultDto>.FromSuccess(result);
        }

        public async Task<RepositoryResponse<ClientOrderStatusDto>> GetOrderStatusAsync(string folio, string? phone = null)
        {
            if (string.IsNullOrWhiteSpace(folio))
            {
                return RepositoryResponse<ClientOrderStatusDto>.FromError(ResponseCode.ValidationFailed, "Folio de pedido requerido.");
            }

            var order = await _clientRepository.GetOrderStatusAsync(new GetOrderStatusParams
            {
                vFolio = folio.Trim(),
                vTelefono = phone?.Trim()
            });

            if (order == null || order.Id == 0)
            {
                return RepositoryResponse<ClientOrderStatusDto>.FromError(ResponseCode.ValidationFailed, "Pedido no encontrado.");
            }

            return RepositoryResponse<ClientOrderStatusDto>.FromSuccess(order);
        }
    }
}
