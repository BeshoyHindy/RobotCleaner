namespace RobotCleaner.App.Infrastructure.Contracts
{
    public interface IRobot
    {
        void StartCleaning();
        string CleanedPositions { get; }
    }
}