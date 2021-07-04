using Chess.Entities.Enums;
using Chess.Entities.Pieces;

namespace Chess.Entities
{
    public class Match
    {
        private Board Board;
        private int Round;
        private Color CurrentPlayer;

        public Match()
        {
            Board = new Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;

            DistributePieces();
        }

        public void Move(Position from, Position to)
        {
            Piece piece = Board.RemovePiece(from);

            piece.MovePiece();

            Piece capturedPiece = Board.RemovePiece(to);

            Board.PlacePiece(piece, to);
        }

        private void DistributePieces()
        {
            Board.PlacePiece(new Rook(Board, Color.Black), new Notation('c', 1).ToPosition());
        }
    }
}