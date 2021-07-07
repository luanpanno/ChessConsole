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
        public bool Check { get; set; }

        public Match()
        {
            Board = new Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            IsOver = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            Check = false;

            DistributePieces();
        }

        public Piece Move(Position from, Position to)
        {
            Piece piece = Board.RemovePiece(from);

            piece.MovePiece();

            Piece capturedPiece = Board.RemovePiece(to);

            Board.PlacePiece(piece, to);

            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }

            return capturedPiece;
        }

        public void UndoMove(Position from, Position to, Piece capturedPiece)
        {
            Piece piece = Board.RemovePiece(to);

            piece.MovePieceBack();

            if (capturedPiece != null)
            {
                Board.PlacePiece(capturedPiece, to);
                CapturedPieces.Remove(capturedPiece);
            }

            Board.PlacePiece(piece, from);
        }

        public void TurnRound(Position from, Position to)
        {
            Piece capturedPiece = Move(from, to);

            if (IsKingInCheck(CurrentPlayer))
            {
                UndoMove(from, to, capturedPiece);

                throw new BoardException("You cannot put yourself in check");
            }

            Check = IsKingInCheck(Opponent(CurrentPlayer));

            if (CheckMate(Opponent(CurrentPlayer)))
            {
                IsOver = true;
            }
            else
            {
                Round++;
                ChangeCurrentPlayer();
            }

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

        private Color Opponent(Color color)
        {
            return color == Color.White ? Color.Black : Color.White;
        }

        private Piece King(Color color)
        {
            foreach (Piece piece in GetPiecesInGame(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }

            return null;
        }

        public bool IsKingInCheck(Color color)
        {
            Piece king = King(color);

            if (king == null)
            {
                throw new BoardException("No king with this color was found");
            }

            foreach (Piece piece in GetPiecesInGame(Opponent(color)))
            {
                bool[,] moves = piece.PossibleMoves();

                if (moves[king.Position.Row, king.Position.Column])
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckMate(Color color)
        {
            bool isInCheck = IsKingInCheck(color);

            if (!isInCheck)
            {
                return false;
            }

            foreach (Piece piece in GetPiecesInGame(color))
            {
                bool[,] moves = piece.PossibleMoves();

                for (int row = 0; row < Board.Rows; row++)
                {
                    for (int column = 0; column < Board.Columns; column++)
                    {
                        if (moves[row, column])
                        {
                            Position from = piece.Position;
                            Position destination = new Position(row, column);
                            Piece capturedPiece = Move(from, destination);
                            isInCheck = IsKingInCheck(color);

                            UndoMove(from, destination, capturedPiece);

                            if (!isInCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        public void PlaceNewPiece(char column, int row, Piece piece)
        {
            Board.PlacePiece(piece, new Notation(column, row).ToPosition());

            Pieces.Add(piece);
        }

        private void DistributePieces()
        {
            PlaceNewPiece('c', 1, new Rook(Board, Color.White));
            PlaceNewPiece('d', 1, new Rook(Board, Color.White));
            PlaceNewPiece('h', 7, new Rook(Board, Color.White));
            PlaceNewPiece('h', 6, new King(Board, Color.White));

            PlaceNewPiece('a', 8, new King(Board, Color.Black));
            PlaceNewPiece('b', 8, new Rook(Board, Color.Black));
        }
    }
}