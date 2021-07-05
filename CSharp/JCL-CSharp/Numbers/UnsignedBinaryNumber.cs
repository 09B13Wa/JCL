using System;
using System.Collections.Generic;
using GeneralTools;
using Math;

namespace Numbers
{
    public class UnsignedBinaryNumber : BinNumber, ICopiable<UnsignedBinaryNumber>
    { 
        public UnsignedBinaryNumber(UnsignedBinaryNumber binaryNumber)
        {
            _currentLength = binaryNumber.Length;
            _maxValue = binaryNumber.Maximum;
            _binaryRepresentation = new List<byte>();
            for (int i = Length - 1; i >= 0; i--)
                _binaryRepresentation.Add(binaryNumber._binaryRepresentation[i]);
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

        
        public static List<int> ToBinNumber(int integer){
            int listSize = MinimumLengthForRepresentation(integer);
            int powerOfTwo = Math.Math.PowerToInt(2, listSize - 1);
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
                int digit = _binaryRepresentation[0];
                while (index < Length && digit == 0){
                    index += 1;
                    amountToShortenBy += 1;
                    digit = _binaryRepresentation[digit];
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
                List<byte> newRepresentation = new List<byte>();
                int target = Length - amount;
                int newLength = 0;
                for (int i = target; i < Length; i++){
                    newRepresentation.Add(_binaryRepresentation[i]);
                    newLength += 1;
                }
                _maxValue = MaxValueAbsoluteForLength(newLength);
                _currentLength = newLength;
                _binaryRepresentation = newRepresentation;
            }
            else throw new ArgumentException("Error: the amount " + amount + " is to great for to shorten by for the" +
                                                    "\nunsigned binary number of length " + Length);
        }


        public int GetValue()
        {
            throw new NotImplementedException();
        }

        public override T GetValue<T>()
        {
            throw new NotImplementedException();
        }

        public UnsignedBinaryNumber ShallowCopy()
        {
            throw new NotImplementedException();
        }

        public UnsignedBinaryNumber SimpleDeepCopy()
        {
            throw new NotImplementedException();
        }
    }
}