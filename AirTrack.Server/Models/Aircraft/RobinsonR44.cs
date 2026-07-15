using AirTrack.Server.Models.Aircraft;

public class RobinsonR44 : AircraftBase
    {
    public decimal Last2200HrOverhaul { get; set; }
    public decimal BladeLifeRemaining { get; set; }
    public int ClutchActuationCount { get; set; }
    public DateTime? GovernorInspectionDue { get; set; }

    }
