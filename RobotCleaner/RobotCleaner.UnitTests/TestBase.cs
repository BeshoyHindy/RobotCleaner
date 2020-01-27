using NUnit.Framework;
using RobotCleaner.App.Infrastructure;

namespace RobotCleaner.UnitTests
{
    [TestFixture]
    public abstract class TestBase
    {

        protected static Coordinate MinCoordinate;
        protected static Coordinate MaxCoordinate;

        [SetUp]
        public void InitializeBase()
        {
            MinCoordinate = Coordinate.CreateInstance(-100_000, -100_000);
            MaxCoordinate = Coordinate.CreateInstance(100_000, 100_000);

        }

    }
}