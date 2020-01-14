using System.Collections;
using System.Collections.Generic;
using TicTacToe.Board.Contracts;
using TicTacToe.Players;

namespace TicTacToe.Engine.Contracts
{
    public interface IGameInitializationStrategy
    {
        void Initialize(IList<IPlayer> players, IBoard board);
    }
}
