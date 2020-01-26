using RobotCleaner.App.Infrastructure.Contracts;

namespace RobotCleaner.App.Infrastructure
{
    public class Robot : IRobot
    {

        private readonly IRobotEngine _robotEngine;
        public Robot(IRobotEngine robotEngine)
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