using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAPI.Entities
{
    public class Price
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Column1 { get; set; }

        [Required]
        [StringLength(50)]
        public string Column2 { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Column3 { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Column4 { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Column5 { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Column6 { get; set; }
    }
}