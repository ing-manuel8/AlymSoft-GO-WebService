using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Persistence;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Infrastructure.Repositories.Base;

namespace AlymSoftGo.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository, IProductRepository
    {
        public ProductRepository(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public async Task<TData> GetProductsByCompanyAsync<TData>(int idEmpresa, int? idCategoria = null, int? idSucursal = null) where TData : class, new()
        {
            var parameters = new Dictionary<string, object>
            {
                { "idEmpresa", idEmpresa }
            };

            if (idCategoria.HasValue) parameters["idCategoria"] = idCategoria.Value;
            if (idSucursal.HasValue) parameters["idSucursal"] = idSucursal.Value;

            return await ResolveSpAsync<TData>(parameters);
        }

        public async Task<TData> GetProductByIdAsync<TData>(int idProducto, int? idSucursal = null) where TData : class, new()
        {
            var parameters = new Dictionary<string, object>
            {
                { "idProducto", idProducto }
            };

            if (idSucursal.HasValue) parameters["idSucursal"] = idSucursal.Value;

            return await ResolveSpAsync<TData>(parameters);
        }

        public async Task<EmptyDto> SaveProductAsync(object @params)
        {
            return await ResolveSpAsync<EmptyDto>(@params);
        }

        public async Task<EmptyDto> DeleteProductAsync(int idProducto, int idEmpresa, string vUpdatedUser)
        {
            var parameters = new Dictionary<string, object>
            {
                { "idProducto", idProducto },
                { "idEmpresa", idEmpresa },
                { "vUpdatedUser", vUpdatedUser }
            };

            return await ResolveSpAsync<EmptyDto>(parameters);
        }
    }
}
