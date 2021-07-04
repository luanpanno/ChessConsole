using System;

namespace Chess.Entities.Exceptions
{
    public class BoardException : Exception
    {
        public BoardException(string message) : base(message) { }
    }
}