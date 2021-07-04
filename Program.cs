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

                Match match = new Match();

                Screen.PrintBoard(match.Board);

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
