using Chess.Entities.Enums;

namespace Chess.Entities.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color) { }

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
            }

            return moves;
        }
    }
}