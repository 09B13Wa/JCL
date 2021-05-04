using System;
using System.Collections.Generic;
using System.IO;

namespace Numbers
{
    public class BinNumber
    {
        private List<uint> BinaryRepresentation;
        private int MinValue;
        private int MaxValue;
        private int CurrentLength;

        public static List<uint> OnesComplement(List<uint> representation)
        {
            List<uint> newRepresentation = new List<uint>();
            int numberOfDigits = representation.Count;
            for (int position = 0; position < numberOfDigits; position++)
            {
                uint digit = representation[position];
                if (digit == 0)
                    newRepresentation.Add(1);
                else if (digit == 1)
                    newRepresentation.Add(0);
                else
                    throw new ArgumentException($"Error: The digit {digit} is not 0 or 1 at position {position} " +
                                                "can't be part of a binary number.");
            }

            return newRepresentation;
        }

        public static List<uint> TwosComplement(List<uint> representation)
        {
            List<uint> result = OnesComplement(representation);
            int numberOfDigits = result.Count;
            bool continueLoop = true;
            List<uint> remainder = new List<uint>();
            for (int i = 0; i <= numberOfDigits; i++)
                remainder.Add(0);
            for (int position = numberOfDigits - 2; continueLoop && position >= 0; position--)
            {
                
            }

            return result;
        }
    }
}