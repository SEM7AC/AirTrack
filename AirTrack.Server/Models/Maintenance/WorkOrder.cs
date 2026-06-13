using System.ComponentModel.DataAnnotations;
using AirTrack.Models.People;

namespace AirTrack.Models.Maintenance
    {
    public class WorkOrder
        {
        public int Id { get; set; }

        // Required: every WorkOrder comes from a Squawk
        [Required]
        public int SquawkId { get; set; }
        public Squawk? Squawk { get; set; }

        // Optional: assigned mechanic (may not be assigned yet)
        public int? AssignedMechanicId { get; set; }
        public Mechanic? AssignedMechanic { get; set; }

        // When work actually begins
        public DateTime? StartedAt { get; set; }

        // When work is completed (before signoff)
        public DateTime? CompletedAt { get; set; }

        // Status of the work order
        public WorkOrderStatus Status { get; set; } = WorkOrderStatus.Open;

        // Corrective actions will attach here later
        public List<CorrectiveAction> Actions { get; set; } = new();
        }

    public enum WorkOrderStatus
        {
        Open = 1,
        InProgress = 2,
        AwaitingSignoff = 3,
        Completed = 4,
        Closed = 5
        }
    }
