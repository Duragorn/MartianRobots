using MartianRobots.Enums;
using MartianRobots.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MartianRobots
{
    class Program
    {
        static void Main(string[] args)
        {
            InputManager inputManager = new InputManager();
            List<Robot> robots = new List<Robot>();
            List<List<CommandEnum>> commands = new List<List<CommandEnum>>();
            OutputManager outputManager = new OutputManager();

            var input = inputManager.GetInput();
            var mars = inputManager.GetMarsFromInput(input[0]);

            if (mars == null)
            {
                outputManager.MarsError();
            }

            if (inputManager.CheckValidAmountOfLines(input))
            {
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
            }


            if (inputManager.CheckSameCommandsAndRobots(robots, commands))
            {
                for (var index = 0; index < robots.Count; index++)
                {
                    if (robots[index] != null)
                        robots[index].PerformCommands(commands[index], mars);
                }

                outputManager.WriteOuput(robots);
            }
        }
    }
}
