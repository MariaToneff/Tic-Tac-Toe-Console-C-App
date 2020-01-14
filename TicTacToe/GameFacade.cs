using TicTacToe.Engine;
using TicTacToe.Engine.Initializations;
using TicTacToe.InputProviders;
using TicTacToe.Renderers;

namespace TicTacToe
{
    public static class GameFacade
    {
        public static void Start()
        {
            var renderer = new ConsoleRenderer();
            renderer.RenderMainMenu();

            var inputProvider = new ConsoleInputProvider();

            var gameEngine = new StandardTwoPlayerEngine(renderer, inputProvider);

            var gameInitializationStrategy = new StandardStartGameInitializationStrategy();

            gameEngine.Initialize(gameInitializationStrategy);
            gameEngine.Start();

            System.Console.ReadLine();
        }
    }
}
