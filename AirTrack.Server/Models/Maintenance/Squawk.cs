using System.ComponentModel.DataAnnotations;
using AirTrack.Server.Models.Aircraft;

namespace AirTrack.Server.Models.Maintenance
    {
    public class Squawk
        {
        public int Id { get; set; }

        [Required]
        public int AircraftId { get; set; }
        public AircraftBase? Aircraft { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        public bool IsGrounding { get; set; }

        public DateTime ReportedAt { get; set; } = DateTime.UtcNow;

        // Only used when resolving a squawk
        public DateTime? ResolvedAt { get; set; }
        public string? ResolutionNotes { get; set; }
        public string? MechanicSignoff { get; set; }
        }
    }
