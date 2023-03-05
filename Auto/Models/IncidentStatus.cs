using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Auto.Models
{
   
    public partial class IncidentStatus
    {
        public IncidentStatus()
        {
            Incident = new HashSet<Incident>();

        }

        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Incident> Incident { get; set; }
    }
}
