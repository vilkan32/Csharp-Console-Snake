using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Coordinates 
{
    public class Coordinate : IComparable<Coordinate>
    {
        private int coordinateX;
        private int coordinateY;
        public Coordinate(int coordinateX, int coordinateY)
        {
            this.CoordinateX = coordinateX;
            this.CoordinateY = coordinateY;
        }
        public int CoordinateX
        {
            get => this.coordinateX;
            set
            {
                this.coordinateX = value;
            }
        }

        public int CoordinateY
        {
            get => this.coordinateY;
            set
            {
                this.coordinateY = value;
            }
        }

        public int CompareTo(Coordinate other)
        {
            if (this.CoordinateX != other.CoordinateX)

                return (this.CoordinateX - other.CoordinateX);

            if (this.CoordinateY != other.CoordinateY)

                return (this.CoordinateY - other.CoordinateY);

            return 0;
        }
    }
}
