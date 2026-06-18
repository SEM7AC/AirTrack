using AirTrack.Server.Model.Aircraft;

public class RobinsonR44 : AircraftBase
    {
    public decimal HoursSince2200HrOverhaul {  get; set; }
    public decimal BladeLifeRemaining { get; set; }
    public int ClutchActuationCount { get; set; }
    public DateTime? GovernorInspectionDue { get; set; }

    public List<RecurringAD> RecurringADs { get; set; } = new();
    
}
