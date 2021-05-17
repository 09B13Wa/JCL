using System;
using System.Collections.Generic;

namespace Numbers
{
    public class UnsignedBinaryNumber : BinNumber
    {
        private List<int> BinaryRepresentation;
        private int Length;
        private int MaxValue;

        public UnsignedBinaryNumber(UnsignedBinaryNumber binaryNumber)
        {
            Length = binaryNumber.Length;
            MaxValue = binaryNumber.MaxValue;
            BinaryRepresentation = new List<int>();
            for (int i = Length - 1; i >= 0; i--)
                BinaryRepresentation.Add(binaryNumber.BinaryRepresentation[i]);
        }
        public static int MinimumLengthForRepresentation(int value){
            int length = 0;
            if (value == 0)
                length = 1;
            else{
                int powerOfTwo = 1;
                while (powerOfTwo - 1 < value){
                    length += 1;
                    powerOfTwo *= 2;
                }
            }
            return length;
        }

        
        public static List<int> toBinNumber(int integer){
            int listSize = MinimumLengthForRepresentation(integer);
            int powerOfTwo = (int)Math.Pow(2, listSize - 1);
            List<int> newRepresentation = new List<int>();
            for (int i = 0; i < listSize; i++){
                int valueToAdd = 0;
                if (integer >= powerOfTwo) {
                    valueToAdd = 1;
                    integer -= powerOfTwo;
                }
                newRepresentation.Add(valueToAdd);
                powerOfTwo /= 2;
            }

            return newRepresentation;
        }
        
        public int Squeeze(){
            int amountToShortenBy = 0;
            if (Length > 0){
                int index = 0;
                int digit = BinaryRepresentation[0];
                while (index < Length && digit == 0){
                    index += 1;
                    amountToShortenBy += 1;
                    digit = BinaryRepresentation[digit];
                }
            }
            ShortenBy(amountToShortenBy);
            return amountToShortenBy;
        }

        public static int MaxValueAbsoluteForLength(int length){
            int maxValue = 0;
            int powerOfTwo = 1;
            for (int i = 0; i < length; i++){
                maxValue += powerOfTwo;
                powerOfTwo *= 2;
            }
            return maxValue;
        }
        public void ShortenBy(int amount){
            if (amount <= Length){
                List<int> newRepresentation = new List<int>();
                int target = Length - amount;
                int newLength = 0;
                for (int i = target; i < Length; i++){
                    newRepresentation.Add(BinaryRepresentation[i]);
                    newLength += 1;
                }
                MaxValue = MaxValueAbsoluteForLength(newLength);
                Length = newLength;
                BinaryRepresentation = newRepresentation;
            }
            else throw new ArgumentException("Error: the amount " + amount + " is to great for to shorten by for the" +
                                                    "\nunsigned binary number of length " + Length);
        }


    }
}