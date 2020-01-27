using System.Collections.Generic;
using NUnit.Framework;
using RobotCleaner.App.Infrastructure;
using RobotCleaner.App.Infrastructure.Contracts;
using RobotCleaner.App.Infrastructure.Factory;
using RobotCleaner.App.Infrastructure.Models;

namespace RobotCleaner.UnitTests
{
    [TestFixture]
    public class RobotEngineTests : TestBase
    {
        private IRobotEngine _robotEngine;


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RunEngine_ShouldCleanCommands()
        {
            // Arrange
            var statingPosition = Coordinate.CreateInstance(10, 22);
            var movements = new List<IMovement>
            {
                new Movement(Direction.East, 2),
                new Movement(Direction.North, 1)
            };
            _robotEngine = RobotEngineFactory.CreateRobotEngine(statingPosition, movements, MinCoordinate, MaxCoordinate);

            // Act
            _robotEngine.RunEngine();

            // Assert
            var actual = _robotEngine.CleanedPositions;
            var expected = new HashSet<Coordinate>
            {
                Coordinate.CreateInstance(10, 22),
                Coordinate.CreateInstance(11, 22),
                Coordinate.CreateInstance(12, 22),
                Coordinate.CreateInstance(12, 23)
            };

            Assert.That(actual, Is.EquivalentTo(expected));

        }


        [Test]
        public void RunEngine_ShouldCleanUniquePositions()
        {
            // Arrange
            var statingPosition = Coordinate.CreateInstance(1, 1);
            var movements = new List<IMovement>
            {
                new Movement(Direction.East, 1),
                new Movement(Direction.North, 1),
                new Movement(Direction.West, 1),
                new Movement(Direction.South, 1),
                new Movement(Direction.East, 1),
                new Movement(Direction.North, 1),
                new Movement(Direction.West, 1),
                new Movement(Direction.South, 1),

            };
            _robotEngine = RobotEngineFactory.CreateRobotEngine(statingPosition, movements, MinCoordinate, MaxCoordinate);

            // Act
            _robotEngine.RunEngine();

            // Assert
            var actual = _robotEngine.CleanedPositions;
            var expected = new HashSet<Coordinate>
            {
                Coordinate.CreateInstance(1, 1),
                Coordinate.CreateInstance(1, 2),
                Coordinate.CreateInstance(2, 2),
                Coordinate.CreateInstance(2, 1),

            };

            Assert.That(actual, Is.EquivalentTo(expected));

        }


        [Test]
        [TestCase(100_000, 100_000, Direction.East, 1, 100_000, 100_000)]
        [TestCase(100_000, 100_000, Direction.North, 1, 100_000, 100_000)]
        [TestCase(-100_000, 100_000, Direction.West, 1, -100_000, 100_000)]
        [TestCase(-100_000, 100_000, Direction.North, 1, -100_000, 100_000)]
        [TestCase(100_000, -100_000, Direction.East, 1, 100_000, -100_000)]
        [TestCase(100_000, -100_000, Direction.South, 1, 100_000, -100_000)]
        [TestCase(-100_000, -100_000, Direction.West, 1, -100_000, -100_000)]
        [TestCase(-100_000, -100_000, Direction.South, 1, -100_000, -100_000)]
        public void RunEngine_MoveToBorders(int xCoordinate, int yCoordinate, Direction direction, int steps, int expectedX, int expectedY)
        {
            // Arrange
            var statingPosition = Coordinate.CreateInstance(xCoordinate, yCoordinate);
            var movements = new List<IMovement>
            {
                new Movement(direction, steps),
            };
            _robotEngine = RobotEngineFactory.CreateRobotEngine(statingPosition, movements, MinCoordinate, MaxCoordinate);

            // Act
            _robotEngine.RunEngine();

            // Assert
            var actual = _robotEngine.CleanedPositions;
            var expected = new HashSet<Coordinate>
            {
                Coordinate.CreateInstance(expectedX, expectedY)
            };

            Assert.That(actual, Is.EquivalentTo(expected));

        }


    }
}