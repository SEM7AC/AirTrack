using System.ComponentModel.DataAnnotations;
using AirTrack.Models.People;

namespace AirTrack.Models.Maintenance
    {
    public class MechanicSignoff
        {
        public int Id { get; set; }

        // Required: every signoff belongs to a WorkOrder
        [Required]
        public int WorkOrderId { get; set; }
        public WorkOrder? WorkOrder { get; set; }

        // Required: mechanic who signs off the work
        [Required]
        public int MechanicId { get; set; }
        public Mechanic? Mechanic { get; set; }

        // Required: certification statement
        [Required]
        public string SignoffText { get; set; } = string.Empty;

        // Timestamp of signoff
        public DateTime SignedAt { get; set; } = DateTime.UtcNow;

        // Optional: mechanic's certificate number at time of signoff
        public string CertificateNumber { get; set; } = string.Empty;
        }
    }
