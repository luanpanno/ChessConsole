using Chess.Entities.Enums;

namespace Chess.Entities.Pieces
{
    public class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "R";
        }
    }
}