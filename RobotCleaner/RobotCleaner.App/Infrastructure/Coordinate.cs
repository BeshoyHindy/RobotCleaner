using RobotCleaner.App.Infrastructure.Contracts;

namespace RobotCleaner.App.Infrastructure
{
    public struct Coordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        private Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static Coordinate CreateInstance(int x, int y) => new Coordinate(x, y);

        public static bool operator <(Coordinate a, Coordinate b) => a.X < b.X && a.Y < b.Y;
        public static bool operator >(Coordinate a, Coordinate b) => a.X > b.X && a.Y > b.Y;

        public void MoveStepToEast() => X++;
        public void MoveStepToWest() => X--;
        public void MoveStepToNorth() => Y++;
        public void MoveStepToSouth() => Y--;

    }

}