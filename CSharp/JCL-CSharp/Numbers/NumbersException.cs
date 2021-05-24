using System;

namespace Numbers
{
    public class InvalidSignArrayException : Exception
    {
        public InvalidSignArrayException()
        {
        }

        public InvalidSignArrayException(string message)
            : base(message)
        {
        }

        public InvalidSignArrayException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    
    public class LengthNotDeclaredPrecisionException : Exception
    {
        public LengthNotDeclaredPrecisionException()
        {
        }

        public LengthNotDeclaredPrecisionException(string message)
            : base(message)
        {
        }

        public LengthNotDeclaredPrecisionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    
    public class NotABinaryNumberException : Exception
    {
        public NotABinaryNumberException()
        {
        }

        public NotABinaryNumberException(string message)
            : base(message)
        {
        }

        public NotABinaryNumberException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}