using CsvHelper.Configuration.Attributes;

namespace MyAPI.Entities.DTOs.Inventory
{
    public class InventoryDto
    {
        [Name("product_id")]
        public int ProductId { get; set; }

        [Name("sku")]
        public string SKU { get; set; }

        [Name("unit")]
        public string Unit { get; set; }

        [Name("qty")]
        public string Qty { get; set; }

        [Name("manufacturer_name")]
        public string Manufacturer { get; set; }

        [Name("manufacturer_ref_num")]
        public string ManufacturerRefNum { get; set; }

        [Name("shipping")]
        public string Shipping { get; set; }

        [Name("shipping_cost")]
        public string ShippingCost { get; set; }
    }
}
