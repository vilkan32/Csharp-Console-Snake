using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    using Coordinates;
    public abstract class Food
    {
        private int foodPoints;
        private string foodSymbols;
        private Coordinate coordinate;

        public Food(string symbol, int foodPoints, Coordinate coordinate)
        {
            this.FoodSymbols = symbol;
            this.FoodPoints = foodPoints;
            this.Coordinate = coordinate;
        }

        public int FoodPoints { get => foodPoints; private set => foodPoints = value; }
        public string FoodSymbols { get => foodSymbols; private set => foodSymbols = value; }
        public Coordinate Coordinate { get => coordinate; private set => coordinate = value; }
    }
}
