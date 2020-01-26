using System.Collections.Generic;
using RobotCleaner.App.Infrastructure.Contracts;
using RobotCleaner.App.Infrastructure.Models;

namespace RobotCleaner.App.Infrastructure
{
    public class RobotEngine : IRobotEngine
    {

        private readonly IEnumerable<IMovement> _movements;
        private Coordinate _currentPosition;
        private readonly Coordinate _minCoordinate;
        private readonly Coordinate _maxCoordinate;
        public HashSet<Coordinate> CleanedPositions { get; private set; }

        public RobotEngine(Coordinate startingPosition, List<IMovement> movements, Coordinate minCoordinate, Coordinate maxCoordinate)
        {
            _currentPosition = startingPosition;
            _movements = movements;
            _minCoordinate = minCoordinate;
            _maxCoordinate = maxCoordinate;

            CleanedPositions = new HashSet<Coordinate>();
        }

        public void RunEngine()
        {
            RegisterCleanedPosition();
            foreach (var movement in _movements)
            {
                for (var i = 0; i < movement.Steps; i++)
                {
                    MoveTo(movement.Direction);
                    RegisterCleanedPosition();
                }
            }
        }
        private void MoveTo(Direction direction)
        {
            switch (direction)
            {
                case Direction.East:
                    MoveToEast();
                    break;
                case Direction.West:
                    MoveToWest();
                    break;
                case Direction.North:
                    MoveToNorth();
                    break;
                case Direction.South:
                    MoveToSouth();
                    break;
            }

        }
        private void MoveToEast()
        {
            if (_currentPosition < _maxCoordinate)
                _currentPosition.MoveStepToEast();
        }
        private void MoveToWest()
        {
            if (_currentPosition > _minCoordinate)
                _currentPosition.MoveStepToWest();
        }
        private void MoveToNorth()
        {
            if (_currentPosition < _maxCoordinate)
                _currentPosition.MoveStepToNorth();
        }
        private void MoveToSouth()
        {
            if (_currentPosition > _minCoordinate)
                _currentPosition.MoveStepToSouth();
        }
        private void RegisterCleanedPosition() => CleanedPositions.Add(_currentPosition);

    }

}