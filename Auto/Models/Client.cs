using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Auto.Models
{
    public partial class Client
    {
     
        public Client()
        {
            Auto = new HashSet<Auto>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string? FIO { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [Required]
        public string? Passport { get; set; }

        [Required]
        public string? Sertificate { get; set; }

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

        
        public virtual ICollection<Auto> Auto { get; set; }

    }
}
