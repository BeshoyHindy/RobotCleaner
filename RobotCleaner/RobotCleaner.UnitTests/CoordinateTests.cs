using System.Collections.Generic;
using NUnit.Framework;
using RobotCleaner.App.Infrastructure;
using RobotCleaner.App.Infrastructure.Contracts;
using RobotCleaner.App.Infrastructure.Factory;
using RobotCleaner.App.Infrastructure.Models;

namespace RobotCleaner.UnitTests
{
    [TestFixture]
    public class CoordinateTests : TestBase
    {

        private Coordinate _coordinate;

        [SetUp]
        public void Setup()
        {
            _coordinate = Coordinate.CreateInstance(0,0);
        }

        [Test]
        public void Coordinate_MoveStepToEast()
        {
            // Arrange
            //Coordinate is on (0,0)

            // Act
            _coordinate.MoveStepToEast();

            // Assert
            var actual = _coordinate;
            var expected = Coordinate.CreateInstance(1, 0);

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Coordinate_MoveStepToWest()
        {
            // Arrange
            //Coordinate is on (0,0)

            // Act
            _coordinate.MoveStepToWest();

            // Assert
            var actual = _coordinate;
            var expected = Coordinate.CreateInstance(-1, 0);

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Coordinate_MoveStepToNorth()
        {
            // Arrange
            //Coordinate is on (0,0)

            // Act
            _coordinate.MoveStepToNorth();

            // Assert
            var actual = _coordinate;
            var expected = Coordinate.CreateInstance(0, 1);

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void Coordinate_MoveStepToSouth()
        {
            // Arrange
            //Coordinate is on (0,0)

            // Act
            _coordinate.MoveStepToSouth();

            // Assert
            var actual = _coordinate;
            var expected = Coordinate.CreateInstance(0, -1);

            Assert.That(actual, Is.EqualTo(expected));

        }

    }
}