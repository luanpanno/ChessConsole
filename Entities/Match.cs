using Chess.Entities.Enums;
using Chess.Entities.Pieces;
using Chess.Entities.Exceptions;

namespace Chess.Entities
{
    public class Match
    {
        public Board Board { get; private set; }
        public int Round { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool IsOver { get; set; }

        public Match()
        {
            Board = new Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            IsOver = false;

            DistributePieces();
        }

        public void Move(Position from, Position to)
        {
            Piece piece = Board.RemovePiece(from);

            piece.MovePiece();

            Piece capturedPiece = Board.RemovePiece(to);

            Board.PlacePiece(piece, to);
        }

        public void TurnRound(Position from, Position to)
        {
            Move(from, to);
            Round++;
            ChangeCurrentPlayer();
        }

        public void ValidateInitialPosition(Position position)
        {
            Piece piece = Board.Piece(position);

            if (piece == null)
            {
                throw new BoardException("There's no piece at this position.");
            }

            if (CurrentPlayer != piece.Color)
            {
                throw new BoardException("The choosed piece at this position isn't yours.");
            }

            if (!piece.CheckPossibleMoves())
            {
                throw new BoardException("There's no possible moves at this position.");
            }
        }

        public void ValidateMovePosition(Position from, Position to)
        {
            if (!Board.Piece(from).CanMoveTo(to))
            {
                throw new BoardException("Invalid destination position.");

            }
        }

        public void ChangeCurrentPlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
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