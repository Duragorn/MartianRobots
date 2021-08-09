using MartianRobots.Enums;
using MartianRobots.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobotsTest
{
    class InputTests
    {
        InputManager inputManager;

        [SetUp]
        public void Setup()
        {
            inputManager = new InputManager();
        }

        [TestCase("8 7 N", 8, 7, OrientationEnum.North)]
        [TestCase("10 5 N", 10, 5, OrientationEnum.North)]
        [TestCase("40 3 W", 40, 3, OrientationEnum.West)]
        [TestCase("38 21 S", 38, 21, OrientationEnum.South)]
        [TestCase("0 0 E", 0, 0, OrientationEnum.East)]
        [TestCase("50 50 N", 50, 50, OrientationEnum.North)]
        [TestCase("3 18 E", 3, 18, OrientationEnum.East)]
        [TestCase("41 22 S", 41, 22, OrientationEnum.South)]
        [TestCase("17 48 W", 17, 48, OrientationEnum.West)]
        public void TestRobot(string input, int x, int y, OrientationEnum orientation)
        {
            Robot robot = inputManager.GetRobotFromImput(input);

            Assert.AreEqual(robot.GetPosition().X, x);
            Assert.AreEqual(robot.GetPosition().Y, y);
            Assert.AreEqual(robot.GetOrientation(), orientation);
        }

        [TestCase("51 12 W")]
        public void TestOutOfBoundsRobot(string input)
        {
            Robot robot = inputManager.GetRobotFromImput(input);

            Assert.AreEqual(robot, null);
        }
    }
}
