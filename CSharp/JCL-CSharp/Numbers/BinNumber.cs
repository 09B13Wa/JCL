using System;
using System.Collections.Generic;
using System.IO;

namespace Numbers
{
    public abstract class BinNumber
    {
        private List<uint> BinaryRepresentation;
        private int MinValue;
        public int Minimum { get => MinValue; }
        private int MaxValue;
        public int Maximum { get => MaxValue; }
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
            List<uint> onesComplement = OnesComplement(representation);
            List<uint> twosComplement = new List<uint>();
            List<uint> one = new List<uint>();
            int numberOfDigits = onesComplement.Count;
            bool continueLoop = true;
            List<uint> remainder = new List<uint>();
            for (int i = 0; i <= numberOfDigits; i++)
            {
                remainder.Add(0);
                twosComplement.Add(0);
                if (i == numberOfDigits)
                    one.Add(1);
                else
                    one.Add(0);
            }

            if (numberOfDigits == 0)
                twosComplement[0] = 1;
            else
            {
                for (int position = numberOfDigits - 1; continueLoop && position >= 0; position--)
                {
                    uint currentNumber = onesComplement[position] + remainder[position + 1];
                    uint currentResultNumber = 0;
                    uint currentResultRemainder = 0;
                    switch (currentNumber)
                    {
                        case 0:
                            break;
                        case 1:
                            currentResultNumber = 1;
                            break;
                        case 2:
                            currentResultRemainder = 1;
                            break;
                        case 3:
                            currentResultNumber = 1;
                            currentResultRemainder = 1;
                            break;
                        default:
                            throw new ArgumentException($"Error: unexpected sum: {currentNumber} should be between 0 and 3 included.");
                    }

                    twosComplement[position] = currentResultNumber;
                    remainder[position + 1] = currentResultRemainder;
                }
            }
            
            return onesComplement;
        }

        public List<uint> GetBinaryRepresentation()
        {
            List<uint> copy = new List<uint>();
            foreach (uint digit in BinaryRepresentation)
                copy.Add(digit);
            return copy;
        }

        public abstract int GetValue();
    }
}