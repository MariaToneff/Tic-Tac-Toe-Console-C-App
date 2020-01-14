using System;
using System.Threading;
using TicTacToe.Board.Contracts;
using TicTacToe.Common;
using TicTacToe.Common.Console;
using TicTacToe.Renderers.Contracts;

namespace TicTacToe.Renderers
{
    public class ConsoleRenderer : IRenderer
    {
        private const string Logo = "TIC TAC TOE";
        private const ConsoleColor LightSquareConsoleColor = ConsoleColor.Gray;
        private const ConsoleColor DarkSquareConsoleColor = ConsoleColor.DarkGray;

        public ConsoleRenderer()
        {
            // TODO: change these magic values to something calculated
            if (Console.WindowWidth < 100 || Console.WindowHeight < 80)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.WriteLine("Please, set the Console window and buffer size to 100x80. For best experience use Raster Fonts 8x8!");
                Environment.Exit(0);
            }
        }
        public void RenderMainMenu()
        {
            ConsoleHelpers.SetCursorAtCenter(Logo.Length);
            Console.WriteLine(Logo);

            // TODO: add main menu
            Thread.Sleep(1000);
        }
        public void RenderBoard(IBoard board)
        {
            // TODO: validate Console dimensions
            var startRowPrint = (Console.WindowWidth / 2) - (board.TotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare / 2);
            var startColPrint = (Console.WindowHeight / 2) - (board.TotalCols * ConsoleConstants.CharactersPerColPerBoardSquare / 2);

            var currentRowPrint = startRowPrint;
            var currentColPrint = startColPrint;

            PrintBorder(startRowPrint, startColPrint, board.TotalRows, board.TotalCols);

            Console.BackgroundColor = ConsoleColor.White;
            for (int top = 0; top < board.TotalRows; top++)
            {
                for (int left = 0; left < board.TotalCols; left++)
                {
                    currentColPrint = startRowPrint + (left * ConsoleConstants.CharactersPerColPerBoardSquare);
                    currentRowPrint = startColPrint + (top * ConsoleConstants.CharactersPerRowPerBoardSquare);

                    ConsoleColor backgroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = backgroundColor;

                    var position = Position.FromArrayCoordinates(top, left, board.TotalRows);

                    var figure = board.GetFigureAtPosition(position);
                    ConsoleHelpers.PrintFigure(figure, backgroundColor, currentRowPrint, currentColPrint);
                }
            }

            //middle row lines

            for (int i = startRowPrint - 2; i < startRowPrint + (board.TotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare) + 2; i++)
            {
                Console.BackgroundColor = LightSquareConsoleColor;
                Console.SetCursorPosition(i, startColPrint - 2 + ConsoleConstants.CharactersPerRowPerBoardSquare + 1);
                Console.Write(" ");
                Console.SetCursorPosition(i, startColPrint - 2 + ConsoleConstants.CharactersPerRowPerBoardSquare + 1 + 1);
                Console.Write(" ");
            }

            for (int i = startRowPrint - 2; i < startRowPrint + (board.TotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare) + 2; i++)
            {
                Console.BackgroundColor = LightSquareConsoleColor;
                Console.SetCursorPosition(i, startColPrint - 2 + (ConsoleConstants.CharactersPerRowPerBoardSquare + 1) * 2 - 1);
                Console.Write(" ");
                Console.SetCursorPosition(i, startColPrint - 2 + (ConsoleConstants.CharactersPerRowPerBoardSquare + 1) * 2);
                Console.Write(" ");
            }

            //up and down row lines

            for (int i = startRowPrint - 2; i < startRowPrint + (board.TotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare) + 2; i++)
            {
                Console.BackgroundColor = DarkSquareConsoleColor;
                Console.SetCursorPosition(i, startColPrint);
                Console.Write(" ");
            }

            for (int i = startRowPrint - 2; i < startRowPrint + (board.TotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare) + 2; i++)
            {
                Console.BackgroundColor = DarkSquareConsoleColor;
                Console.SetCursorPosition(i, startColPrint + (board.TotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare) - 1);
                Console.Write(" ");
            }

            //middle column lines

            for (int i = startColPrint - 2; i < startColPrint + (board.TotalCols * ConsoleConstants.CharactersPerColPerBoardSquare) + 2; i++)
            {
                Console.BackgroundColor = LightSquareConsoleColor;
                Console.SetCursorPosition(startRowPrint + ConsoleConstants.CharactersPerColPerBoardSquare - 1, i);
                Console.Write("  ");
            }

            for (int i = startColPrint - 2; i < startColPrint + (board.TotalCols * ConsoleConstants.CharactersPerColPerBoardSquare) + 2; i++)
            {
                Console.BackgroundColor = LightSquareConsoleColor;
                Console.SetCursorPosition(startRowPrint + ConsoleConstants.CharactersPerColPerBoardSquare * 2 - 1, i);
                Console.Write("  ");
            }

            // left ang right column lines

            for (int i = startColPrint - 2; i < startColPrint + (board.TotalCols * ConsoleConstants.CharactersPerColPerBoardSquare) + 2; i++)
            {
                Console.BackgroundColor = DarkSquareConsoleColor;
                Console.SetCursorPosition(startRowPrint, i);
                Console.Write(" ");
            }

            for (int i = startColPrint - 2; i < startColPrint + (board.TotalCols * ConsoleConstants.CharactersPerColPerBoardSquare) + 2; i++)
            {
                Console.BackgroundColor = DarkSquareConsoleColor;
                Console.SetCursorPosition(startRowPrint + (board.TotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare) - 1, i);
                Console.Write(" ");
            }
        }
        private void PrintBorder(int startRowPrint, int startColPrint, int boardTotalRows, int boardTotalCols)
        {
            var start = startRowPrint + (ConsoleConstants.CharactersPerRowPerBoardSquare / 2);
            for (int i = 0; i < boardTotalCols; i++)
            {
                Console.SetCursorPosition(start + (i * ConsoleConstants.CharactersPerRowPerBoardSquare), startColPrint - 2);
                Console.Write((char)('A' + i));
                Console.SetCursorPosition(start + (i * ConsoleConstants.CharactersPerRowPerBoardSquare), startColPrint + (boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare) + 1);
                Console.Write((char)('A' + i));
            }

            start = startColPrint + (ConsoleConstants.CharactersPerColPerBoardSquare / 2);
            for (int i = 0; i < boardTotalRows; i++)
            {
                Console.SetCursorPosition(startRowPrint - 2, start + (i * ConsoleConstants.CharactersPerColPerBoardSquare));
                Console.Write(i + 1);
                Console.SetCursorPosition(startRowPrint + 1 + (boardTotalCols * ConsoleConstants.CharactersPerColPerBoardSquare), start + (i * ConsoleConstants.CharactersPerColPerBoardSquare));
                Console.Write(i + 1);
            }
        }

        public void PrintErrorMessage(string errorMessage)
        {
            ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRowForPlayerIO);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition((Console.WindowWidth / 2) - (errorMessage.Length / 2), ConsoleConstants.ConsoleRowForPlayerIO);
            Console.Write(errorMessage);
            Thread.Sleep(3000);
            ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRowForPlayerIO);
        }
    }
}
