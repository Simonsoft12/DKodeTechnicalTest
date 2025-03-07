namespace MyAPI.Entities.DTOs.Supplier
{
    public class SupplierSummaryDto
    {
        public string SupplierName { get; set; }
        public string MainCategory { get; set; }
        public string SubCategory { get; set; }
        public decimal TotalStockQuantity { get; set; }
        public decimal AveragePriceIncludingVAT { get; set; }
        public decimal TotalStockValueIncludingVAT { get; set; }
        public string ShippedBy { get; set; }
    }
}
