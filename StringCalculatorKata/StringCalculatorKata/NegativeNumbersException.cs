using System;

namespace StringCalculatorKata
{
    public class NegativeNumbersException : Exception
    {
        public NegativeNumbersException(string message) : base(message)
        {
            
        }
    }
}