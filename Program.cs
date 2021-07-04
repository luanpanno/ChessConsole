using System;
using Chess.Entities;
using Chess.Entities.Enums;
using Chess.Entities.Pieces;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Board board = new Board(8, 8);

            board.PlacePiece(new Rook(board, Color.Black), new Position(0, 0));
            board.PlacePiece(new Rook(board, Color.Black), new Position(1, 3));
            board.PlacePiece(new King(board, Color.Black), new Position(2, 4));

            Screen.PrintBoard(board);

            Console.WriteLine();
        }
    }
}
