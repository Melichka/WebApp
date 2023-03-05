using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Auto.Models
{
    public partial class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public int? InsuranceId { get; set; }
        public virtual Insurance? Insurance { get; set; }
    }
}
