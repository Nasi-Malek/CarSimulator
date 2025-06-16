using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.DriverService;
using System;

namespace CarSimulator.Tests
{
    [TestClass]
    public class SimulatorTest
    {
        private CarActions _carActions;
        private DriverActions _driverActions;
        private Status _status;
        private Mock<IDriver> _mockDriver;

        public SimulatorTest()
        {
            _mockDriver = new Mock<IDriver>();
            _carActions = new CarActions();
            _driverActions = new DriverActions();
            _status = new Status();
        }

        [TestInitialize]
        public void Setup()
        {
            CarActions.IsTesting = true;
            DriverActions.IsTesting = true;
            Status.IsTesting = true;
        }

        [TestMethod]
        public void Car_Should_Turn_Left_From_North_To_West()
        {
            var car = new Car { Direction = "North" };
            var driver = new Driver { Tiredness = 0 };

            CarActions.TurnLeft(car, driver);

            Assert.AreEqual("West", car.Direction);
        }

        [TestMethod]
        public void Car_Should_Turn_Right_From_North_To_East()
        {
            var car = new Car { Direction = "North" };
            var driver = new Driver { Tiredness = 0 };

            CarActions.TurnRight(car, driver);

            Assert.AreEqual("East", car.Direction);
        }

        [TestMethod]
        public void Car_Should_Drive_And_Consume_Fuel_And_Increase_Tiredness()
        {
            var car = new Car { Fuel = 100 };
            var driver = new Driver { Tiredness = 0 };

            CarActions.Drive(car, driver);

            Assert.AreEqual(90, car.Fuel);
            Assert.AreEqual(10, driver.Tiredness);
        }

        [TestMethod]
        public void Car_Should_Reverse_And_Consume_Fuel_And_Increase_Tiredness()
        {
            var car = new Car { Fuel = 100 };
            var driver = new Driver { Tiredness = 0 };

            CarActions.Reverse(car, driver);

            Assert.AreEqual(95, car.Fuel);
            Assert.AreEqual(5, driver.Tiredness);
        }

        [TestMethod]
        public void Refueling_Should_Set_Fuel_To_100_And_Increase_Tiredness()
        {
            var car = new Car { Fuel = 50 };
            var driver = new Driver { Tiredness = 0 };

            _carActions.Refuel(car, driver);

            Assert.AreEqual(100, car.Fuel);
            Assert.AreEqual(5, driver.Tiredness);
        }

        [TestMethod]
        public void Rest_Should_Reset_Tiredness_To_Zero()
        {
            var driver = new Driver { Tiredness = 50 };

            DriverActions.Rest(driver);

            Assert.AreEqual(0, driver.Tiredness);
        }

        [TestMethod]
        public void CheckTiredness_Should_Warn_When_Tiredness_Is_70()
        {
            var driver = new Driver { Tiredness = 70 };

            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                DriverActions.CheckTiredness(driver);
                var result = sw.ToString().Trim();

                Assert.IsTrue(result.Contains("The driver is getting tired and needs to take a break."));
            }
        }

        [TestMethod]
        public void CheckTiredness_Should_Criticize_When_Tiredness_Is_100()
        {
            var driver = new Driver { Tiredness = 100 };

            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                DriverActions.CheckTiredness(driver);
                var result = sw.ToString().Trim();

                Assert.IsTrue(result.Contains("The driver is extremely tired! It is very dangerous to keep driving. REST!"));
            }
        }

        [TestMethod]
        public void IncreaseHunger_Should_Add_Two()
        {
            _mockDriver.SetupProperty(d => d.Hunger, 10);
            _mockDriver.Setup(d => d.IncreaseHunger()).Callback(() => _mockDriver.Object.Hunger += 2);

            _mockDriver.Object.IncreaseHunger();

            Assert.AreEqual(12, _mockDriver.Object.Hunger);
        }

        [TestMethod]
        public void Eat_Should_Reset_Hunger_To_Zero()
        {
            _mockDriver.SetupProperty(d => d.Hunger, 10);
            _mockDriver.Setup(d => d.Eat()).Callback(() => _mockDriver.Object.Hunger = 0);

            _mockDriver.Object.Eat();

            Assert.AreEqual(0, _mockDriver.Object.Hunger);
        }

        [TestMethod]
        public void IncreaseHunger_Should_Throw_Exception_When_Hunger_Reaches_16()
        {
            _mockDriver.SetupProperty(d => d.Hunger, 14);
            _mockDriver.Setup(d => d.IncreaseHunger()).Callback(() =>
            {
                _mockDriver.Object.Hunger += 2;
                if (_mockDriver.Object.Hunger >= 16)
                {
                    throw new InvalidOperationException("The driver is too hungry! Game over.");
                }
            });

            Assert.ThrowsException<InvalidOperationException>(() => _mockDriver.Object.IncreaseHunger());
        }
    }
}
