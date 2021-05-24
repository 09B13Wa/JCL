using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Runtime.Remoting.Messaging;

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

        public BaseSign Sign
        {
            get => _signArray[0] == 0 ? BaseSign.POSITIVE : BaseSign.NEGATIVE;
            set => _signArray[0] = value == BaseSign.POSITIVE ?  0 : 1;
        }

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

        public FloatingPointNumber(float floatingPointNumber, Precision precision = Precision.SINGLE_PRECISION)
        {
            
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
        
        private FloatingPointValueType DetectActualType(double num)
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

        private void InitialSetUpBasedOnType(FloatingPointValueType type, float number)
        {
            switch (type)
            {
                case FloatingPointValueType.POSITIVE_INFINITY:
                case FloatingPointValueType.NEGATIVE_INFINITY:
                    SetUpInfinity(type);
                    break;
                case FloatingPointValueType.NEGATIVE_ZERO:
                case FloatingPointValueType.POSITIVE_ZERO:
                    SetUpZero(type);
                    break;
                case FloatingPointValueType.NOT_A_NUMBER:
                    SetUpNaN();
                    break;
                case FloatingPointValueType.DENORMALIZED:
                    SetUpDenormalized();
                    break;
            }
        }

        private void SetUpSign(BaseSign sign)
        {
            Sign = sign;
        }

        private void SetUpExponentArrayWithValue(int value)
        {
            int exponentArraySize = _exponentArray.Length;
            for (int i = 0; i < exponentArraySize; i++)
                _exponentArray[i] = value;
        }
        
        private void SetUpMantissaArrayWithValue(int value)
        {
            int mantissaArrayLength = _mantissaArray.Length;
            for (int i = 0; i < mantissaArrayLength; i++)
                _mantissaArray[i] = value;
        }

        private void SetUpInfinity(FloatingPointValueType infinityKind)
        {
            if (infinityKind is FloatingPointValueType.POSITIVE_INFINITY)
                SetUpSign(BaseSign.POSITIVE);
            else if (infinityKind is FloatingPointValueType.NEGATIVE_INFINITY)
                SetUpSign(BaseSign.NEGATIVE);
            else
                throw new ArgumentException($"Error: {infinityKind} is not a kind of infinity");
            SetUpExponentArrayWithValue(1);
            SetUpMantissaArrayWithValue(0);
        }

        private void SetUpNaN()
        {
            _signArray[0] = 0;
            SetUpExponentArrayWithValue(1);
            _mantissaArray[0] = 1;
        }

        private void SetUpZero(FloatingPointValueType zeroKind)
        {
            if (zeroKind is FloatingPointValueType.POSITIVE_ZERO)
                SetUpSign(BaseSign.POSITIVE);
            else if (zeroKind is FloatingPointValueType.NEGATIVE_ZERO)
                SetUpSign(BaseSign.NEGATIVE);
            else
                throw new ArgumentException($"Error: {zeroKind} is not a kind of zero");
            SetUpExponentArrayWithValue(0);
            SetUpMantissaArrayWithValue(0);
        }

        private void SetUpDenormalized(float input, Precision precision)
        {
            (List<int> integralPart, List<int> decimalPart) baseBinaryRepresentation = ToBinary(input);
            (List<int> mantissa, int exponent) result = DenormalizedMantissa(baseBinaryRepresentation.integralPart,
                baseBinaryRepresentation.decimalPart);
            SetUpExponentArrayWithValue(0);
            int exponent = result.exponent + (1 - GetBias(precision));
        }

        private int GetBias(Precision precision)
        {
            int bias = 0;
            switch (precision)
            {
                case Precision.HALF_PRECISION:
                    bias = 15;
                    break;
                case Precision.SINGLE_PRECISION:
                    bias = 127;
                    break;
                case Precision.DOUBLE_PRECISION:
                    bias = 1023;
                    break;
                case Precision.QUAD_PRECISION:
                    bias = 16383;
                    break;
            }

            return bias;
        }
        
        private int GetBias(int exponentLength)
        {
            int basePower = Math.Math.PowerToInt(2, exponentLength);

            return bias;
        }
    }
}