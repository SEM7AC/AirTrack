public static class TimeHelper
    {
    private static readonly TimeZoneInfo Pacific =
        TimeZoneInfo.FindSystemTimeZoneById("America/Los_Angeles");

    public static DateTime PacificNow =>
        TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Pacific);

    public static DateTime PacificToday =>
        PacificNow.Date;

    public static DateTime ToPacific(DateTime utc) =>
        TimeZoneInfo.ConvertTimeFromUtc(utc, Pacific);

    public static DateTime ToUtc(DateTime pacific) =>
        TimeZoneInfo.ConvertTimeToUtc(pacific, Pacific);
    }
