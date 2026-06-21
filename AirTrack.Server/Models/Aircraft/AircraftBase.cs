using System.ComponentModel.DataAnnotations.Schema;

namespace AirTrack.Server.Models.Aircraft
    {
    public enum AircraftStatus
        {
        Available,
        InFlight,
        Scheduled,
        Maintenance
        }

    public abstract class AircraftBase
        {
        // EF Core Identity
        public int Id { get; set; }

        // Identity / Configuration
        public string TailNumber { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string EngineType { get; set; } = string.Empty;
        public string FuelType { get; set; } = string.Empty;
        public int Seats { get; set; }
        public string Notes { get; set; } = string.Empty;

        // Operational Time
        public decimal Hobbs { get; set; }
        public decimal Tach { get; set; }

        // Maintenance
        public DateTime AnnualDueDate { get; set; }
        public int SquawkCount { get; set; }

        // Status & Equipment
        [NotMapped]
        public AircraftStatus Status { get; set; }
        public OptionalEquipment Equipment { get; set; }

        // Current Flight (runtime)
        public string CurrentStudent { get; set; } = string.Empty;
        public string CurrentInstructor { get; set; } = string.Empty;
        public DateTime? CurrentFlightStart { get; set; }

        // Scheduling (runtime)
        public DateTime? NextBookingStart { get; set; }
        public DateTime? NextBookingEnd { get; set; }
        }
    }
