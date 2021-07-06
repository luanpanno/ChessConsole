using System;
using System.Collections.Generic;
using Chess.Entities;
using Chess.Entities.Enums;

namespace Chess
{
    public class Screen
    {
        public static void PrintMatch(Match match)
        {
            Console.Clear();

            Screen.PrintBoard(match.Board, null);

            Console.WriteLine();

            PrintCapturedPieces(match);

            Console.WriteLine("Round: " + match.Round);
            Console.WriteLine("Current player: " + match.CurrentPlayer);
        }

        public static void PrintCapturedPieces(Match match)
        {
            Console.WriteLine("Captured pieces:");
            Console.Write("Whites: ");
            PrintPiecesSet(match.GetCapturedPiecesByColor(Color.White));

            ConsoleColor aux = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("Blacks: ");
            PrintPiecesSet(match.GetCapturedPiecesByColor(Color.Black));

            Console.ForegroundColor = aux;

            Console.WriteLine();
        }

        public static void PrintPiecesSet(HashSet<Piece> piecesSet)
        {
            Console.Write("[");

            foreach (Piece piece in piecesSet)
            {
                Console.Write(piece + " ");
            }

            Console.WriteLine("]");
        }

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