using TicTacToe.Board.Contracts;

namespace TicTacToe.Renderers.Contracts
{
    public interface IRenderer
    {
        void RenderMainMenu();

        void RenderBoard(IBoard board);

        void PrintErrorMessage(string errorMessage);
    }
}
