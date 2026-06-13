namespace AirTrack.Model.Aircraft
    {
    public class RecurringAD
        {
        public int Id { get; set; }  // EF Core primary key
        public string ADNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal IntervalHours { get; set; }
        public DateTime? LastCompliedWith { get; set; }
        
        // Relationship back to the aircraft
        public int AircraftId { get; set; }
        public AircraftBase Aircraft { get; set; } = null!;
        }

    }
