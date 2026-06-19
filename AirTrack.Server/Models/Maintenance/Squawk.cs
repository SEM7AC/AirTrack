using System.ComponentModel.DataAnnotations;
using AirTrack.Server.Models.Aircraft;

namespace AirTrack.Server.Models.Maintenance
    {
    public class Squawk
        {
        public int Id { get; set; }

        // Always required
        [Required]
        public int AircraftId { get; set; }
        public AircraftBase? Aircraft { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        public DateTime ReportedAt { get; set; } = DateTime.UtcNow;

        // You said yes to grounding capability
        public bool IsGrounding { get; set; }

        // You said yes to statuses
        public SquawkStatus Status { get; set; } = SquawkStatus.Open;

        // You said work orders MUST come from squawks
        public WorkOrder? WorkOrder { get; set; }
        }

    public enum SquawkStatus
        {
        Open = 1,
        InProgress = 2,
        Resolved = 3,
        Closed = 4
        }
    }
