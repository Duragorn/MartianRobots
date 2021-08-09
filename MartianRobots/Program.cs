using MartianRobots.Enums;
using MartianRobots.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots
{
    class Program
    {
        static void Main(string[] args)
        {
            InputManager inputManager = new InputManager();
            List<Robot> robots = new List<Robot>();
            List<List<CommandEnum>> commands = new List<List<CommandEnum>>();

            var input = inputManager.GetInput();
            var mars = inputManager.GetMarsFromInput(input[0]);

            for (var index = 1; index < input.Length - 1; index++)
            {
                if (index % 2 == 0)
                {
                    commands.Add(inputManager.GetCommandsFromInput(input[index]));
                } 
                else
                {
                    robots.Add(inputManager.GetRobotFromImput(input[index]));
                }
            }


            for (var index = 0; index < robots.Count; index++)
            {
                robots[index].PerformCommands(commands[index], mars);
            }

            foreach(var robot in robots)
            {
                Console.WriteLine(robot.GetPosition().X + " " +
                    robot.GetPosition().Y + " " +
                    robot.GetOrientation() + " " +
                    (robot.IsLost() ? "LOST" : ""));
            }
        }
    }
}
