using TicTacToe.Common;

namespace TicTacToe.Figures.Contracts
{
    public interface IFigure
    {
        FigureTypes FigureType { get; set; }
    }
}
