using Chess.Entities.Enums;

namespace Chess.Entities
{
    public class Piece
    {
        public Board Board { get; protected set; }
        public Color Color { get; protected set; }
        public Position Position { get; set; }
        public int MovesCount { get; protected set; }

        public Piece() { }

        public Piece(Board board, Color color)
        {
            Board = board;
            Color = color;
            Position = null;
            MovesCount = 0;
        }

        public void MovePiece()
        {
            MovesCount++;
        }
    }
}