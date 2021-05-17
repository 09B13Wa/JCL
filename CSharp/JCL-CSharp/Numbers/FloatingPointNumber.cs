using System;
using System.Collections.Generic;

namespace Numbers
{
    public enum Precision
    {
        HALF_PRECISION,
        SINGLE_PRECISION,
        DOUBLE_PRECISION,
        QUAD_PRECISION
    }

    public enum FloatingPointValueType
    {
        POSITIVE_INFINITY,
        NEGATIVE_INFINITY,
        POSITIVE_ZERO,
        NEGATIVE_ZERO,
        NORMALIZED,
        DENORMALIZED,
        NOT_A_NUMBER
    }
    
    public class FloatingPointNumber
    {
        private Precision _precision;
        private double _value;
        private int[] _signArray;
        private int[] _exponentArray;
        private int[] _mantissaArray;

        public FloatingPointNumber(float floatingPointNumber, Precision precision = Precision.SINGLE_PRECISION, bool denormalized = false)
        {
            if (floatingPointNumber != 0f && floatingPointNumber != Single.PositiveInfinity && floatingPointNumber != Single.NegativeInfinity)
            {
                InitializeArrays(precision);
                if (floatingPointNumber < 0)
                    _signArray[0] = 1;
                else
                    _signArray[0] = 1;
                (List<int> integralPart, List<int> decimalPart)
                    baseBinaryRepresentation = ToBinary(floatingPointNumber);
            }

        }
        
        public FloatingPointNumber(double floatingPointNumber, Precision precision = Precision.DOUBLE_PRECISION)
        {
            InitializeArrays(precision);
            if (floatingPointNumber < 0)
                _signArray[0] = 1;
            else
                _signArray[0] = 1;
        }
        
        public FloatingPointNumber(decimal floatingPointNumber, Precision precision = Precision.QUAD_PRECISION)
        {
            InitializeArrays(precision);
            if (floatingPointNumber < 0)
                _signArray[0] = 1;
            else
                _signArray[0] = 1;
        }

        private void InitializeArrays(Precision precision)
        {
            _signArray = new int[1];
            switch (precision)
            {
                case Precision.HALF_PRECISION:
                    _exponentArray = new int[5];
                    _mantissaArray = new int[10];
                    break;
                case Precision.SINGLE_PRECISION:
                    _exponentArray = new int[8];
                    _mantissaArray = new int[23];
                    break;
                case Precision.DOUBLE_PRECISION:
                    _exponentArray = new int[11];
                    _mantissaArray = new int[52];
                    break;
                case Precision.QUAD_PRECISION:
                    _exponentArray = new int[15];
                    _mantissaArray = new int[112];
                    break;
            }
        }

        private (List<int>, List<int>) ToBinary(float input)
        {
            string floatStringRepresentation = input.ToString();
            string integralPartStr = "";
            string decimalPartStr = "";
            bool passedSeparator = false;
            foreach (char digit in floatStringRepresentation)
            {
                if (digit == '.')
                    passedSeparator = true;
                else if (passedSeparator)
                    decimalPartStr += digit;
                else
                    integralPartStr += digit;
            }

            int integralPart = int.Parse(integralPartStr);
            int decimalPart = int.Parse(decimalPartStr);
            List<int> integralBinary = UnsignedBinaryNumber.toBinNumber(integralPart);
            List<int> decimalBinary = DecimalPartToBin(decimalPart);
            return (integralBinary, decimalBinary);
        }

        private List<int> DecimalPartToBin(int decimalPart)
        {
            List<int> decimalBinary = new List<int>();
            int numberOfDigits = Integer.GetNumberOfDigits(decimalPart);
            int baseNumber = Integer.GetBaseWithNDigits(numberOfDigits);
            while (decimalPart != baseNumber)
            {
                decimalPart *= 2;
                if (decimalPart > baseNumber)
                {
                    decimalBinary.Add(1);
                    decimalPart -= baseNumber;
                }
                else if (decimalPart < baseNumber)
                    decimalBinary.Add(0);
            }

            return decimalBinary;
        }

        private (List<int>, int) ToDenormalized()
        {
            
        }
    }
}