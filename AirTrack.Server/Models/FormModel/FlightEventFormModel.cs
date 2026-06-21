namespace AirTrack.Server.Models.FormModel
    {
    public class FlightEventFormModel
        {
        public int? Id { get; set; }
        public int? AircraftId { get; set; }
        public int? InstructorId { get; set; }
        public int? StudentId { get; set; }
        public int? MechanicId { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        }
    }
