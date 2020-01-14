using TicTacToe.Common;

namespace TicTacToe.Players
{
    public interface IPlayer
    {
        string Name { get; }
        FigureTypes FigureType { get; }
    }
}
