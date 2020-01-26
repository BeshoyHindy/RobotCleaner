using System.Collections.Generic;

namespace RobotCleaner.App.Infrastructure.Contracts
{
    public interface IRobotEngine
    {
        HashSet<Coordinate> CleanedPositions { get; }
        void RunEngine();
    }
}