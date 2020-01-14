using System.Collections.Generic;
using TicTacToe.Board.Contracts;
using TicTacToe.Players;

namespace TicTacToe.Engine.Contracts
{
    public interface IGameEngine
    {
        IEnumerable<IPlayer> Players { get; }

        void Initialize(IGameInitializationStrategy gameInitializationStrategy);

        void Start();

        void WinningConditions(IBoard board);
    }
}
