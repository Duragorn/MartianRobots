using MartianRobots.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace MartianRobots.Models
{
    public class InputManager
    {
        public string[] GetInput()
        {
            Console.WriteLine("Insert your input: (type end to finish)");
            string input = string.Empty;
            string inputLine;
            do
            {
                inputLine = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(inputLine) && !inputLine.ToLower().Equals("end"))
                {
                    input += inputLine + Environment.NewLine;
                }
            } while (!inputLine.ToLower().Equals("end"));

            return input.Split(Environment.NewLine);
        }

        public Mars GetMarsFromInput(string mars)
        {
            string[] marsCoordinates = mars.Split(" ");

            if (ValidateMars(marsCoordinates))
            {
                int.TryParse(marsCoordinates[0], out int topX);
                int.TryParse(marsCoordinates[1], out int topY);
                return new Mars(new Coordinates(topX, topY));
            }

            return null;
        }

        public Robot GetRobotFromImput(string robot)
        {
            string[] robotCoordinates = robot.Split(" ");

            if (ValidateRobot(robotCoordinates))
            {
                int.TryParse(robotCoordinates[0], out int positionX);
                int.TryParse(robotCoordinates[1], out int positionY);

                var orientation = robotCoordinates[2];

                return new Robot(new Coordinates(positionX, positionY), GetOrientation(orientation.ToUpper()));
            }

            return null;
        }

        public List<CommandEnum> GetCommandsFromInput(string commands)
        {
            List<CommandEnum> commandsList = new List<CommandEnum>();
            commands = commands.ToUpper();

            if (ValidateCommands(commands))
            {                
                foreach (char c in commands.ToUpper())
                {
                    commandsList.Add(GetCommand(c));
                }
            }

            return commandsList;
        }

        public bool CheckValidAmountOfLines(string[] input)
        {
            return input.Length - 1 % 2 != 0;
        }

        public bool CheckSameCommandsAndRobots(List<Robot> robots, List<List<CommandEnum>> commands)
        {
            return robots.Count == commands.Count;
        }

        private static OrientationEnum GetOrientation(string orientation)
        {
            return orientation switch
            {
                "N" => OrientationEnum.North,
                "W" => OrientationEnum.West,
                "S" => OrientationEnum.South,
                "E" => OrientationEnum.East,
                _ => OrientationEnum.North,
            };
        }

        private static CommandEnum GetCommand(char command)
        {
            return command switch
            {
                'F' => CommandEnum.Forward,
                'L' => CommandEnum.Left,
                'R' => CommandEnum.Right
            };
        }

        private bool ValidateMars(string[] mars)
        {
            if (mars.Length == 2
                && IsNumericAndMax50(mars[0])
                && IsNumericAndMax50(mars[1]))
                return true;

            return false;
        }

        private bool ValidateRobot(string[] robot)
        {
            if (robot.Length == 3 
                && IsNumericAndMax50(robot[0])
                && IsNumericAndMax50(robot[1])
                && Regex.IsMatch(robot[2].ToUpper(), @"^[NSEW]"))
                return true;

            return false;
        }

        private bool ValidateCommands(string commands)
        {
            if (Regex.IsMatch(commands, @"^([FLR]*)$") 
                && commands.Length <= 100)
            {
                return true;
            }
            return false;
        }

        private bool IsNumericAndMax50(string value)
        {
            return Regex.IsMatch(value, @"\b([0-9]|[1-4][0-9]|50)\b");
        }
    }
}
