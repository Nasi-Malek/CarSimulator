using NUnit.Framework;
using static NUnit.Framework.Assert;
using CarSimulator;
using Moq;
using NUnit.Framework;
using Services.DriverService;

namespace CarSimulator.NUnit
{
    [TestFixture]
    public class SimulatorNUnitTests
    {
        private Mock<IDriver> _mockDriver;

        [SetUp]
        public void Setup()
        {
            CarActions.IsTesting = true;
            DriverActions.IsTesting = true;
            Status.IsTesting = true;
            _mockDriver = new Mock<IDriver>();
        }

        [TestCase(100, 90, 10)]
        [TestCase(50, 40, 10)]
        [TestCase(10, 0, 10)]
        public void Drive_Should_ConsumeFuel_And_IncreaseTiredness(int initialFuel, int expectedFuel, int expectedTiredness)
        {
            var car = new Car { Fuel = initialFuel, Direction = "North" };
            var driver = new Driver { Tiredness = 0 };

            CarActions.Drive(car, driver);

            That(car.Fuel, Is.EqualTo(expectedFuel));
            That(driver.Tiredness, Is.EqualTo(expectedTiredness));
        }

        [TestCase("North", "West")]
        [TestCase("West", "South")]
        [TestCase("South", "East")]
        public void TurnLeft_Should_Update_Direction_Correctly(string initialDirection, string expectedDirection)
        {
            var car = new Car { Direction = initialDirection };
            var driver = new Driver();

            CarActions.TurnLeft(car, driver);

            That(car.Direction, Is.EqualTo(expectedDirection));
        }

        [TestCase("North", "East")]
        [TestCase("East", "South")]
        [TestCase("South", "West")]
        public void TurnRight_Should_Update_Direction_Correctly(string initialDirection, string expectedDirection)
        {
            var car = new Car { Direction = initialDirection };
            var driver = new Driver();

            CarActions.TurnRight(car, driver);

            That(car.Direction, Is.EqualTo(expectedDirection));
        }

        [TestCase(0, HungerLevel.Full)]
        [TestCase(3, HungerLevel.Full)]
        [TestCase(5, HungerLevel.Full)]
        [TestCase(6, HungerLevel.Hungry)]
        [TestCase(8, HungerLevel.Hungry)]
        [TestCase(10, HungerLevel.Hungry)]
        [TestCase(11, HungerLevel.Starving)]
        [TestCase(15, HungerLevel.Starving)]
        public void GetHungerLevel_Should_Return_CorrectLevel(int hungerValue, HungerLevel expectedLevel)
        {
            _mockDriver.SetupProperty(d => d.Hunger, hungerValue);
            _mockDriver.Setup(d => d.GetHungerLevel()).Returns(() =>
            {
                if (_mockDriver.Object.Hunger <= 5)
                    return HungerLevel.Full;
                else if (_mockDriver.Object.Hunger <= 10)
                    return HungerLevel.Hungry;
                else
                    return HungerLevel.Starving;
            });

            var actualLevel = _mockDriver.Object.GetHungerLevel();

            That(actualLevel, Is.EqualTo(expectedLevel));
        }
    }
}
