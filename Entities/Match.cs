using Chess.Entities.Enums;
using Chess.Entities.Pieces;

namespace Chess.Entities
{
    public class Match
    {
        public Board Board { get; private set; }
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
            Board.PlacePiece(new Rook(Board, Color.White), new Notation('c', 1).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.White), new Notation('c', 2).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.White), new Notation('d', 2).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.White), new Notation('e', 2).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.White), new Notation('e', 1).ToPosition());
            Board.PlacePiece(new King(Board, Color.White), new Notation('d', 1).ToPosition());

            Board.PlacePiece(new Rook(Board, Color.Black), new Notation('c', 7).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Black), new Notation('c', 8).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Black), new Notation('d', 7).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Black), new Notation('e', 7).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Black), new Notation('e', 8).ToPosition());
            Board.PlacePiece(new King(Board, Color.Black), new Notation('d', 8).ToPosition());
        }
    }
}