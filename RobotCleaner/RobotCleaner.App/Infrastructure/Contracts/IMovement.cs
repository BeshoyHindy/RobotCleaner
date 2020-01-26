using RobotCleaner.App.Infrastructure.Models;

namespace RobotCleaner.App.Infrastructure.Contracts
{
    public interface IMovement
    {
        Direction Direction { get; }
        int Steps { get; }
    }
}