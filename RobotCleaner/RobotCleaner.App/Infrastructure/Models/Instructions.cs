using System.Collections.Generic;
using RobotCleaner.App.Infrastructure.Contracts;

namespace RobotCleaner.App.Infrastructure.Models
{
    public class Instructions
    {
        public Instructions(Coordinate startingPosition, List<IMovement> movements)
        {
            StartingPosition = startingPosition;
            Movements = movements;
        }
        public Coordinate StartingPosition { get; private set; }
        public List<IMovement> Movements { get; private set; }
    }
}