using CsvHelper.Configuration.Attributes;

namespace MyAPI.Entities.DTOs.Product
{
    public class ProductDto
    {
        [Name("ID")]
        public string ProductId { get; set; }

        [Name("SKU")]
        public string Sku { get; set; }

        [Name("name")]
        public string Name { get; set; }

        [Name("reference_number")]
        public string ReferenceNumber { get; set; }

        [Name("EAN")]
        public string Ean { get; set; }

        [Name("can_be_returned")]
        public bool? CanBeReturned { get; set; }

        [Name("producer_name")]
        public string ProducerName { get; set; }

        [Name("category")]
        public string Category { get; set; }

        [Name("is_wire")]
        public bool? IsWire { get; set; }

        [Name("shipping")]
        public string Shipping { get; set; }

        [Name("package_size")]
        public string PackageSize { get; set; }

        [Name("available")]
        public bool? Available { get; set; }

        [Name("logistic_height")]
        public string LogisticHeight { get; set; }

        [Name("logistic_width")]
        public string LogisticWidth { get; set; }

        [Name("logistic_length")]
        public string LogisticLength { get; set; }

        [Name("logistic_weight")]
        public string LogisticWeight { get; set; }

        [Name("is_vendor")]
        public bool? IsVendor { get; set; }

        [Name("available_in_parcel_locker")]
        public bool? AvailableInParcelLocker { get; set; }

        [Name("default_image")]
        public string DefaultImage { get; set; }
    }

}
