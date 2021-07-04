using Chess.Entities.Enums;

namespace Chess.Entities.Pieces
{
    public class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color) { }

        public override bool[,] PossibleMoves()
        {
            bool[,] moves = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            position.DefineValues(Position.Row - 1, Position.Column);
            while (Board.IsPositionValid(position) && CanMove(position))
            {
                FillPosition(moves, position);

                if (CheckPositionByColor(position))
                {
                    break;
                }

                position.Row = position.Row - 1;
            }

            position.DefineValues(Position.Row + 1, Position.Column);
            while (Board.IsPositionValid(position) && CanMove(position))
            {
                FillPosition(moves, position);

                if (CheckPositionByColor(position))
                {
                    break;
                }

                position.Row = position.Row + 1;
            }

            position.DefineValues(Position.Row, Position.Column + 1);
            while (Board.IsPositionValid(position) && CanMove(position))
            {
                FillPosition(moves, position);

                if (CheckPositionByColor(position))
                {
                    break;
                }

                position.Column = position.Column + 1;
            }

            position.DefineValues(Position.Row, Position.Column - 1);
            while (Board.IsPositionValid(position) && CanMove(position))
            {
                FillPosition(moves, position);

                if (CheckPositionByColor(position))
                {
                    break;
                }

                position.Column = position.Column - 1;
            }

            return moves;
        }

        private bool CheckPositionByColor(Position position)
        {
            return Board.Piece(position) != null && Board.Piece(position).Color != Color;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}