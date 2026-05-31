namespace TollCalculator;

public interface IHolidayProvider
{
    bool IsHoliday(DateTime date);
}