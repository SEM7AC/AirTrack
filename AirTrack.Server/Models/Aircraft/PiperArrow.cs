namespace AirTrack.Server.Models.Aircraft
    {
    public class PiperArrow : AircraftBase
        {
        public decimal LastOilChange { get; set; }
        public decimal Last100Hr {  get; set; }
        public int LastGearCyclesInspection {  get; set; }
        public DateTime? PropOverhaulDue {  get; set; }

       

        }
    }
