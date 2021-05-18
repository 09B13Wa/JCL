using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

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

        public FloatingPointNumber(FloatingPointValueType specialKind)
        {
            switch (specialKind)
            {
                case FloatingPointValueType.POSITIVE_INFINITY:
                    break;
                case FloatingPointValueType.NEGATIVE_INFINITY:
                    break;
                case FloatingPointValueType.POSITIVE_ZERO:
                    break;
                case FloatingPointValueType.NEGATIVE_ZERO:
                    break;
                case FloatingPointValueType.NOT_A_NUMBER:
                    break;
                case FloatingPointValueType.DENORMALIZED:
                    break;
                case FloatingPointValueType.NORMALIZED:
                    break;
            }
        }

        public FloatingPointNumber(float floatingPointNumber, Precision precision = Precision.SINGLE_PRECISION, bool denormalized = false)
        {
            if (floatingPointNumber != 0f && floatingPointNumber != Single.PositiveInfinity && floatingPointNumber != Single.NegativeInfinity)
            {
                InitializeArrays(precision);
                if (floatingPointNumber < 0)
                    _signArray[0] = 1;
                else
                    _signArray[0] = 1;
                (List<int> integralPart, List<int> decimalPart) baseBinaryRepresentation = ToBinary(floatingPointNumber);
                (List<int> mantissa, int exponent) result = (null, 0);
                if (denormalized)
                    result = DenormalizedMantissa(baseBinaryRepresentation.integralPart,
                        baseBinaryRepresentation.decimalPart);
                else
                    result = NormalizedMantissa(baseBinaryRepresentation.integralPart,
                        baseBinaryRepresentation.decimalPart);
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

        private (List<int>, int) DenormalizedMantissa(List<int> integralPart, List<int> decimalPart)
        {
            List<int> denormalized = new List<int>();
            int integralPartLen = integralPart.Count;
            int offset = 0;
            int exponent = 0;
            
            while (integralPartLen != 0)
            {
                exponent += 1;
                decimalPart.Add(integralPart[offset]);
                integralPartLen -= 1;
            }

            bool isUseless = true;
            foreach (int digit in decimalPart)
            {
                if (isUseless && digit != 0)
                    isUseless = false;
                else if (!isUseless)
                {
                    denormalized.Insert(0, digit);
                    exponent -= 1;
                }
            }

            return (denormalized, exponent);
        }

        private (List<int>, int) NormalizedMantissa(List<int> integralPart, List<int> decimalPart)
        {
            List<int> normalized = new List<int>();
            int integralPartLen = integralPart.Count;
            int offset = 0;
            int exponent = 0;
            int index = 0;
            while (index < integralPartLen && integralPart[index] != 1)
                index += 1;
            return (normalized, exponent);
        }

        private FloatingPointValueType DetectActualType(float num, bool denormalized)
        {
            FloatingPointValueType actualType;
            if (num == 0f)
                actualType = FloatingPointValueType.POSITIVE_ZERO;
            else if (num == -0f)
                actualType = FloatingPointValueType.NEGATIVE_ZERO;
            else if (num is float.PositiveInfinity)
                actualType = FloatingPointValueType.POSITIVE_INFINITY;
            else if (num is float.NegativeInfinity)
                actualType = FloatingPointValueType.NEGATIVE_INFINITY;
            else if (num is float.NaN)
                actualType = FloatingPointValueType.NOT_A_NUMBER;
            else if (denormalized)
                actualType = FloatingPointValueType.DENORMALIZED;
            else
                actualType = FloatingPointValueType.NORMALIZED;
            return actualType;
        }
        
        private FloatingPointValueType DetectActualType(double num, bool denormalized)
        {
            FloatingPointValueType actualType;
            if (num == 0.0)
                actualType = FloatingPointValueType.POSITIVE_ZERO;
            else if (num == -0.0)
                actualType = FloatingPointValueType.NEGATIVE_ZERO;
            else if (num is double.PositiveInfinity)
                actualType = FloatingPointValueType.POSITIVE_INFINITY;
            else if (num is double.NegativeInfinity)
                actualType = FloatingPointValueType.NEGATIVE_INFINITY;
            else if (num is double.NaN)
                actualType = FloatingPointValueType.NOT_A_NUMBER;
            else if (denormalized)
                actualType = FloatingPointValueType.DENORMALIZED;
            else
                actualType = FloatingPointValueType.NORMALIZED;
            return actualType;
        }
        
        private FloatingPointValueType DetectActualType(decimal num, bool denormalized)
        {
            FloatingPointValueType actualType;
            if (num == 0)
                actualType = FloatingPointValueType.POSITIVE_ZERO;
            else if (num == -0)
                actualType = FloatingPointValueType.NEGATIVE_ZERO;
            else if (denormalized)
                actualType = FloatingPointValueType.DENORMALIZED;
            else
                actualType = FloatingPointValueType.NORMALIZED;
            return actualType;
        }
    }
}