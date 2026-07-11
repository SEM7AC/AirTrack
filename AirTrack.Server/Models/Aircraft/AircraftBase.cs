using AirTrack.Server.Models.Aircraft;
using AirTrack.Server.Models.FormModel;

using System.ComponentModel.DataAnnotations.Schema;

namespace AirTrack.Server.Models.Aircraft
    {
    public enum AircraftStatus
        {
        Available,
        InFlight,
        Scheduled,
        Maintenance
        }

    public abstract class AircraftBase
        {
        // EF Core Identity
        public int Id { get; set; }

        // Identity / Configuration
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
        public int SquawkCount { get; set; }

        // Status & Equipment
        [NotMapped]
        public AircraftStatus Status { get; set; }

        public OptionalEquipment Equipment { get; set; }

        // Current Flight (runtime)
        [NotMapped]
        public string CurrentStudent { get; set; } = string.Empty;
        [NotMapped]
        public string CurrentInstructor { get; set; } = string.Empty;
        [NotMapped]
        public DateTime? CurrentFlightStart { get; set; }

        // Scheduling (runtime)
        [NotMapped]
        public DateTime? NextBookingStart { get; set; }
        [NotMapped]
        public DateTime? NextBookingEnd { get; set; }

        //Moved Logic from UI
        public bool MatchesSearch(string? text)
            {
            if (string.IsNullOrWhiteSpace(text))
                return true;

            var modelName = Model.GetDescription();

            return TailNumber.Contains(text, StringComparison.OrdinalIgnoreCase)
                || modelName.Contains(text, StringComparison.OrdinalIgnoreCase);
            }


        public void AddEquipment(OptionalEquipment value)
            {
            Equipment |= value;
            }

        public void RemoveEquipment(OptionalEquipment value)
            {
            Equipment &= ~value;
            }

        public void UpdateFrom(AircraftFormModel model)
            {
            TailNumber = model.TailNumber;
            Model = model.Model;
            Year = model.Year;
            EngineType = model.EngineType;
            FuelType = model.FuelType;
            Seats = model.Seats;
            Notes = model.Notes;
            Hobbs = model.Hobbs;
            Tach = model.Tach;
            AnnualDueDate = model.AnnualDueDate;
            Status = model.Status;
            Equipment = model.Equipment;
            }





        }
    }
