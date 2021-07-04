using System;
using Chess.Entities;
using Chess.Entities.Enums;

namespace Chess
{
    public class Screen
    {
        public static void PrintBoard(Board board, bool[,] possibleMoves)
        {
            ConsoleColor originalBg = Console.BackgroundColor;
            ConsoleColor possibleMoveBg = ConsoleColor.DarkGray;

            for (int row = 0; row < board.Rows; row++)
            {
                Console.Write(8 - row + "| ");
                for (int column = 0; column < board.Columns; column++)
                {
                    Piece piece = board.Piece(new Position(row, column));

                    if (possibleMoves != null && possibleMoves[row, column])
                    {
                        Console.BackgroundColor = possibleMoveBg;
                    }

                    PrintPiece(piece);

                    Console.BackgroundColor = originalBg;
                }

                Console.WriteLine();
            }

            Console.WriteLine(" ------------------");
            Console.WriteLine("   a b c d e f g h");
        }

        public static Notation ReadNotationPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");

            return new Notation(column, row);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else if (piece.Color == Color.White)
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