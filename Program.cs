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

                Match match = new Match();

                while (!match.IsOver)
                {
                    Console.Clear();

                    Screen.PrintBoard(match.Board, null);

                    Console.WriteLine();

                    Console.Write("From: ");
                    Position from = Screen.ReadNotationPosition().ToPosition();

                    bool[,] possibleMoves = match.Board.Piece(from).PossibleMoves();

                    Console.Clear();

                    Screen.PrintBoard(match.Board, possibleMoves);

                    Console.WriteLine();
                    Console.WriteLine("From: " + from);
                    Console.Write("To: ");
                    Position to = Screen.ReadNotationPosition().ToPosition();

                    match.Move(from, to);

                }

            }
            catch (BoardException e)
            {
                Console.WriteLine("Board error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Unexpected error: " + e.Message);
            }
        }
    }
}
