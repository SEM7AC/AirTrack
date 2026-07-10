namespace AirTrack.Server.Models.Aircraft
    {

    
    public class CessnaSkyhawk : AircraftBase
        {
       

        public decimal LastOilChange { get; set; }
        public decimal Last50Hr { get; set; }

        public decimal Last100Hr { get; set; }
               
        public DateTime? ELTInspectionDue {  get; set; }

        public DateTime? TransponderDue {  get; set; }
        public DateTime? PitotStaticDue {  get; set; }

        
        }
    }
