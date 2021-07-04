using Chess.Entities.Enums;

namespace Chess.Entities
{
    public class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovesCount { get; protected set; }
        public Board Board { get; protected set; }

        public Piece() { }

        public Piece(Position position, Color color, Board board)
        {
            Position = position;
            Color = color;
            Board = board;
            MovesCount = 0;
        }
    }
}