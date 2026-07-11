namespace AirTrack.Server.Models.Aircraft;

public class PiperSeminole : AircraftBase
    {
    public decimal LastLeftEngineHobbs { get; set; }
    public decimal LastRightEngineHobbs { get; set; }

    public decimal Last100Hr {  get; set; }
    public DateTime? LeftPropOverhaulDue { get; set; }
    public DateTime? RightPropOverhaulDue { get; set; }
    public int LastGearCyclesInspection { get; set; }

    
    }

