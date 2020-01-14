using TicTacToe.Board.Contracts;
using TicTacToe.Common;
using TicTacToe.Figures.Contracts;

namespace TicTacToe.Board
{
    public class Board : IBoard
    {

        private readonly IFigure[,] board;
        public Board(
            int rows = GlobalConstants.StandardGameTotalBoardRows,
            int cols = GlobalConstants.StandardGameTotalBoardCols)
        {
            this.TotalRows = rows;
            this.TotalCols = cols;
            this.board = new IFigure[rows, cols];
        }
        public int TotalRows { get; private set; }

        public int TotalCols { get; private set; }

        public void AddFigure(IFigure figure, Position position)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, "Figure cannot be null!");
            Position.CheckIfValid(position);

            int arrRow = GetArrayRow(position.Row);
            int arrCol = GetArrayCol(position.Col);
            this.board[arrRow, arrCol] = figure;
        }

        public IFigure GetFigureAtPosition(Position position)
        {
            int arrRow = GetArrayRow(position.Row);
            int arrCol = GetArrayCol(position.Col);
            return this.board[arrRow, arrCol];
        }

        private int GetArrayRow(int boardRow)
        {
            return boardRow - 1;
        }

        private int GetArrayCol(char boardCol)
        {
            return boardCol - 'a';
        }
    }
}
