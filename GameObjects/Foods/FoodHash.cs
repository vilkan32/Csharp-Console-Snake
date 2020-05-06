using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    using Coordinates;

    public class FoodHash : Food
    {
        private const int Points = 3;
        private const string Symbol = "#";

        public FoodHash(Coordinate coordinate) : base(Symbol, Points, coordinate)
        {
        }
    }
}
