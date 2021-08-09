using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using MartianRobots;
using MartianRobots.Enums;
using MartianRobots.Models;

namespace MartianRobotsTest
{
    class RobotTests
    {
        InputManager inputManager;
        Mars mars;

        [SetUp]
        public void Setup()
        {
            inputManager = new InputManager();
            mars = new Mars(new Coordinates(5, 3));
        }

        [TestCase("17 48 N", OrientationEnum.South)]
        [TestCase("17 48 W", OrientationEnum.East)]
        [TestCase("17 48 S", OrientationEnum.North)]
        [TestCase("17 48 E", OrientationEnum.West)]
        public void TestRobotTurnLeft(string input, OrientationEnum endOrientation)
        {
            var robot = inputManager.GetRobotFromImput(input);
            robot.TurnLeft();
            robot.TurnLeft();
            Assert.AreEqual(robot.GetOrientation(), endOrientation);
        }

        [TestCase("17 48 N", OrientationEnum.South)]
        [TestCase("17 48 W", OrientationEnum.East)]
        [TestCase("17 48 S", OrientationEnum.North)]
        [TestCase("17 48 E", OrientationEnum.West)]
        public void TestRobotTurnRight(string input, OrientationEnum endOrientation)
        {
            var robot = inputManager.GetRobotFromImput(input);
            robot.TurnRight();
            robot.TurnRight();
            Assert.AreEqual(robot.GetOrientation(), endOrientation);
        }


        [TestCase("1 1 E", "RFRFRFRF", 1, 1, OrientationEnum.East)]
        [TestCase("3 2 N", "FRRFLLFFRRFLL", 3, 3, OrientationEnum.North)]        
        public void TestRobotPerformingCommands(string input, string commands, int endX, int endY, OrientationEnum orientationEnum)
        {
            var robot = inputManager.GetRobotFromImput(input);
            var commandsList = inputManager.GetCommandsFromInput(commands);

            robot.PerformCommands(commandsList, mars);

            Assert.AreEqual(robot.GetPosition().X, endX);
            Assert.AreEqual(robot.GetPosition().Y, endY);
            Assert.AreEqual(robot.GetOrientation(), orientationEnum);
        }

        [TestCase("0 3 W", "LLFFFLFLFL", 2, 3, OrientationEnum.South)]
        public void TestRobotPerformingCommandsWhenAlreadyScent(string input, string commands, int endX, int endY, OrientationEnum orientationEnum)
        {
            mars.AddScentCoordinate(new Coordinates(3, 4));
            var robot = inputManager.GetRobotFromImput(input);
            var commandsList = inputManager.GetCommandsFromInput(commands);

            robot.PerformCommands(commandsList, mars);

            Assert.AreEqual(robot.GetPosition().X, endX);
            Assert.AreEqual(robot.GetPosition().Y, endY);
            Assert.AreEqual(robot.GetOrientation(), orientationEnum);
        }

    }
}
