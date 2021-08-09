using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MartianRobots.Models
{
    public class Mars
    {

        private int TopX { get; set; }
        private int TopY { get; set; }
        public List<Coordinates> ScentCoordinates { get; set; }

        public Mars(Coordinates coordinates)
        {
            TopX = coordinates.X;
            TopY = coordinates.Y;
            ScentCoordinates = new List<Coordinates>();
        }

        public bool IsScentCoordinate(Coordinates coordinate)
        {
            return this.ScentCoordinates.Where(sc => sc.X == coordinate.X && sc.Y == coordinate.Y).Count() > 0;
        }

        public bool IsOutOfBounds(Coordinates coordinate)
        {
            return (coordinate.X < 0 || coordinate.X > this.TopX)
               || (coordinate.Y < 0 || coordinate.Y > this.TopY);
        }

        public void AddScentCoordinate(Coordinates coordinate)
        {
            this.ScentCoordinates.Add(coordinate);
        }
    }
}
