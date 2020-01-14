using System;
using System.Collections.Generic;
using TicTacToe.Board.Contracts;
using TicTacToe.Common;
using TicTacToe.Common.Console;
using TicTacToe.Engine.Contracts;
using TicTacToe.Figures;
using TicTacToe.Figures.Contracts;
using TicTacToe.InputProviders.Contracts;
using TicTacToe.Players;
using TicTacToe.Renderers.Contracts;

namespace TicTacToe.Engine
{
    public class StandardTwoPlayerEngine : IGameEngine
    {
        private readonly IRenderer renderer;
        private readonly IInputProvider input;
        private readonly IBoard board;

        private IList<IPlayer> players;

        private int currentPlayerIndex;

        public StandardTwoPlayerEngine(IRenderer renderer, IInputProvider inputProvider)
        {
            this.renderer = renderer;
            this.input = inputProvider;
            this.board = new Board.Board();
        }

        public IEnumerable<IPlayer> Players
        {
            get
            {
                return new List<IPlayer>(this.players);
            }
        }
        public void Initialize(IGameInitializationStrategy gameInitializationStrategy)
        {
            this.players = this.input.GetPlayers(GlobalConstants.StandardGameNumberOfPlayers);

            this.SetFirstPlayerIndex();
            gameInitializationStrategy.Initialize(this.players, this.board);
            this.renderer.RenderBoard(this.board);
        }
        public void Start()
        {
            while (true)
            {
                try
                {
                    IPlayer player = this.GetNextPlayer();
                    IFigure figure = new Figure(player.FigureType);
                    var move = this.input.GetNextPlayerMove(player);
                    var to = move.Position;
                    this.CheckIfPositionIsEmpty(to);

                    board.AddFigure(figure, to);
                    this.renderer.RenderBoard(this.board);

                    try
                    {
                        WinningConditions(this.board);
                    }
                    catch (Exception ex)
                    {
                        this.renderer.PrintErrorMessage(ex.Message);
                        ConsoleHelpers.PrintWinner(player);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    this.currentPlayerIndex--;
                    this.renderer.PrintErrorMessage(ex.Message);
                }
            }
        }
        public void EndGame()
        {

        }
        public void WinningConditions(IBoard board)
        {
            //row check
            for (int row = GlobalConstants.MinimumRowValueOnBoard; row <= GlobalConstants.MaximumRowValueOnBoard; row++)
            {

                for (char col = GlobalConstants.MinimumColumnValueOnBoard; col < GlobalConstants.MaximumColumnValueOnBoard; col++)
                {
                    var figure1 = board.GetFigureAtPosition(new Position(row, col));
                    var figure2 = board.GetFigureAtPosition(new Position(row, ++col));
                    var figure3 = board.GetFigureAtPosition(new Position(row, ++col));

                    if (figure1 == null || figure2 == null || figure3 == null)
                    {
                        break;
                    }

                    if (figure1.FigureType == figure2.FigureType && figure2.FigureType == figure3.FigureType)
                    {
                        throw new Exception(GlobalConstants.GameOverMessage);
                    }
                }
            }

            //column check
            for (char col = GlobalConstants.MinimumColumnValueOnBoard; col < GlobalConstants.MaximumColumnValueOnBoard; col++)
            {

                for (int row = GlobalConstants.MinimumRowValueOnBoard; row <= GlobalConstants.MaximumRowValueOnBoard; row++)
                {
                    var figure1 = board.GetFigureAtPosition(new Position(row, col));
                    var figure2 = board.GetFigureAtPosition(new Position(++row, col));
                    var figure3 = board.GetFigureAtPosition(new Position(++row, col));

                    if (figure1 == null || figure2 == null || figure3 == null)
                    {
                        break;
                    }

                    if (figure1.FigureType == figure2.FigureType && figure2.FigureType == figure3.FigureType)
                    {
                        throw new Exception(GlobalConstants.GameOverMessage);
                    }
                }
            }

            //diagonal check
            for (int row = GlobalConstants.MinimumRowValueOnBoard; row <= GlobalConstants.MaximumRowValueOnBoard; row++)
            {

                for (char col = GlobalConstants.MinimumColumnValueOnBoard; col < GlobalConstants.MaximumColumnValueOnBoard; col++)
                {
                    var figure1 = board.GetFigureAtPosition(new Position(row, col));
                    var figure2 = board.GetFigureAtPosition(new Position(++row, ++col));
                    var figure3 = board.GetFigureAtPosition(new Position(++row, ++col));

                    if (figure1 == null || figure2 == null || figure3 == null)
                    {
                        break;
                    }

                    if (figure1.FigureType == figure2.FigureType && figure2.FigureType == figure3.FigureType)
                    {
                        throw new Exception(GlobalConstants.GameOverMessage);
                    }
                }
            }

            for (int row = GlobalConstants.MinimumRowValueOnBoard; row <= GlobalConstants.MaximumRowValueOnBoard; row++)
            {

                for (char col = GlobalConstants.MaximumColumnValueOnBoard; col > GlobalConstants.MinimumColumnValueOnBoard; col--)
                {
                    var figure1 = board.GetFigureAtPosition(new Position(row, col));
                    var figure2 = board.GetFigureAtPosition(new Position(++row, --col));
                    var figure3 = board.GetFigureAtPosition(new Position(++row, --col));

                    if (figure1 == null || figure2 == null || figure3 == null)
                    {
                        break;
                    }

                    if (figure1.FigureType == figure2.FigureType && figure2.FigureType == figure3.FigureType)
                    {
                        throw new Exception(GlobalConstants.GameOverMessage);
                    }
                }
            }
        }
        private IPlayer GetNextPlayer()
        {
            this.currentPlayerIndex++;
            if (this.currentPlayerIndex >= this.players.Count)
            {
                this.currentPlayerIndex = 0;
            }

            return this.players[this.currentPlayerIndex];
        }
        private void SetFirstPlayerIndex()
        {
            for (int i = 0; i < this.players.Count; i++)
            {
                if (this.players[i].FigureType == FigureTypes.X)
                {
                    this.currentPlayerIndex = i - 1;
                    return;
                }
            }
        }
        private void CheckIfPositionIsEmpty(Position position)
        {
            if (board.GetFigureAtPosition(position) != null)
            {
                throw new InvalidOperationException("The position is already taken!");
            }
        }
    }
}
