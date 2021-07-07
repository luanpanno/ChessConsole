using Chess.Entities.Enums;

namespace Chess.Entities.Pieces
{
    public class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "Q";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] moves = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            // esquerda
            pos.DefineValues(Position.Row, Position.Column - 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Row, pos.Column - 1);
            }

            // direita
            pos.DefineValues(Position.Row, Position.Column + 1);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Row, pos.Column + 1);
            }

            // acima
            pos.DefineValues(Position.Row - 1, Position.Column);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Row - 1, pos.Column);
            }

            // abaixo
            pos.DefineValues(Position.Row + 1, Position.Column);
            while (Board.IsPositionValid(pos) && CanMove(pos))
            {
                moves[pos.Row, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Row + 1, pos.Column);
            }

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