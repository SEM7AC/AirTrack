using AirTrack.Server.Models.Aircraft;

namespace AirTrack.Server.Models.FormModel
    {
    public class AircraftFormModel
        {
        // Identity
        public string TailNumber { get; set; } = string.Empty;
        public AircraftModel Model { get; set; }
            
        public int Year { get; set; }
        public string EngineType { get; set; } = string.Empty;
        public string FuelType { get; set; } = string.Empty;
        public int Seats { get; set; }
        public string Notes { get; set; } = string.Empty;

        // Operational Time
        public decimal Hobbs { get; set; }
        public decimal Tach { get; set; }

        // Maintenance
        public DateTime AnnualDueDate { get; set; }

        // Status & Equipment
        public AircraftStatus Status { get; set; }
        public OptionalEquipment Equipment { get; set; } = OptionalEquipment.None;
        }
    }
