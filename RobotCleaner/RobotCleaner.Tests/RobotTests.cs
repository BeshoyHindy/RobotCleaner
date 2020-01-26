using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotCleaner.App.Infrastructure;
using RobotCleaner.App.Infrastructure.Contracts;
using RobotCleaner.App.Infrastructure.Factory;
using RobotCleaner.App.Infrastructure.Models;

namespace RobotCleaner.Tests
{
    [TestClass]
    public class RobotTests : TestsBase
    {
        private IRobot _robot;
        private static Coordinate _minCoordinate;
        private static Coordinate _maxCoordinate;


        [ClassInitialize]
        public static void BeforeAllTests(TestContext context)
        {
            _minCoordinate = Coordinate.CreateInstance(-100_000, -100_000);
            _maxCoordinate = Coordinate.CreateInstance(100_000, 100_000);
        }

        [TestInitialize]
        public void BeforeEachTest()
        {


        }


        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var commands = new List<string>() { "E 2", "N 1" };
            var inputs = new InputsModel
            {
                StartingPosition = "10 22",
                Commands = commands
            };
            _robot = RobotFactory.CreateRobot(inputs, _minCoordinate, _maxCoordinate);

            // Act
            _robot.StartCleaning();
            // Assert
            string actual = _robot.CleanedPositions;
            string expected = "Cleaned: 4";
            Assert.AreEqual(expected, actual);

        }
    }
}
