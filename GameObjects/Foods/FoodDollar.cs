using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    using Coordinates;

    public class FoodDollar : Food
    {
        private const int Points = 2;
        private const string Symbol = "$";

        public FoodDollar(Coordinate coordinate) : base(Symbol, Points, coordinate)
        {
        }
    }
}
