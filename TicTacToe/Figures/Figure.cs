using TicTacToe.Common;
using TicTacToe.Figures.Contracts;

namespace TicTacToe.Figures
{
    public class Figure : IFigure
    {
        public Figure(FigureTypes figureType)
        {
            this.FigureType = figureType;
        }
        public FigureTypes FigureType { get; set; }
    }
}
