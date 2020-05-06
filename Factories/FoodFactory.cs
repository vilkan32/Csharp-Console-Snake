using System;
using System.Collections.Generic;
using System.Text;
using SimpleSnake.GameObjects.Foods;
using System.Linq;
using SimpleSnake.GameObjects.Coordinates;

namespace SimpleSnake.Factories
{
    public static class FoodFactory
    {
        private static Random random;

        static FoodFactory()
        {
            random = new Random();
        }

        public static Food GenerateRandomFood(int boardWidth, int boardHeight)
        {
            List<Type> subClassTypes = typeof(StartUp)
                .Assembly
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Food)))
                .ToList();

            Type foodType = subClassTypes[random.Next(0, subClassTypes.Count)];

            int x = random.Next(1, boardWidth - 1);
            int y = random.Next(1, boardHeight - 1);

            Coordinate coordinate = new Coordinate(x, y);

            return Activator.CreateInstance(foodType, coordinate) as Food;



        }
    }
}
