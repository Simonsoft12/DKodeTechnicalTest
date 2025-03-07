using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyAPI.Entities
{
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        [StringLength(50)]
        public string SKU { get; set; }

        [Required]
        [StringLength(50)]
        public string Unit { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal? Qty { get; set; }

        [StringLength(255)]
        public string Manufacturer { get; set; }

        [StringLength(10)]
        public string Shipping { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ShippingCost { get; set; }
    }
}
