using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using RobotCleaner.App.Infrastructure;
using RobotCleaner.App.Infrastructure.Contracts;
using RobotCleaner.App.Infrastructure.Factory;
using RobotCleaner.App.Infrastructure.Models;

namespace RobotCleaner.App
{
    class Program
    {
        private static IRobot _robot;

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
                    ReadTheLastReport();
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
            var minCoordinate = Coordinate.CreateInstance(-100_000, -100_000);
            var maxCoordinate = Coordinate.CreateInstance(100_000, 100_000);

            var commandsCount = PrintOutInput("Please enter the number of robot commands:");
            var startingPosition = PrintOutInput("Please enter the starting position coordinates {x y}:");
            var commands = new List<string>();
            for (var i = 1; i <= int.Parse(commandsCount); i++)
            {
                var cmd = PrintOutInput($"Please enter the command number ({i}):");
                commands.Add(cmd);
            }

            var inputs = new InputsModel
            {
                StartingPosition = startingPosition,
                Commands = commands
            };

            _robot = RobotFactory.CreateRobot(inputs, minCoordinate, maxCoordinate);

            _robot.StartCleaning();

        }

        private static void ReadTheLastReport()
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
