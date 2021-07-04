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

        public abstract bool[,] PossibleMoves();

        public void MovePiece()
        {
            MovesCount++;
        }

        public virtual bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);
            Console.WriteLine(piece);

            return piece == null || piece.Color != Color;
            // return true;
        }

        public virtual void FillPosition(bool[,] moves, Position position)
        {
            moves[position.Row, position.Column] = Board.IsPositionValid(position) && CanMove(position);
        }
    }
}