using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAPI.Entities
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string SKU { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string EAN { get; set; }

        [StringLength(255)]
        public string ProducerName { get; set; }

        [StringLength(255)]
        public string MainCategory { get; set; }

        [StringLength(255)]
        public string SubCategory { get; set; }

        [StringLength(255)]
        public string ChildCategory { get; set; }

        public bool? IsWire { get; set; }

        [StringLength(10)]
        public string Shipping { get; set; }
        public bool? Available { get; set; }
        public bool? IsVendor { get; set; }

        [StringLength(500)]
        public string DefaultImage { get; set; }
    }
}