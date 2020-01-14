using System;
using System.Collections.Generic;
using TicTacToe.Figures.Contracts;
using TicTacToe.Players;

namespace TicTacToe.Common.Console
{
    public static class ConsoleHelpers
    {
        private static readonly IDictionary<FigureTypes, bool[,]> Patterns = new Dictionary<FigureTypes, bool[,]>
        {
            { FigureTypes.O, new[,]
                {
                    { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,},
                    { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,},
                    { false, false, false, false, false, false, false, true, true, true, true, false, false, false, false, false, false, false,},
                    { false, false, false, false, false, false, true, true, true, true, true, true, false, false, false, false, false, false,},
                    { false, false, false, false, false, true, true, false, false, false, false, true, true, false, false, false, false, false,},
                    { false, false, false, false, true, true, false, false, false, false, false, false, true, true, false, false, false, false,},
                    { false, false, false, true, true, false, false, false, false, false, false, false, false, true, true, false, false, false,},
                    { false, false, true, true, false, false, false, false, false, false, false, false, false, false, true, true, false, false,},
                    { false, false, true, true, false, false, false, false, false, false, false, false, false, false, true, true, false, false,},
                    { false, false, true, true, false, false, false, false, false, false, false, false, false, false, true, true, false, false,},
                    { false, false, true, true, false, false, false, false, false, false, false, false, false, false, true, true, false, false,},
                    { false, false, false, true, true, false, false, false, false, false, false, false, false, true, true, false, false, false,},
                    { false, false, false, false, true, true, false, false, false, false, false, false, true, true, false, false, false, false,},
                    { false, false, false, false, false, true, true, false, false, false, false, true, true, false, false, false, false, false,},
                    { false, false, false, false, false, false, true, true, true, true, true, true, false, false, false, false, false, false,},
                    { false, false, false, false, false, false, false, true, true, true, true, false, false, false, false, false, false, false,},
                    { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,},
                    { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,}
                }
            },
            { FigureTypes.X, new[,]
                {
                    { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,},
                    { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,},
                    { false, false, true, true, false, false, false, false, false, false, false, false, false, false, true, true, false, false,},
                    { false, false, true, true, true, false, false, false, false, false, false, false, false, true, true, true, false, false,},
                    { false, false, false, true, true, true, false, false, false, false, false, false, true, true, true, false, false, false,},
                    { false, false, false, false, true, true, true, false, false, false, false, true, true, true, false, false, false, false,},
                    { false, false, false, false, false, true, true, true, false, false, true, true, true, false, false, false, false, false,},
                    { false, false, false, false, false, false, true, true, true, true, true, true, false, false, false, false, false, false,},
                    { false, false, false, false, false, false, false, true, true, true, true, false, false, false, false, false, false, false,},
                    { false, false, false, false, false, false, false, true, true, true, true, false, false, false, false, false, false, false,},
                    { false, false, false, false, false, false, true, true, true, true, true, true, false, false, false, false, false, false,},
                    { false, false, false, false, false, true, true, true, false, false, true, true, true, false, false, false, false, false,},
                    { false, false, false, false, true, true, true, false, false, false, false, true, true, true, false, false, false, false,},
                    { false, false, false, true, true, true, false, false, false, false, false, false, true, true, true, false, false, false,},
                    { false, false, true, true, true, false, false, false, false, false, false, false, false, true, true, true, false, false,},
                    { false, false, true, true, false, false, false, false, false, false, false, false, false, false, true, true, false, false,},
                    { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,},
                    { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,}
                }
            }
        };
        public static void SetCursorAtCenter(int lengthOfMessage)
        {
            int centerRow = System.Console.WindowHeight / 2;
            int centerCol = (System.Console.WindowWidth / 2) - (lengthOfMessage / 2);
            System.Console.SetCursorPosition(centerCol, centerRow);
        }

        public static void PrintFigure(IFigure figure, ConsoleColor backgroundColor, int top, int left)
        {
            if (figure == null)
            {
                PrintEmptySquare(backgroundColor, top, left);
                return;
            }

            if (!Patterns.ContainsKey(figure.FigureType))
            {
                return;
            }

            var figurePattern = Patterns[figure.FigureType];

            if (figure.FigureType == FigureTypes.X)
            {
                backgroundColor = ConsoleColor.Red;
            }
            else
            {
                backgroundColor = ConsoleColor.Blue;
            }

            for (int i = 0; i < figurePattern.GetLength(0); i++)
            {
                for (int j = 0; j < figurePattern.GetLength(1); j++)
                {
                    System.Console.SetCursorPosition(left + j, top + i);
                    if (figurePattern[i, j] == true)
                    {
                        System.Console.BackgroundColor = backgroundColor;
                    }
                    else
                    {
                        System.Console.BackgroundColor = ConsoleColor.Black;
                    };

                    System.Console.Write(" ");
                }
            }
        }

        public static void PrintEmptySquare(ConsoleColor backgroundColor, int top, int left)
        {
            for (int i = 0; i < ConsoleConstants.CharactersPerRowPerBoardSquare; i++)
            {
                for (int j = 0; j < ConsoleConstants.CharactersPerColPerBoardSquare; j++)
                {
                    System.Console.SetCursorPosition(left + j, top + i);
                    System.Console.Write(" ");
                }
            }
        }
        public static Move CreateMoveFromCommand(string command)
        {
            var toAsString = command.Split();
            var letter = char.Parse(toAsString[0]);
            var digit = char.Parse(toAsString[1]);

            if (toAsString.Length != 2)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var toPosition = Position.FromChessCoordinates(digit - '0', letter);

            return new Move(toPosition);
        }

        public static void ClearRow(int row)
        {
            System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.SetCursorPosition(0, row);
            System.Console.Write(new string(' ', System.Console.WindowWidth));
        }

        public static void PrintWinner(IPlayer player)
        {
            System.Console.Clear();
        }
    }
}
