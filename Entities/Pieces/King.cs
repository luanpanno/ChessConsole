using Chess.Entities.Enums;

namespace Chess.Entities.Pieces
{
    public class King : Piece
    {
        public King(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "K";
        }
    }
}