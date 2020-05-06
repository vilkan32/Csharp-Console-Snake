using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.SnakeBody
{
    using Coordinates;
    using Enums;
    using System.Linq;
    using Foods;
    public class Snake
    {
        private List<Coordinate> snakeBody;
        private Direction currentDirection;
        private Coordinate head;
        public IReadOnlyCollection<Coordinate> Body => this.snakeBody.AsReadOnly();
        public Coordinate Head => this.head;
        public Direction Direction
        {
            get => this.currentDirection;
            set
            {
                this.currentDirection = value;
            }
        }
        public Snake()
        {
            this.snakeBody = new List<Coordinate>();
            this.InitializeDefaultSnake();
            this.currentDirection = Direction.Right;
        }

        private void InitializeDefaultSnake()
        {
            int x = 5;
            int y = 6;

            for (int i = 1; i < 6; i++)
            {
                this.snakeBody.Add(new Coordinate(x++, y));
            }
        }

        private Coordinate CalculateNewCoordinate(Coordinate newCoordinate)
        {
            switch (this.currentDirection)
            {
                case Direction.Right:
                    newCoordinate.CoordinateX += 1;
                    break;
                case Direction.Left:
                    newCoordinate.CoordinateX += -1;
                    break;
                case Direction.Down:
                    newCoordinate.CoordinateY += 1;
                    break;
                case Direction.Up:
                    newCoordinate.CoordinateY += -1;
                    break;
                default:
                    break;
            }

            return newCoordinate;
        }

        public void Move()
        {
            Coordinate currentHead = this.snakeBody.Last();

            Coordinate newHeadCoordinate = this.CalculateNewCoordinate(new Coordinate(currentHead.CoordinateX, currentHead.CoordinateY));
            this.snakeBody.Add(newHeadCoordinate);
            this.snakeBody.RemoveAt(0);
            this.head = newHeadCoordinate;
        }

        public void Eat(Food food)
        {
            for (int i = 0; i < food.FoodPoints; i++)
            {
                Coordinate coordinate = new Coordinate(this.head.CoordinateX,
                    this.head.CoordinateY);
                this.snakeBody.Add(this.CalculateNewCoordinate(coordinate));
            }
        }
    }
}
