namespace AirTrack.Server.Model.Aircraft
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
        // EF CORE Identity
        public int Id { get; set; }

        // Identity
        public string TailNumber { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;

        // Operational Time
        public decimal Hobbs { get; set; }
        public decimal Tach { get; set; }

        // Universal Maintenance
        public DateTime AnnualDueDate { get; set; }
        public int SquawkCount { get; set; }

        // Status
        public AircraftStatus Status { get; set; }

        // Current Flight
        public string CurrentStudent { get; set; } = string.Empty;
        public string CurrentInstructor { get; set; } = string.Empty;
        public DateTime? CurrentFlightStart { get; set; }

        // Scheduling
        public DateTime? NextBookingStart { get; set; }
        public DateTime? NextBookingEnd { get; set; }
        }
    }
