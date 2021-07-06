using System.Collections.Generic;
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
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;

        public Match()
        {
            Board = new Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            IsOver = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();

            DistributePieces();
        }

        public void Move(Position from, Position to)
        {
            Piece piece = Board.RemovePiece(from);

            piece.MovePiece();

            Piece capturedPiece = Board.RemovePiece(to);

            Board.PlacePiece(piece, to);

            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }
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

        public HashSet<Piece> GetCapturedPiecesByColor(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach (Piece piece in CapturedPieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }

            return aux;
        }

        public HashSet<Piece> GetPiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach (Piece piece in Pieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }

            aux.ExceptWith(GetCapturedPiecesByColor(color));

            return aux;
        }

        public void PlaceNewPiece(char column, int row, Piece piece)
        {
            Board.PlacePiece(piece, new Notation(column, row).ToPosition());

            Pieces.Add(piece);
        }

        private void DistributePieces()
        {
            PlaceNewPiece('c', 1, new Rook(Board, Color.White));
            PlaceNewPiece('c', 2, new Rook(Board, Color.White));
            PlaceNewPiece('d', 2, new Rook(Board, Color.White));
            PlaceNewPiece('e', 2, new Rook(Board, Color.White));
            PlaceNewPiece('e', 1, new Rook(Board, Color.White));
            PlaceNewPiece('d', 1, new King(Board, Color.White));

            PlaceNewPiece('c', 7, new Rook(Board, Color.Black));
            PlaceNewPiece('c', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('d', 7, new Rook(Board, Color.Black));
            PlaceNewPiece('e', 7, new Rook(Board, Color.Black));
            PlaceNewPiece('e', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('d', 8, new King(Board, Color.Black));
        }
    }
}