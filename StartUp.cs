namespace SimpleSnake
{
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects.Coordinates;
    using SimpleSnake.GameObjects.SnakeBody;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            DrawManager drawManager = new DrawManager();
            Snake snake = new Snake();
            Coordinate coordinate = new Coordinate(120, 40);
            Engine engine = new Engine(drawManager, snake, coordinate);
            engine.Run();
        }
    }
}
