using Chess.Entities.Enums;

namespace Chess.Entities.Pieces
{
    public class Pawn : Piece
    {
        private Match Match;

        public Pawn(Board board, Color color, Match match) : base(board, color)
        {
            Match = match;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool FreePosition(Position pos)
        {
            return Board.Piece(pos) == null;
        }

        private bool TheresEnemy(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p != null && p.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] moves = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.DefineValues(Position.Row - 1, Position.Column);
                if (Board.IsPositionValid(pos) && FreePosition(pos))
                {
                    moves[pos.Row, pos.Column] = true;
                }

                pos.DefineValues(Position.Row - 2, Position.Column);
                Position p2 = new Position(Position.Row - 1, Position.Column);
                if (Board.IsPositionValid(p2) && FreePosition(p2) && Board.IsPositionValid(pos) && FreePosition(pos) && MovesCount == 0)
                {
                    moves[pos.Row, pos.Column] = true;
                }

                pos.DefineValues(Position.Row - 1, Position.Column - 1);
                if (Board.IsPositionValid(pos) && TheresEnemy(pos))
                {
                    moves[pos.Row, pos.Column] = true;
                }

                pos.DefineValues(Position.Row - 1, Position.Column + 1);
                if (Board.IsPositionValid(pos) && TheresEnemy(pos))
                {
                    moves[pos.Row, pos.Column] = true;
                }

                if (Position.Row == 3)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);

                    if (Board.IsPositionValid(left) && TheresEnemy(left) && Board.Piece(left) == Match.EnPassantVulnerable)
                    {
                        moves[left.Row - 1, left.Column] = true;
                    }

                    Position right = new Position(Position.Row, Position.Column + 1);

                    if (Board.IsPositionValid(right) && TheresEnemy(right) && Board.Piece(right) == Match.EnPassantVulnerable)
                    {
                        moves[right.Row - 1, right.Column] = true;
                    }
                }
            }
            else
            {
                pos.DefineValues(Position.Row + 1, Position.Column);
                if (Board.IsPositionValid(pos) && FreePosition(pos))
                {
                    moves[pos.Row, pos.Column] = true;
                }

                pos.DefineValues(Position.Row + 2, Position.Column);
                Position p2 = new Position(Position.Row + 1, Position.Column);
                if (Board.IsPositionValid(p2) && FreePosition(p2) && Board.IsPositionValid(pos) && FreePosition(pos) && MovesCount == 0)
                {
                    moves[pos.Row, pos.Column] = true;
                }

                pos.DefineValues(Position.Row + 1, Position.Column - 1);
                if (Board.IsPositionValid(pos) && TheresEnemy(pos))
                {
                    moves[pos.Row, pos.Column] = true;
                }

                pos.DefineValues(Position.Row + 1, Position.Column + 1);
                if (Board.IsPositionValid(pos) && TheresEnemy(pos))
                {
                    moves[pos.Row, pos.Column] = true;
                }

                if (Position.Row == 4)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);

                    if (Board.IsPositionValid(left) && TheresEnemy(left) && Board.Piece(left) == Match.EnPassantVulnerable)
                    {
                        moves[left.Row + 1, left.Column] = true;
                    }

                    Position right = new Position(Position.Row, Position.Column + 1);

                    if (Board.IsPositionValid(right) && TheresEnemy(right) && Board.Piece(right) == Match.EnPassantVulnerable)
                    {
                        moves[right.Row + 1, right.Column] = true;
                    }
                }
            }

            return moves;
        }
    }
}