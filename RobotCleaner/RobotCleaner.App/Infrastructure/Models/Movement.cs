using RobotCleaner.App.Infrastructure.Contracts;

namespace RobotCleaner.App.Infrastructure.Models
{
    public struct Movement : IMovement
    {
        public Movement(Direction direction, int steps)
        {
            Direction = direction;
            Steps = steps;
        }
        public Direction Direction { get; private set; }
        public int Steps { get; private set; }

    }
}