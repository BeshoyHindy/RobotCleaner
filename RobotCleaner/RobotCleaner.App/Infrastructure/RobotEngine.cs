using System.Collections.Generic;

namespace RobotCleaner.App.Infrastructure
{
    public class RobotEngine
    {
        private readonly Instructions _instructions;
        private Coordinate _CurrentPosition;
        public HashSet<Coordinate> CleanedPositions { get; private set; }
        public RobotEngine(Instructions instructions)
        {
            CleanedPositions = new HashSet<Coordinate>();

            _instructions = instructions;
            _CurrentPosition = _instructions.StartingPosition;
        }

        public void RunEngine()
        {
            RegisterCleanedPosition();
            foreach (var movement in _instructions.Movements)
            {
                MoveTo(movement);
            }
        }

        private void MoveTo(Movement movement)
        {
            switch (movement.Direction)
            {
                case "E":
                    MoveToEast(movement.Steps);
                    break;
                case "W":
                    MoveToWest(movement.Steps);
                    break;
                case "N":
                    MoveToNorth(movement.Steps);
                    break;
                case "S":
                    MoveToSouth(movement.Steps);
                    break;
            }

        }
        private void MoveToEast(int steps)
        {
            for (var i = 0; i < steps; i++)
            {
                _CurrentPosition.MoveStepToEast();
                RegisterCleanedPosition();
            }
        }

        private void MoveToWest(int steps)
        {
            for (var i = 0; i < steps; i++)
            {
                _CurrentPosition.MoveStepToWest();
                RegisterCleanedPosition();
            }
        }

        private void MoveToNorth(int steps)
        {
            for (var i = 0; i < steps; i++)
            {
                _CurrentPosition.MoveStepToNorth();
                RegisterCleanedPosition();
            }
        }

        private void MoveToSouth(int steps)
        {
            for (var i = 0; i < steps; i++)
            {
                _CurrentPosition.MoveStepToSouth();
                RegisterCleanedPosition();
            }
        }

        private void RegisterCleanedPosition()
        {
            CleanedPositions.Add(_CurrentPosition);
        }

    }
}