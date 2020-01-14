using System.Collections.Generic;
using TicTacToe.Players;

namespace TicTacToe.Engine.Contracts
{
    public interface IGameEngine
    {
        IEnumerable<IPlayer> Players { get; }

        void Initialize(IGameInitializationStrategy gameInitializationStrategy);

        void Start();

        void WinningConditions();
    }
}
