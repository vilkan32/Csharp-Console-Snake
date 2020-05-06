using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.Core
{
    using Core;
    using SimpleSnake.Enums;
    using SimpleSnake.Factories;
    using SimpleSnake.GameObjects.Coordinates;
    using SimpleSnake.GameObjects.Foods;
    using SimpleSnake.GameObjects.SnakeBody;
    using System.Linq;
    using System.Threading;

    public class Engine
    {
        private DrawManager drawManager;
        private Snake snake;
        private Food currentFood;
        private Coordinate boardCoordinate;
        private int gameScore;
        private int level = 1;
        public Engine(DrawManager drawManager, Snake snake, Coordinate boardCoordinate)
        {
            this.drawManager = drawManager;
            this.snake = snake;
            this.InitializeFood();
            this.boardCoordinate = boardCoordinate;
            this.InitializeBoard();
        }
        public void Run()
        {
            while (true)
            {
                this.PlayerInfo();
               
                this.drawManager.Draw(currentFood.FoodSymbols, new List<Coordinate> { currentFood.Coordinate });
                this.drawManager.Draw("\u25CF", this.snake.Body);
                if (Console.KeyAvailable)
                {
                    SetNewDirection(Console.ReadKey(true));
                }
                this.snake.Move();

                this.drawManager.UndoDraw();
                if (HasSelfColision())
                {
                    this.AskUserForRestart();
                }
                if (HasEatCollision())
                {
                    this.snake.Eat(currentFood);
                    this.InitializeFood();
                    this.gameScore += currentFood.FoodPoints;
                    this.level = gameScore / 10;
                }
                if (HasBorderCollision())
                {
                    this.AskUserForRestart();
                }
                Thread.Sleep(100);

            }
        }

        private void SetNewDirection(ConsoleKeyInfo input)
        {
            Direction direction = this.snake.Direction;

            switch (input.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (direction != Direction.Right)
                    {
                        direction = Direction.Left;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (direction != Direction.Up)
                    {
                        direction = Direction.Down;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (direction != Direction.Down)
                    {
                        direction = Direction.Up;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (direction != Direction.Left)
                    {
                        direction = Direction.Right;
                    }
                    break;
                case ConsoleKey.P:
                    Console.ReadKey(true);
                    break;
                default:
                    break;
            }

            this.snake.Direction = direction;
        }

        private void InitializeFood()
        {
            this.currentFood = FoodFactory.GenerateRandomFood(20, 20);
        }
        private bool HasEatCollision()
        {
            int headCoordinateX = this.snake.Head.CoordinateX;
            int headCoordinateY = this.snake.Head.CoordinateY;

            int foodCoordinateX = this.currentFood.Coordinate.CoordinateX;
            int foodCoordinateY = this.currentFood.Coordinate.CoordinateY;

            return headCoordinateX == foodCoordinateX && headCoordinateY == foodCoordinateY;

        }

        private void InitializeBoard()
        {
            List<Coordinate> allCoordinates = new List<Coordinate>();
            this.InitializeHorizontalBorder(0, allCoordinates);
            this.InitializeHorizontalBorder(this.boardCoordinate.CoordinateY -1, allCoordinates);
            this.InitializeVerticalBorder(0, allCoordinates);
            this.InitializeVerticalBorder(this.boardCoordinate.CoordinateX, allCoordinates);
            this.drawManager.Draw("\u25A0", allCoordinates);
        }

        private void InitializeHorizontalBorder(int coordinateY, List<Coordinate> allCoordinates)
        {
            for (int i = 0; i < this.boardCoordinate.CoordinateX; i++)
            {
                allCoordinates.Add(new Coordinate(i, coordinateY));
            }
        }

        private void InitializeVerticalBorder(int coordinateX, List<Coordinate> allCoordinates)
        {
            for (int i = 0; i < this.boardCoordinate.CoordinateY; i++)
            {
                allCoordinates.Add(new Coordinate(coordinateX, i));
            }
        }

        private bool HasBorderCollision()
        {
            int headCoordinateX = this.snake.Head.CoordinateX;
            int headCoordinateY = this.snake.Head.CoordinateY;

            bool hasLeftBorderCollision = headCoordinateY <= 0 || headCoordinateY > this.boardCoordinate.CoordinateY - 1;
            bool hasTopBorderCollision = headCoordinateX <= 0 || headCoordinateX > this.boardCoordinate.CoordinateX - 1;

            return hasLeftBorderCollision || hasTopBorderCollision;

        }
        private bool HasSelfColision()
        {


            if (this.HasEatCollision() == true)
            {
                return false;
            }
            else
            {
                foreach (var item in this.snake.Body.SkipLast(1))
                {
                   var result = item.CompareTo(this.snake.Head);
                    if (result == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void AskUserForRestart()
        {
            int x = 45;
            int y = 20;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Would you like to continue? ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Y/N  ");

            string input = Console.ReadLine();

            if (input?.ToLower() == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void PlayerInfo()
        {
            Console.SetCursorPosition(this.boardCoordinate.CoordinateX + 10, 10);
            Console.Write($"Game score: {this.gameScore}");
            Console.SetCursorPosition(this.boardCoordinate.CoordinateX + 10, 0);
            Console.Write($"Game level: {this.level}");
        }
    }
}
