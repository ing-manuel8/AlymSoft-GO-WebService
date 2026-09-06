using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Product
{
    /// <summary>
    /// Parámetros para crear o actualizar un producto
    /// </summary>
    public class SaveProductParams
    {
        [JsonProperty("@idProducto")]
        public int? ProductId { get; set; }

        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }

        [JsonProperty("@idSucursal")]
        public int? BranchId { get; set; }

        [JsonProperty("@idCategoria")]
        public int? CategoryId { get; set; }

        [JsonProperty("@idCatTipoProducto")]
        public int? ProductTypeId { get; set; } = 1;

        [JsonProperty("@idCatTipoUnidad")]
        public int? UnitTypeId { get; set; } = 1;

        [JsonProperty("@vSKU")]
        public string? Sku { get; set; }

        [JsonProperty("@vCodigoBarras")]
        public string? Barcode { get; set; }

        [JsonProperty("@vNombre")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("@vDescripcion")]
        public string? Description { get; set; }

        [JsonProperty("@vImagenesJSON")]
        public string? ImagesJson { get; set; }

        [JsonProperty("@dCosto")]
        public decimal Cost { get; set; } = 0;

        [JsonProperty("@dPrecio")]
        [Required]
        public decimal Price { get; set; }

        [JsonProperty("@dPrecioOferta")]
        public decimal? OfferPrice { get; set; }

        [JsonProperty("@bControlaStock")]
        public bool TrackStock { get; set; } = true;

        [JsonProperty("@dStock")]
        public decimal Stock { get; set; } = 0;

        [JsonProperty("@dStockMinimo")]
        public decimal MinStock { get; set; } = 0;

        [JsonProperty("@bEsOferta")]
        public bool IsOnSale { get; set; } = false;

        [JsonProperty("@vEtiquetaOferta")]
        public string? SaleTag { get; set; }

        [JsonProperty("@vUser")]
        [Required]
        public string User { get; set; } = "SYSTEM";
    }
}
