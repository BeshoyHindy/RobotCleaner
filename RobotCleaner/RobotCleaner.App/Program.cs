using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using RobotCleaner.App.Infrastructure;

namespace RobotCleaner.App
{
    class Program
    {
        private static Robot _robot;
        private static RobotEngine _robotEngine;
        static void Main(string[] args)
        {
            string command = "";
            do
            {
                Console.WriteLine("\r\n-- COMMAND LIST --");
                Console.WriteLine("\tstart or -s. Starts the robot cleaner");
                Console.WriteLine("\treport or -r. Read the last report");

                Console.WriteLine("\tquit or -q. Quit");

                command = Console.ReadLine()?.Trim().ToLower();

                Execute(command);
            } while (command != "-q" || command != "quit");


        }

        private static void Execute(string command)
        {

            switch (command)
            {
                case "-s":
                case "start":
                    StartTheRobot();
                    break;
                case "-r":
                case "report":
                    ReadTheReport();
                    break;
                case "-q":
                case "quit":
                    break;
                default:
                    Console.WriteLine("\r\nIncorrect command.");
                    break;
            }
        }

        private static void StartTheRobot()
        {
            var instructions = new Instructions();

            var commandsCount = PrintOutInput("Please enter the number of robot commands:");
            var startingPosition = PrintOutInput("Please enter the starting position coordinates {x y}:");
            var coordinate = startingPosition.Trim().Split(' ');
            int.TryParse(coordinate[0], out var x);
            int.TryParse(coordinate[1], out var y);
            instructions.StartingPosition =new Coordinate(x, y);


            for (var i = 1; i <= int.Parse(commandsCount); i++)
            {
                var cmd = PrintOutInput($"Please enter the command number ({i}):");
                var movement = cmd.Trim().Split(' ');
                int.TryParse(movement[1], out var steps);
                instructions.Movements.Add(new Movement(movement[0].ToUpper(), steps));
            }
            _robotEngine = new RobotEngine(instructions);
            _robot = new Robot(_robotEngine);

            _robot.StartCleaning();

        }

        private static void ReadTheReport()
        {
            Console.WriteLine($"{_robot.CleanedPositions}");
        }

        private static string PrintOutInput(string title)
        {
            Console.WriteLine($" => {title}");
            return Console.ReadLine();
        }

    }
}
