using TollCalculator.Vehicles;

namespace TollCalculator;

public class TollCalculator(TollFeeSchedule tollFeeSchedule)
{
    private const int MaxTotalFeePerDay = 60;

    //TODO rewrite so we can handle more than 24 hours!!!
    public int GetTollFee(IVehicle vehicle, DateTime[] dates)
    {
        if (dates.Length == 0)
            return 0;

        var timeStamps = dates
            .OrderBy(x => x.Date)
            .ToList();

        var totalFee = 0;
        var currentIntervalTimestamps = new List<DateTime>();
        var intervalStart = timeStamps.First();

        foreach (var timestamp in timeStamps)
        {
            currentIntervalTimestamps.Add(timestamp);

            var minutesPassed = (timestamp - intervalStart).TotalMinutes;
            if ((minutesPassed >= 60) is false)
                continue;

            totalFee += GetHighestTollFee(vehicle, currentIntervalTimestamps);

            currentIntervalTimestamps.Clear();
            intervalStart = timestamp;
        }

        if (currentIntervalTimestamps.Count > 0)
            totalFee += GetHighestTollFee(vehicle, currentIntervalTimestamps);

        return Math.Min(totalFee, MaxTotalFeePerDay);//TODO create a method for getting total Per day so that we can support multiday!!!!
    }

    private int GetHighestTollFee(IVehicle vehicle, List<DateTime> timestamps)
    {
        var tollFees = timestamps
            .Select(date => GetTollFee(vehicle, date))
            .ToList();

        return tollFees.Max();//TODO borde vi checka att listan inte är tom?
    }

    public int GetTollFee(IVehicle vehicle, DateTime date)
    {
        if (tollFeeSchedule.IsTollFreeDate(date))
            return 0;

        if (vehicle.IsTollFree())
            return 0;

        var time = TimeOnly.FromDateTime(date);
        return TollFeeSchedule.GetTollFee(time);
    }
}