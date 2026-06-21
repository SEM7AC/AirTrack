namespace AirTrack.Server.Models.Scheduler
    {
    public class FlightEvent
        {
        public int Id { get; set; }

        public int AircraftId { get; set; }
        public int? InstructorId { get; set; }
        public int? StudentId { get; set; }
        public int? MechanicId { get; set; }

        public DateTime Start { get; set; } = DateTime.Today.AddHours(8);
        public DateTime End { get; set; } = DateTime.Today.AddHours(9);
        }

    }
