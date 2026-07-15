using AirTrack.Server.Data;
using AirTrack.Server.Models.Aircraft;
using AirTrack.Server.Models.FormModel;
using AirTrack.Server.Models.Scheduler;

using System.ComponentModel.DataAnnotations.Schema;

namespace AirTrack.Server.Models.Aircraft;

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

    public void ApplyFrom(AircraftFormModel form)
        {
        TailNumber = form.TailNumber;
        Model = form.Model;
        Year = form.Year;
        EngineType = form.EngineType;
        FuelType = form.FuelType;
        Seats = form.Seats;
        Notes = form.Notes;
        Hobbs = form.Hobbs;
        Tach = form.Tach;
        AnnualDueDate = form.AnnualDueDate;
        Status = form.Status;
        Equipment = form.Equipment;
        }
    public bool IsMaintenanceDue(DateTime now)
        {
        var hobbs = Hobbs;

        switch (this)
            {
            case CessnaSkyhawk s:
                if (hobbs >= s.LastOilChange + 50) return true;
                if (hobbs >= s.Last50Hr + 50) return true;
                if (hobbs >= s.Last100Hr + 100) return true;

                if (s.ELTInspectionDue is not null && s.ELTInspectionDue <= now) return true;
                if (s.TransponderDue is not null && s.TransponderDue <= now) return true;
                if (s.PitotStaticDue is not null && s.PitotStaticDue <= now) return true;

                return false;

            case PiperArrow pa:
                if (hobbs >= pa.LastOilChange + 50) return true;
                if (hobbs >= pa.Last100Hr + 100) return true;

                if (pa.LastGearCyclesInspection >= 200) return true;

                if (pa.PropOverhaulDue is not null && pa.PropOverhaulDue <= now) return true;

                return false;

            case PiperSeminole ps:
                if (hobbs >= ps.LastLeftEngineHobbs + 50) return true;
                if (hobbs >= ps.LastRightEngineHobbs + 50) return true;
                if (hobbs >= ps.Last100Hr + 100) return true;

                if (ps.LastGearCyclesInspection >= 200) return true;

                if (ps.LeftPropOverhaulDue is not null && ps.LeftPropOverhaulDue <= now) return true;
                if (ps.RightPropOverhaulDue is not null && ps.RightPropOverhaulDue <= now) return true;

                return false;

            case RobinsonR44 r:
                if (hobbs >= r.Last2200HrOverhaul + 2200) return true;

                if (r.BladeLifeRemaining <= 0) return true;

                if (r.ClutchActuationCount >= 200) return true;

                if (r.GovernorInspectionDue is not null && r.GovernorInspectionDue <= now) return true;

                return false;

            default:
                return false;
            }
        }

    
    public AircraftStatus CalculateStatus(IReadOnlyList<FlightEvent> events,bool hasGroundingSquawk)
        {
        var now = TimeHelper.PacificNow;

        if (hasGroundingSquawk)
            return AircraftStatus.Maintenance;

        if (IsMaintenanceDue(now))
            return AircraftStatus.Maintenance;

        var active = events.FirstOrDefault(e =>
            e.AircraftId == Id &&
            e.Start <= now &&
            e.End >= now);

        if (active is not null)
            {
            CurrentFlightStart = active.Start;

            var next = events.FirstOrDefault(e => e.AircraftId == Id && e.Start > now);
            NextBookingStart = next?.Start;
            NextBookingEnd = next?.End;

            return AircraftStatus.InFlight;
            }

        var future = events.FirstOrDefault(e =>
            e.AircraftId == Id &&
            e.Start > now);

        if (future is not null)
            {
            NextBookingStart = future.Start;
            NextBookingEnd = future.End;

            return AircraftStatus.Scheduled;
            }

        return AircraftStatus.Available;
        }

    public async Task RefreshOperationalStateAsync(DbHelper db, IReadOnlyList<FlightEvent> events)
        {
        SquawkCount = await db.GetOpenSquawksCount(Id);
        var hasGroundingSquawk = await db.AircraftHasGroundingSquawk(Id);

        Status = CalculateStatus(events, hasGroundingSquawk);
        }

    public async Task RefreshSquawksAsync(DbHelper db)
        {
        SquawkCount = await db.GetOpenSquawksCount(Id);
        }







    }

