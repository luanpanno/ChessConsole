using Chess.Entities.Enums;

namespace Chess.Entities.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color) { }


        public override string ToString()
        {
            return "B";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] moves = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            // NO
            pos.DefineValues(Position.Row - 1, Position.Column - 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Row - 1, pos.Column - 1);
            }

            // NE
            pos.DefineValues(Position.Row - 1, Position.Column + 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Row - 1, pos.Column + 1);
            }

            // SE
            pos.DefineValues(Position.Row + 1, Position.Column + 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Row + 1, pos.Column + 1);
            }

            // SO
            pos.DefineValues(Position.Row + 1, Position.Column - 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Row + 1, pos.Column - 1);
            }

            return moves;
        }
    }
}