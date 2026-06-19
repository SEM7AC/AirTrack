using AirTrack.Server.Models.Aircraft;

namespace AirTrack.Server.Models.FormModel
    {
    public class AircraftFormModel
        {
        public string TailNumber { get; set; } = string.Empty;
        public decimal Hobbs { get; set; }
        public decimal Tach { get; set; }
        public DateTime AnnualDueDate { get; set; }
        public AircraftStatus Status { get; set; }
        }

    }
