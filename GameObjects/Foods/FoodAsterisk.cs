namespace SimpleSnake.GameObjects.Foods
{
    using Coordinates;

    public class FoodAsterisk : Food
    {
        private const int Points = 1;
        private const string Symbol = "*";

        public FoodAsterisk(Coordinate coordinate) : base(Symbol, Points, coordinate)
        {
        }

    }
}
