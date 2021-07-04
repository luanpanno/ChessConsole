using System;
using Chess.Entities;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Board board = new Board(8, 8);

            Screen.PrintBoard(board);

            Console.WriteLine();
        }
    }
}
