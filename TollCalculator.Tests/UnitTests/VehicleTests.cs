using TollCalculator.Vehicles;

namespace TollCalculator.Tests.UnitTests;

public class VehicleTests
{

    [TestCase("Motorbike", true)]
    [TestCase("Tractor", true)]
    [TestCase("EmergencyVehicle", true)]
    [TestCase("DiplomaticVehicle", true)]
    [TestCase("ForeignVehicle", true)]
    [TestCase("MilitaryVehicle", true)]
    [TestCase("Car", false)]
    public void IsTollFreeVehicle_ReturnsExpected_ForVehicleType(string vehicleType, bool expected)
    {
        var vehicle = Create(vehicleType);

        Assert.That(vehicle.IsTollFree(), Is.EqualTo(expected));
    }
    
    private static IVehicle Create(string vehicleType) => vehicleType switch
    {
        "Car" => new Car(),
        "Motorbike" => new Motorbike(),
        "Tractor" => new Tractor(),
        "EmergencyVehicle" => new EmergencyVehicle(),
        "DiplomaticVehicle" => new DiplomaticVehicle(),
        "ForeignVehicle" => new ForeignVehicle(),
        "MilitaryVehicle" => new MilitaryVehicle(),
        _ => throw new ArgumentException($"Unknown vehicle type: {vehicleType}", nameof(vehicleType))
    };
}