using System.Collections.Generic;
using NUnit.Framework;
using RobotCleaner.App.Infrastructure.Contracts;
using RobotCleaner.App.Infrastructure.Factory;
using RobotCleaner.App.Infrastructure.Models;

namespace RobotCleaner.UnitTests
{
    [TestFixture]
    public class RobotTests : TestBase
    {
        private IRobot _robot;


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Robot_StartCleaning_ShouldReportCleanedPositions()
        {
            // Arrange
            var commands = new List<string>() { "E 2", "N 1" };
            var inputs = new InputsModel
            {
                StartingPosition = "10 22",
                Commands = commands
            };
            _robot = RobotFactory.CreateRobot(inputs, MinCoordinate, MaxCoordinate);

            // Act
            _robot.StartCleaning();
            // Assert
            var actual = _robot.CleanedPositions;
            var expected = "Cleaned: 4";
            Assert.That(expected, Is.EqualTo(actual));
            Assert.That(actual, Does.EndWith("4"));

        }
    }
}