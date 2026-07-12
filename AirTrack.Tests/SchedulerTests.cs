using AirTrack.Server.Models.Aircraft;
using AirTrack.Server.Models.Scheduler;
using Xunit;

public class StatusTests
    {
    [Fact]
    public void Aircraft_IsScheduled_WhenFutureEventExists()
        {
        // arrange
        var ac = new CessnaSkyhawk { Id = 1 };

        var events = new List<FlightEvent>
        {
            new FlightEvent
            {
                AircraftId = 1,
                Start = DateTime.Now.AddHours(2),
                End = DateTime.Now.AddHours(3)
            }
        };

        // act
        var status = ac.CalculateStatus(events, hasGroundingSquawk: false);

        // assert
        Assert.Equal(AircraftStatus.Scheduled, status);
        }
    }
