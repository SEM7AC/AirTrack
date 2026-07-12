using AirTrack.Server.Models.Aircraft;
using Xunit;

public class MaintenanceTests
    {
    [Fact]
    public void CessnaSkyhawk_IsMaintenanceDue_WhenOilChangeExceeded()
        {
        // arrange
        var ac = new CessnaSkyhawk
            {
            Hobbs = 160,
            LastOilChange = 100,
            Last50Hr = 150,
            Last100Hr = 100
            };

        // act
        var result = ac.IsMaintenanceDue(DateTime.Now);

        // assert
        Assert.True(result);
        }
    }
