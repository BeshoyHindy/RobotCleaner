namespace RobotCleaner.App.Infrastructure
{
    public class Robot
    {
        private readonly RobotEngine _robotEngine;
        public Robot(RobotEngine robotEngine)
        {
            _robotEngine = robotEngine;
        }

        public void StartCleaning()
        {
            _robotEngine.RunEngine();
        }

        public string CleanedPositions => $"=> Cleaned: {_robotEngine.CleanedPositions.Count}";

    }
}