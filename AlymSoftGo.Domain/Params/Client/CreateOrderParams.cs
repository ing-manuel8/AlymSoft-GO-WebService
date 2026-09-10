namespace AlymSoftGo.Domain.Params.Client
{
    public class CreateOrderParams
    {
        public string? vDominioSlug { get; set; }
        public int? idSucursal { get; set; }
        public string? vClienteNombre { get; set; }
        public string? vClienteTelefono { get; set; }
        public string? vClienteEmail { get; set; }
        public int idCatTipoEntrega { get; set; }
        public string? vDireccionEntrega { get; set; }
        public string? vComentariosPedido { get; set; }
        public int idCatMedioPago { get; set; }
        public decimal dSubtotal { get; set; }
        public decimal dCostoEnvio { get; set; }
        public decimal dDescuento { get; set; }
        public decimal dTotal { get; set; }
        public string? vItemsJSON { get; set; }
    }
}
