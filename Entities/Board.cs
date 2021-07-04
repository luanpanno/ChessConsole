using Chess.Entities.Exceptions;

namespace Chess.Entities
{
    public class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Board() { }

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[Rows, Columns];
        }

        public Piece Piece(Position position)
        {
            return Pieces[position.Row, position.Column];
        }

        public void PlacePiece(Piece piece, Position position)
        {
            if (PieceExists(position))
            {
                throw new BoardException("This position already has a piece");
            }

            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public Piece RemovePiece(Position position)
        {
            if (Piece(position) == null)
            {
                return null;
            }

            Piece aux = Piece(position);

            aux.Position = null;
            Pieces[position.Row, position.Column] = null;

            return aux;
        }

        public bool IsPositionValid(Position position)
        {
            return position.Row >= 0 && position.Row < Rows && position.Column >= 0 && position.Column < Columns;
        }

        public void ValidatePosition(Position position)
        {
            if (!IsPositionValid(position))
            {
                throw new BoardException("Invalid position");
            }
        }

        public bool PieceExists(Position position)
        {
            ValidatePosition(position);

            return Piece(position) != null;
        }
    }
}