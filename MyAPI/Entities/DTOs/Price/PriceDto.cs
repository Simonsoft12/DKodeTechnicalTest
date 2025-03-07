using CsvHelper.Configuration.Attributes;

namespace MyAPI.Entities.DTOs.Price
{
    public class PriceDto
    {
        public string UniqueId { get; set; }
        public string SKU { get; set; }
        public string NetPrice { get; set; }
        public string PriceAfterDiscount { get; set; }
        public string VATRate { get; set; }
        public string NetPriceAfterDiscountForUnit { get; set; }
    }

}
