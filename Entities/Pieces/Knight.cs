using Chess.Entities.Enums;

namespace Chess.Entities.Pieces
{
    public class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "N";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] moves = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            pos.DefineValues(Position.Row - 1, Position.Column - 2);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row - 2, Position.Column - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row - 2, Position.Column + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row - 1, Position.Column + 2);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row + 1, Position.Column + 2);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row + 2, Position.Column + 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row + 2, Position.Column - 1);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }
            pos.DefineValues(Position.Row + 1, Position.Column - 2);
            if (Board.IsPositionValid(pos) && CanMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
            }

            return moves;
        }
    }
}