namespace AirTrack.Server.Models.Aircraft;

[Flags]
public enum OptionalEquipment
    {
    None = 0,
    IFR = 1,
    GPS = 2,
    Autopilot = 4,
    LongRangeTanks = 8,
    WheelPants = 16,
    Floats = 32,
    BannerTowHook = 64,
    STOLKit = 128,
    TundraTires = 256,
    EnginePreheater = 512
    }

