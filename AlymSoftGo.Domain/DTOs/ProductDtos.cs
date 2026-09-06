namespace AlymSoftGo.Domain.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? ProductTypeId { get; set; }
        public int? UnitTypeId { get; set; }
        public string? Sku { get; set; }
        public string? Barcode { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImagesJson { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal? OfferPrice { get; set; }
        public bool TrackStock { get; set; }
        public decimal Stock { get; set; }
        public decimal MinStock { get; set; }
        public bool IsOnSale { get; set; }
        public string? SaleTag { get; set; }
        public bool IsActive { get; set; }
    }

    public class SaveProductRequestDto
    {
        public int? ProductId { get; set; }
        public int? IdProducto { set => ProductId = value; }

        public int CompanyId { get; set; }
        public int IdEmpresa { set => CompanyId = value; }

        public int? BranchId { get; set; }
        public int? IdSucursal { set => BranchId = value; }

        public int? CategoryId { get; set; }
        public int? IdCategoria { set => CategoryId = value; }

        public int? ProductTypeId { get; set; } = 1;
        public int? IdCatTipoProducto { set => ProductTypeId = value; }

        public int? UnitTypeId { get; set; } = 1;
        public int? IdCatTipoUnidad { set => UnitTypeId = value; }

        public string? Sku { get; set; }
        public string? VSKU { set => Sku = value; }

        public string? Barcode { get; set; }
        public string? VCodigoBarras { set => Barcode = value; }

        public string Name { get; set; } = string.Empty;
        public string VNombre { set => Name = value; }

        public string? Description { get; set; }
        public string? VDescripcion { set => Description = value; }

        public string? ImagesJson { get; set; }
        public string? VImagenesJSON { set => ImagesJson = value; }

        public decimal Cost { get; set; } = 0;
        public decimal DCosto { set => Cost = value; }

        public decimal Price { get; set; }
        public decimal DPrecio { set => Price = value; }

        public decimal? OfferPrice { get; set; }
        public decimal? DPrecioOferta { set => OfferPrice = value; }

        public bool TrackStock { get; set; } = true;
        public bool BControlaStock { set => TrackStock = value; }

        public decimal Stock { get; set; } = 0;
        public decimal DStock { set => Stock = value; }

        public decimal MinStock { get; set; } = 0;
        public decimal DStockMinimo { set => MinStock = value; }

        public bool IsOnSale { get; set; } = false;
        public bool BEsOferta { set => IsOnSale = value; }

        public string? SaleTag { get; set; }
        public string? VEtiquetaOferta { set => SaleTag = value; }

        public string? User { get; set; } = "SYSTEM";
        public string? VUser { set => User = value; }
    }
}
