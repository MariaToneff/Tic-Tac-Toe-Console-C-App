using TicTacToe.Common;

namespace TicTacToe.Players
{
    public class Player : IPlayer
    {
        public Player(string name, FigureTypes figureType)
        {
            this.Name = name;
            this.FigureType = figureType;
        }
        public string Name { get; private set; }

        public FigureTypes FigureType { get; private set; }
    }
}
