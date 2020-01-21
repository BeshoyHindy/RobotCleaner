using System.Collections.Generic;

namespace RobotCleaner.App.Infrastructure
{
    public class Instructions
    {
        public Instructions()
        {
            Movements = new List<Movement>();
        }
        public Coordinate StartingPosition { get; set; }
        public List<Movement> Movements { get; set; }

    }
}