using MartianRobots.Enums;
using System;
using System.Collections.Generic;

namespace MartianRobots.Models
{
    class OutputManager
    {

        public void WriteOuput(List<Robot> robots)
        {
            foreach (var robot in robots)
            {
                if (robot != null)
                    Console.WriteLine(robot.GetPosition().X + " " +
                        robot.GetPosition().Y + " " +
                        FromOrientationToSingleLetter(robot.GetOrientation()) + " " +
                        (robot.IsLost() ? "LOST" : ""));
            }
        }

        public void MarsError()
        {
            Console.WriteLine("Mars size was incorrect or above 50");
            Environment.Exit(0);
        }

        private string FromOrientationToSingleLetter(OrientationEnum orientation)
        {
            return orientation switch
            {
                OrientationEnum.North => "N",
                OrientationEnum.West => "W",
                OrientationEnum.South => "S",
                OrientationEnum.East => "E"
            };
        }
    }
}
