using Fahrtenbuch_Backend;
namespace TestBackend;

public class UnitTest1
{
    [Fact]
    public void CreateJourney()
    {
        Journey test = new Journey("Burak", "Desc1", DateTime.Today, DateTime.Today.AddDays(1), 5);

        Assert.Equal("Burak", test.Driver);
        Assert.Equal("Desc1", test.Description);
        Assert.Equal(DateTime.Today.ToString(), test.Start.ToString());
        Assert.Equal(DateTime.Today.AddDays(1).ToString(), test.End.ToString());
        Assert.Equal(5, test.Distance);

    }

    [Fact]
    public void GetTotalDistance()
    {
        Journey test = new Journey("Burak", "Desc1", DateTime.Today, DateTime.Today.AddDays(1), 5);
        Journey test2 = new Journey("Burak", "Desc1", DateTime.Today, DateTime.Today.AddDays(1), 5);
        Journey test3 = new Journey("Burak", "Desc1", DateTime.Today, DateTime.Today.AddDays(1), 5);
        List<Journey> testList = new List<Journey>();
        testList.Add(test);
        testList.Add(test2);
        testList.Add(test3);
        Logbook log = new Logbook(testList);


        Assert.Equal(15, log.DistanceTotal);

    }
}
