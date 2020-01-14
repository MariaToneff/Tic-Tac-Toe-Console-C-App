using System.Collections.Generic;
using TicTacToe.Common;
using TicTacToe.Players;

namespace TicTacToe.InputProviders.Contracts
{
    public interface IInputProvider
    {
        IList<IPlayer> GetPlayers(int numberOfPlayers);
        Move GetNextPlayerMove(IPlayer player);
    }
}
