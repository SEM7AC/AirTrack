namespace AirTrack.Model
    {

    
    public class Cessna172 : AircraftBase
        {
       

        public decimal HoursSinceLastOilChange { get; set; }
        public decimal HoursSinceLast50Hr { get; set; }

        public decimal HoursSinceLast100Hr { get; set; }
               
        public DateTime? ELTInspectionDue {  get; set; }

        public DateTime? TransponderDue {  get; set; }
        public DateTime? PitotStaticDue {  get; set; }
                
        }
    }
