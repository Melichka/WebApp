using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Auto.Models
{
    public partial class Insuranceagent
    {
        public Insuranceagent()
        {
            Incident = new HashSet<Incident>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string? Number { get; set; }

        [Required]
        [StringLength(50)]
        public string? Login { get; set; }

        [Required]
        [StringLength(50)]
        public string? Password { get; set; }

        [Required]
        [StringLength(50)]
        public string? Email { get; set; }

        [Required]
        [StringLength(50)]
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Incident> Incident { get; set; }

    }
}
