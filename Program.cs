using System;
using Chess.Entities;
using Chess.Entities.Enums;
using Chess.Entities.Pieces;
using Chess.Entities.Exceptions;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Clear();

                Board board = new Board(8, 8);

                board.PlacePiece(new Rook(board, Color.Black), new Position(0, 0));
                board.PlacePiece(new Rook(board, Color.Black), new Position(1, 3));
                board.PlacePiece(new King(board, Color.Black), new Position(2, 7));
                board.PlacePiece(new King(board, Color.White), new Position(3, 7));

                Screen.PrintBoard(board);

                Console.WriteLine();
            }
            catch (BoardException e)
            {
                Console.WriteLine("Board error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }
        }
    }
}
