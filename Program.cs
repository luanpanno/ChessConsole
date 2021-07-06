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
            Match match = new Match();

            while (!match.IsOver)
            {
                try
                {

                    Console.Clear();

                    Screen.PrintBoard(match.Board, null);

                    Console.WriteLine();

                    Console.WriteLine("Round: " + match.Round);
                    Console.WriteLine("Current player: " + match.CurrentPlayer);

                    Console.WriteLine();

                    Console.Write("From: ");
                    Position from = Screen.ReadNotationPosition().ToPosition();
                    match.ValidateInitialPosition(from);

                    bool[,] possibleMoves = match.Board.Piece(from).PossibleMoves();

                    Console.Clear();

                    Screen.PrintBoard(match.Board, possibleMoves);

                    Console.WriteLine();
                    Console.Write("To: ");
                    Position to = Screen.ReadNotationPosition().ToPosition();
                    match.ValidateMovePosition(from, to);

                    match.TurnRound(from, to);
                }
                catch (BoardException e)
                {
                    Console.WriteLine("Board error: " + e.Message);
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected error: " + e.Message);
                }
            }
        }
    }
}

