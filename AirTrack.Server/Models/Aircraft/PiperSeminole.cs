namespace AirTrack.Model.Aircraft
    {
    public class PiperSeminole : AircraftBase
        {
        public decimal LeftEngineHours { get; set; }
        public decimal RightEngineHours { get; set; }
        public DateTime? LeftPropOverhaulDue { get; set; }
        public DateTime? RightPropOverhaulDue { get; set; }
        public int GearCyclesSinceInspection { get; set; }

        public List<RecurringAD> RecurringADs { get; set; } = new();
        }
    }
