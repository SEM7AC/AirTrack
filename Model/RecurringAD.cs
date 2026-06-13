namespace AirTrack.Model
    {
    public class RecurringAD
        {
        public string ADNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal IntervalHours { get; set; }
        public DateTime? LastCompliedWith { get; set; }
        }

    }
