using RobotCleaner.App.Infrastructure.Contracts;
using System.Collections.Generic;
using RobotCleaner.App.Infrastructure.Models;

namespace RobotCleaner.App.Infrastructure.Factory
{
    public class RobotFactory
    {
        public static IRobot CreateRobot(IRobotEngine robotEngine)
        {
            return new Robot(robotEngine);
        }
        public static IRobot CreateRobot(Coordinate startingPosition, List<IMovement> movements, Coordinate minCoordinate, Coordinate maxCoordinate)
        {
            var engine = RobotEngineFactory.CreateRobotEngine(startingPosition, movements, minCoordinate, maxCoordinate);
            return CreateRobot(engine);
        }
        public static IRobot CreateRobot(Instructions instructions, Coordinate minCoordinate, Coordinate maxCoordinate)
        {
            return CreateRobot(instructions.StartingPosition, instructions.Movements, minCoordinate, maxCoordinate);
        }
        public static IRobot CreateRobot(InputsModel inputsModel, Coordinate minCoordinate, Coordinate maxCoordinate)
        {
            var instructions = InstructionsFactory.CreateInstructions(inputsModel);
            return CreateRobot(instructions, minCoordinate, maxCoordinate);
        }

    }

    public class RobotEngineFactory
    {
        public static IRobotEngine CreateRobotEngine(Coordinate startingPosition, List<IMovement> movements, Coordinate minCoordinate, Coordinate maxCoordinate)
        {
            return new RobotEngine(startingPosition, movements, minCoordinate, maxCoordinate);
        }
    }

    public class InstructionsFactory
    {
        public static Instructions CreateInstructions(InputsModel inputsModel)
        {
            var coordinate = inputsModel.StartingPosition.Trim().Split(' ');
            int.TryParse(coordinate[0], out var x);
            int.TryParse(coordinate[1], out var y);
            var startingPosition = Coordinate.CreateInstance(x, y);

            var movements = new List<IMovement>();
            foreach (var command in inputsModel.Commands)
            {
                var cmd = command.Trim().Split(' ');
                var direction = cmd[0].ToUpper() switch
                {
                    "E" => Direction.East,
                    "W" => Direction.West,
                    "N" => Direction.North,
                    "S" => Direction.South
                };

                int.TryParse(cmd[1], out var steps);
                movements.Add(new Movement(direction, steps));
            }

            return new Instructions(startingPosition, movements);

        }
    }

}