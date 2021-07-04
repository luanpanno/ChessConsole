using Chess.Entities.Enums;

namespace Chess.Entities.Pieces
{
    public class King : Piece
    {
        public King(Board board, Color color) : base(board, color) { }

        public override bool[,] PossibleMoves()
        {
            bool[,] moves = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    position.DefineValues(Position.Row + i, Position.Column + j);

                    if (Board.IsPositionValid(position) && CanMove(position))
                    {
                        FillPosition(moves, position);
                    }
                }
            }

            return moves;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}