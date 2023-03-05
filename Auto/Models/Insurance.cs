using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Auto.Models
{
    public partial class Insurance
    {
        public Insurance()
        {
            Payment = new HashSet<Payment>();
            Incident = new HashSet<Incident>();
        }
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime FinishDate { get; set; }
        public string Policy { get; set; }
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
        public string DrivingExperience { get; set; }

        public string FIO { get; set; }

        public string OwnerPassport { get; set; }

        public string OwnerSertificate { get; set; }

        public int AutoId { get; set; }

        public int TypeId { get; set; }

        public virtual Auto Auto { get; set; }

        public virtual InsuranceType InsuranceType { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<Incident> Incident { get; set; }
    }
}