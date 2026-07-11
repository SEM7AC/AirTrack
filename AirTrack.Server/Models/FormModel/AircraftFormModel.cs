using AirTrack.Server.Models.Aircraft;

namespace AirTrack.Server.Models.FormModel;

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

    public static AircraftFormModel CreateNew()
        {
        return new AircraftFormModel
            {
            AnnualDueDate = DateTime.Today,
            Status = AircraftStatus.Available,
            Equipment = OptionalEquipment.None
            };
        }

    public void ApplyNormalization()
        {
        TailNumber = TailNumber?.Trim() ?? "";
        EngineType = EngineType?.Trim() ?? "";
        FuelType = FuelType?.Trim() ?? "";
        Notes = Notes?.Trim() ?? "";
        }

    public void CloneFrom(AircraftBase source)
        {
        TailNumber = source.TailNumber;
        Model = source.Model;
        Year = source.Year;
        EngineType = source.EngineType;
        FuelType = source.FuelType;
        Seats = source.Seats;
        Notes = source.Notes;
        Hobbs = source.Hobbs;
        Tach = source.Tach;
        AnnualDueDate = source.AnnualDueDate;
        Status = source.Status;
        Equipment = source.Equipment;
        }

    public void ApplyTo(AircraftBase target)
        {
        target.TailNumber = TailNumber;
        target.Model = Model;
        target.Year = Year;
        target.EngineType = EngineType;
        target.FuelType = FuelType;
        target.Seats = Seats;
        target.Notes = Notes;
        target.Hobbs = Hobbs;
        target.Tach = Tach;
        target.AnnualDueDate = AnnualDueDate;
        target.Status = Status;
        target.Equipment = Equipment;
        }

    }

