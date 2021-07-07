using System;
using Chess.Entities.Enums;

namespace Chess.Entities.Pieces
{
    public class King : Piece
    {
        private Match Match;

        public King(Board board, Color color, Match match) : base(board, color)
        {
            Match = match;
        }

        private bool CheckRookForCastling(Position position)
        {
            Piece piece = Board.Piece(position);

            return piece != null && piece is Rook && piece.Color == Color && piece.MovesCount == 0;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            pos.DefineValues(Position.Row - 1, Position.Column);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row - 1, Position.Column + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row, Position.Column + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row + 1, Position.Column + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row + 1, Position.Column);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row + 1, Position.Column - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row, Position.Column - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row - 1, Position.Column - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            if (MovesCount == 0 && !Match.Check)
            {
                try
                {
                    Position posT1 = new Position(Position.Row, Position.Column + 3);
                    if (CheckRookForCastling(posT1))
                    {
                        Position p1 = new Position(Position.Row, Position.Column + 1);
                        Position p2 = new Position(Position.Row, Position.Column + 2);
                        if (Board.Piece(p1) == null && Board.Piece(p2) == null)
                        {
                            mat[Position.Row, Position.Column + 2] = true;
                        }
                    }

                    Position posT2 = new Position(Position.Row, Position.Column - 4);
                    if (CheckRookForCastling(posT2))
                    {
                        Position p1 = new Position(Position.Row, Position.Column - 1);
                        Position p2 = new Position(Position.Row, Position.Column - 2);
                        Position p3 = new Position(Position.Row, Position.Column - 3);
                        if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null)
                        {
                            mat[Position.Row, Position.Column - 2] = true;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine(e.Message);
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}