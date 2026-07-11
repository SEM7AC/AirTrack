using System.ComponentModel;

namespace AirTrack.Server.Models.Aircraft
    {
    public enum AircraftModel
        {
        [Description("Cessna 172 Skyhawk")]
        Cessna172Skyhawk,
        [Description("Piper PA-28R Arrow")]
        PiperPA28RArrow,
        [Description("Piper PA-44 Seminole")]
        PiperPA44Seminole,
        [Description("Robinson R44")]
        RobinsonR44,
        [Description("Generic Aircraft")]
        Generic
        }
    }
