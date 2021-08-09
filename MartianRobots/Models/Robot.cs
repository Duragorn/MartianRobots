using MartianRobots.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Models
{
    public class Robot
    {
        private Coordinates position;
        private OrientationEnum orientation;
        private bool lost;

        public Robot(Coordinates coordinates, OrientationEnum orientation)
        {
            this.SetPosition(coordinates);
            this.SetOrientation(orientation);
            this.lost = false;
        }

        public void PerformCommands(List<CommandEnum> commands, Mars mars)
        {
            foreach (var command in commands)
            {
                if (!lost)
                {
                    if (command == CommandEnum.Forward)
                    {
                        MoveForward(mars);
                    }
                    else if (command == CommandEnum.Left)
                    {
                        TurnLeft();
                    }
                    else if (command == CommandEnum.Right)
                    {
                        TurnRight();
                    }
                }
            }

        }

        public void MoveForward(Mars mars)
        {
            Coordinates nextStep = GetNextCoordinates();

            if (mars.IsOutOfBounds(nextStep))
            {
                if (!mars.IsScentCoordinate(nextStep))
                {
                    mars.AddScentCoordinate(nextStep);
                    lost = true;
                }
            } 
            else
            {
                this.SetPosition(nextStep);
            }
            
        }

        public void TurnLeft()
        {
            if (this.GetOrientation() == OrientationEnum.East) this.SetOrientation(OrientationEnum.North);
            else
                this.SetOrientation(this.GetOrientation() + 1);
        }

        public void TurnRight()
        {
            if (this.GetOrientation() == OrientationEnum.North) this.SetOrientation(OrientationEnum.East);
            else
                this.SetOrientation(this.GetOrientation() - 1);
        }

        public Coordinates GetPosition()
        {
            return position;
        }

        private void SetPosition(Coordinates coordinates)
        {
            this.position = coordinates;
        }
        private void SetXPosition(int newXPosition)
        {
            GetPosition().X = newXPosition;
        }

        private void SetYPosition(int newYPosition)
        {
            GetPosition().Y = newYPosition;
        }

        public OrientationEnum GetOrientation()
        {
            return orientation;
        }

        private void SetOrientation(OrientationEnum orientation)
        {
            this.orientation = orientation;
        }

        private Coordinates GetNextCoordinates()
        {
            Coordinates coordinates = GetPosition();

            if (GetOrientation() == OrientationEnum.North)
            {
                coordinates = new Coordinates(coordinates.X, coordinates.Y + 1);
            }
            else if (GetOrientation() == OrientationEnum.South)
            {
                coordinates = new Coordinates(coordinates.X, coordinates.Y - 1);
            }
            else if (GetOrientation() == OrientationEnum.East)
            {
                coordinates = new Coordinates(coordinates.X + 1, coordinates.Y);
            }
            else if (GetOrientation() == OrientationEnum.West)
            {
                coordinates = new Coordinates(coordinates.X - 1, coordinates.Y);
            }

            return coordinates;
        }

        public bool IsLost()
        {
            return lost;
        }

    }
}
