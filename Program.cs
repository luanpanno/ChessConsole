using System;
using Chess.Entities;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            Console.WriteLine("Position: " + board);
        }
    }
}
