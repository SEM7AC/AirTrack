using AirTrack.Model.Aircraft;
using AirTrack.Models.People;
using System.ComponentModel.DataAnnotations;

namespace AirTrack.Models.Maintenance
    {
    public class CorrectiveAction
        {
        public int Id { get; set; }

        // Required: every action belongs to a WorkOrder
        [Required]
        public int WorkOrderId { get; set; }
        public WorkOrder? WorkOrder { get; set; }

        // Required: mechanic who performed the action
        [Required]
        public int MechanicId { get; set; }
        public Mechanic? Mechanic { get; set; }

        // Required: what was actually done
        [Required]
        public string ActionDescription { get; set; } = string.Empty;

        // Optional: parts replaced, part numbers, etc.
        public string PartsUsed { get; set; } = string.Empty;

        // Optional: reference to an AD or SB
        public int? RecurringADId { get; set; }
        public RecurringAD? RecurringAD { get; set; }

        // Labor time in hours
        public decimal LaborHours { get; set; }

        public DateTime PerformedAt { get; set; } = DateTime.UtcNow;
        }
    }
