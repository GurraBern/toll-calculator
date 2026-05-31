namespace TollCalculator.Tests.UnitTests;

public class TollFeeScheduleTests
{
    //TODO lägg in fler edge cases!!!!!
    [TestCase(5, 59, 0)]
    [TestCase(6, 1, 8)]
    [TestCase(6, 28, 8)]
    [TestCase(6, 31, 13)]
    [TestCase(6, 58, 13)]
    [TestCase(7, 1, 18)]
    [TestCase(7, 58, 18)]
    [TestCase(8, 1, 13)]
    [TestCase(8, 28, 13)]
    [TestCase(8, 31, 8)]
    [TestCase(8, 59, 8)]
    [TestCase(9, 0, 8)]
    [TestCase(9, 59, 8)]
    [TestCase(10, 0, 8)]
    [TestCase(10, 59, 8)]
    [TestCase(11, 0, 8)]
    [TestCase(11, 59, 8)]
    [TestCase(12, 0, 8)]
    [TestCase(12, 59, 8)]
    [TestCase(13, 0, 8)]
    [TestCase(13, 59, 8)]
    [TestCase(14, 0, 8)]
    [TestCase(14, 59, 8)]
    [TestCase(15, 1, 13)]
    [TestCase(15, 28, 13)]
    [TestCase(15, 31, 18)]
    [TestCase(15, 59, 18)]
    [TestCase(16, 0, 18)]
    [TestCase(16, 1, 18)]
    [TestCase(16, 58, 18)]
    [TestCase(17, 1, 13)]
    [TestCase(17, 58, 13)]
    public void GetTollFee_When_Given_Specific_Time_Returns_Expected_Fee(int hour, int minute, int expectedFee)
    {
        var time = new TimeOnly(hour, minute, 1);

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