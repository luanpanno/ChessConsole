using System;
using Chess.Entities.Enums;

namespace Chess.Entities
{
    public abstract class Piece
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

        public void MovePieceBack()
        {
            MovesCount--;
        }

        public virtual bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);

            return piece == null || piece.Color != Color;
        }

        public virtual void FillPosition(bool[,] moves, Position position)
        {
            moves[position.Row, position.Column] = Board.IsPositionValid(position) && CanMove(position);
        }

        public bool CheckPossibleMoves()
        {
            bool[,] moves = PossibleMoves();

            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (moves[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMoves()[position.Row, position.Column];
        }

        public abstract bool[,] PossibleMoves();
    }
}