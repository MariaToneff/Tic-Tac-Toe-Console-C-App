namespace TicTacToe.Common
{
    public struct Move
    {
        public Move(Position position)
            :this()
        {
            this.Position = position;
        }

        public Position Position { get; private set; }
    }
}
