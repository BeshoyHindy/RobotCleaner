namespace RobotCleaner.App.Infrastructure
{
    public struct Movement
    {
        public Movement(string direction, int steps)
        {
            Direction = direction;
            Steps = steps;
        }
        public string Direction { get; private set; }
        public int Steps { get; private set; }

    }
}