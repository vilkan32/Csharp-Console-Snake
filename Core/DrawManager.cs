using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.Core
{
    using GameObjects.Coordinates;
    using GameObjects.SnakeBody;
    using System.Linq;

    public class DrawManager
    {
        private List<Coordinate> lastDrawnElements;
        public DrawManager()
        {
            this.lastDrawnElements = new List<Coordinate>();
        }
        public void Draw(string symbol, IReadOnlyCollection<Coordinate> coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                if (symbol == "\u25CF")
                {
                    this.lastDrawnElements.Add(new Coordinate(coordinate.CoordinateX,
                        coordinate.CoordinateY));
                }
                this.DrawOperation(symbol, coordinate);
            }
        }

        private void DrawOperation(string symbol, Coordinate coordinate)
        {
            Console.SetCursorPosition(coordinate.CoordinateX, coordinate.CoordinateY);
            Console.Write(symbol);
        }

        public void UndoDraw()
        {
            if (this.lastDrawnElements.Any())
            {
                this.DrawOperation(" ", this.lastDrawnElements.First());
                this.lastDrawnElements.Clear();
            }
        }
    }
}
