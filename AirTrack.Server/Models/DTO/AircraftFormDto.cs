using AirTrack.Model.Aircraft;

namespace AirTrack.Server.Models.DTO
    {
    public class AircraftFormDto
        {
        public string TailNumber { get; set; } = string.Empty;
        public decimal Hobbs { get; set; }
        public decimal Tach { get; set; }
        public DateTime AnnualDueDate { get; set; }
        public AircraftStatus Status { get; set; }
        }

    }
