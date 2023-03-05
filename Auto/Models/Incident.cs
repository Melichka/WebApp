using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Auto.Models
{
    public partial class Incident
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int StatusId { get; set; }
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public int InsuranceId { get; set; }

        public int InsuranceAgentId { get; set; }
        public virtual Insurance Insurance { get; set; }
        public virtual IncidentStatus IncidentStatus { get; set; }
        public virtual Insuranceagent Insuranceagent { get; set; }

    }
}
