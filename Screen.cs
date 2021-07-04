using System;
using Chess.Entities;

namespace Chess
{
    public class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int row = 0; row < board.Rows; row++)
            {
                for (int column = 0; column < board.Columns; column++)
                {
                    Piece piece = board.Piece(new Position(row, column));

                    if (piece == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(piece + " ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}