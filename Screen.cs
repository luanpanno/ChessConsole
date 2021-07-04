using System;
using Chess.Entities;
using Chess.Entities.Enums;

namespace Chess
{
    public class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int row = 0; row < board.Rows; row++)
            {
                Console.Write(8 - row + "| ");
                for (int column = 0; column < board.Columns; column++)
                {
                    Piece piece = board.Piece(new Position(row, column));

                    if (piece == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(piece);
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine(" ------------------");
            Console.WriteLine("   a b c d e f g h");
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece + " ");
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece + " ");
                Console.ForegroundColor = aux;

            }
        }
    }
}