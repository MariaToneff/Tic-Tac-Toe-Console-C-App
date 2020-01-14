using System;
using System.Collections.Generic;
using TicTacToe.Board.Contracts;
using TicTacToe.Common;
using TicTacToe.Engine.Contracts;
using TicTacToe.Players;

namespace TicTacToe.Engine.Initializations
{
    public class StandardStartGameInitializationStrategy : IGameInitializationStrategy
    {
        private const int BoardTotalRowsAndCols = 3;

        public void Initialize(IList<IPlayer> players, IBoard board)
        {
            this.ValidateStrategy(players, board);

            var firstPlayer = players[0];
            var secondPlayer = players[1];
        }
        private void ValidateStrategy(ICollection<IPlayer> players, IBoard board)
        {
            if (players.Count != GlobalConstants.StandardGameNumberOfPlayers)
            {
                throw new InvalidOperationException("Standard Start Game Initialization Strategy needs exactly two players!");
            }

            if (board.TotalRows != BoardTotalRowsAndCols || board.TotalCols != BoardTotalRowsAndCols)
            {
                throw new InvalidOperationException("Standard Start Game Initialization Strategy needs 3x3 board!");
            }
        }
    }
}
