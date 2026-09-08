namespace AlymSoftGo.Domain.DTOs.Customer
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string? DefaultAddress { get; set; }
        public string? Notes { get; set; }
    }
}
