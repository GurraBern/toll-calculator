namespace TollCalculator.Tests.UnitTests;

public class TollFeeScheduleTests
{
    [TestCase(0, 0, 0, 0)]
    [TestCase(5, 59, 59, 0)]
    [TestCase(6, 0, 0, 8)]
    [TestCase(6, 29, 59, 8)]
    [TestCase(6, 30, 0, 13)]
    [TestCase(6, 59, 59, 13)]
    [TestCase(7, 0, 0, 18)]
    [TestCase(7, 59, 59, 18)]
    [TestCase(8, 0, 0, 13)]
    [TestCase(8, 29, 59, 13)]
    [TestCase(8, 30, 0, 8)]
    [TestCase(14, 59, 59, 8)]
    [TestCase(15, 0, 0, 13)]
    [TestCase(15, 29, 59, 13)]
    [TestCase(15, 30, 0, 18)]
    [TestCase(16, 59, 59, 18)]
    [TestCase(17, 0, 0, 13)]
    [TestCase(17, 59, 59, 13)]
    [TestCase(18, 0, 0, 8)]
    [TestCase(18, 29, 59, 8)]
    [TestCase(18, 30, 0, 0)]
    [TestCase(23, 59, 59, 0)]
    public void GetTollFee_When_Given_Specific_Time_Returns_Expected_Fee(int hour, int minute, int second, int expectedFee)
    {
        var time = new TimeOnly(hour, minute, second);

        var fee = TollFeeSchedule.GetTollFee(time);

        Assert.That(fee, Is.EqualTo(expectedFee));
    }
    
    [TestCase(DayOfWeek.Monday)]
    [TestCase(DayOfWeek.Tuesday)]
    [TestCase(DayOfWeek.Wednesday)]
    [TestCase(DayOfWeek.Thursday)]
    [TestCase(DayOfWeek.Friday)]
    public void IsWeekend_ReturnsFalse_For_Week_days(DayOfWeek dayOfWeek)
    {
        Assert.That(TollFeeSchedule.IsWeekend(dayOfWeek), Is.False);
    }
    
    [TestCase(DayOfWeek.Saturday)]
    [TestCase(DayOfWeek.Sunday)]
    public void IsWeekend_Returns_True_For_Weekend_Days(DayOfWeek dayOfWeek)
    {
        Assert.That(TollFeeSchedule.IsWeekend(dayOfWeek), Is.True);
    }
}