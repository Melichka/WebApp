using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace Auto.Models
{
    public partial class Auto
    {
        public Auto()
        {
            Insurance = new HashSet<Insurance>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? Brand { get; set; }

        [StringLength(50)]
        public string? Model { get; set; }

        public int EnginePower { get; set; }

        [StringLength(50)]
        public string? NumberAuto { get; set; }

        public int? Run { get; set; }

        [Required]
        [StringLength(50)]
        public string? NumberPTS { get; set; }

        public int ClientId { get; set; }
        public virtual Client? Client { get; set; }

        public virtual ICollection<Insurance> Insurance { get; set; }

    }
}
