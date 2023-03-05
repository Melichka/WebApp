using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Auto.Models
{
    public partial class InsuranceType
    {
        
        public InsuranceType()
        {
            Insurance = new HashSet<Insurance>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string? Name { get; set; }

        public virtual ICollection<Insurance> Insurance { get; set; }
    }
}
