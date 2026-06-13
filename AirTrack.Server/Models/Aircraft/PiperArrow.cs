namespace AirTrack.Model.Aircraft
    {
    public class PiperArrow : AircraftBase
        {
        public decimal HoursSinceLastOilChange { get; set; }
        public decimal HoursSinceLast100Hr {  get; set; }
        public int GearCyclesSinceInspection {  get; set; }
        public DateTime? PropOverhaulDue {  get; set; }

        public List<RecurringAD> RecurringADs { get; set; } = new();

        }
    }
