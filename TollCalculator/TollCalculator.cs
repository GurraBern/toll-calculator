using TollCalculator.Vehicles;

namespace TollCalculator;

//TODO this class has too much responsiblity 
public static class TollCalculator
{

    /**
     * Calculate the total toll fee for one day
     *
     * @param vehicle - the vehicle
     * @param dates   - date and time of all passes on one day
     * @return - the total toll fee for that day
     */

    //TODO rewrite
    public static int GetTollFee(IVehicle vehicle, DateTime[] dates)
    {
        DateTime intervalStart = dates[0];
        int totalFee = 0;
        foreach (DateTime date in dates)
        {
            int nextFee = GetTollFee(vehicle, date);
            int tempFee = GetTollFee(vehicle, intervalStart);

            long diffInMillies = date.Millisecond - intervalStart.Millisecond;
            long minutes = diffInMillies/1000/60;

            if (minutes <= 60)
            {
                if (totalFee > 0) totalFee -= tempFee;
                if (nextFee >= tempFee) tempFee = nextFee;
                totalFee += tempFee;
            }
            else
            {
                totalFee += nextFee;
            }
        }
        if (totalFee > 60) totalFee = 60;
        return totalFee;
    }
    
    private static int GetTollFee(IVehicle vehicle, DateTime date)
    {
        if (TollFeeSchedule.IsTollFreeDate(date)) 
            return 0;
        
        if (vehicle.IsTollFree()) 
            return 0;

        var time = TimeOnly.FromDateTime(date);
        return TollFeeSchedule.GetTollFee(time);
    }
}