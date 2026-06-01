using PublicHoliday;

namespace TollCalculator;

public class ExternalHolidayProvider(IPublicHolidays holidays) : IHolidayProvider
{
    public bool IsHoliday(DateTime date) => holidays.IsPublicHoliday(date);
}