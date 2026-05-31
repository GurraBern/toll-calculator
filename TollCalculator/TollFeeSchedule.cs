namespace TollCalculator;

public static class TollFeeSchedule
{
    private static readonly (TimeOnly Start, TimeOnly End, int Fee)[] FeeSchedule =
    [
        (new TimeOnly(6, 0),   new TimeOnly(6, 30),   8),
        (new TimeOnly(6, 30),  new TimeOnly(7, 0),   13),
        (new TimeOnly(7, 0),   new TimeOnly(8, 0),   18),
        (new TimeOnly(8, 0),   new TimeOnly(8, 30),  13),
        (new TimeOnly(8, 30),  new TimeOnly(15, 0),   8),
        (new TimeOnly(15, 0),  new TimeOnly(15, 30), 13),
        (new TimeOnly(15, 30), new TimeOnly(17, 0),  18),
        (new TimeOnly(17, 0),  new TimeOnly(18, 0),  13),
        (new TimeOnly(18, 0),  new TimeOnly(18, 30),  8)
    ];
    
    public static int GetTollFee(TimeOnly time)
    {
        foreach (var (start, end, fee) in FeeSchedule)
        {
            if (time >= start && time < end) 
                return fee;
        }
        
        return 0;
    }
    
    public static bool IsTollFreeDate(DateTime date)
    {
        if (IsWeekend(date.DayOfWeek)) 
            return true;

        if (IsHoliday(date))
            return true;
        
        return false;
    }
    
    //TODO nuget for holiday dates
    private static bool IsHoliday(DateTime date)
    {
        int year = date.Year;
        int month = date.Month;
        int day = date.Day;

        if (year == 2013)
        {
            if (month == 1 && day == 1 ||
                month == 3 && (day == 28 || day == 29) ||
                month == 4 && (day == 1 || day == 30) ||
                month == 5 && (day == 1 || day == 8 || day == 9) ||
                month == 6 && (day is 5 or 6 || day == 21) ||
                month == 7 ||
                month == 11 && day == 1 ||
                month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
            {
                return true;
            }
        }
        
        return false;
    }
    
    public static bool IsWeekend(DayOfWeek dayOfWeek) => dayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;
}