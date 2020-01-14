using TicTacToe.Common;
using TicTacToe.Figures.Contracts;

namespace TicTacToe.Board.Contracts
{
    public interface IBoard
    {
        int TotalRows { get; }
        int TotalCols { get; }
        void AddFigure(IFigure figure, Position position);
        IFigure GetFigureAtPosition(Position position);
    }
}
