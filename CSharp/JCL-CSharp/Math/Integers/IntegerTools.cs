using System;

namespace Math
{
    internal static class IntegerTools
    {
        private static bool CompareInteger8(Integer8 integer8Base, object secondObject)
        {
            bool isEqual;
            sbyte value = integer8Base.Value;
            if (secondObject is Integer8 integer8)
                isEqual = integer8.Value == value;
            else if (secondObject is UInteger8 uInteger8)
                isEqual = uInteger8.Value == value;
            else if (secondObject is Integer16 integer16)
                isEqual = integer16.Value == value;
            else if (secondObject is UInteger16 uInteger16)
                isEqual = uInteger16.Value == value;
            else if (secondObject is Integer32 integer32)
                isEqual = integer32.Value == value;
            else if (secondObject is UInteger32 uInteger32)
                isEqual = uInteger32.Value == value;
            else if (secondObject is Integer64 integer64)
                isEqual = integer64.Value == value;
            else if (secondObject is UInteger64 uInteger64)
                isEqual = uInteger64.Value == (ulong) value;
            else if (secondObject is int integer)
                isEqual = integer == value;
            else if (secondObject is uint uinteger)
                isEqual = uinteger == value;
            else if (secondObject is Int16 integer16Struct)
                isEqual = integer16Struct == value;
            else if (secondObject is UInt16 uinteger16Struct)
                isEqual = uinteger16Struct == value;
            else if (secondObject is Int64 integer64Struct)
                isEqual = integer64Struct == value;
            else if (secondObject is UInt64 uinteger64Struct)
                isEqual = uinteger64Struct == (ulong) value;
            else if (secondObject is float floatingPoint)
                isEqual = System.Math.Abs(floatingPoint - value) < 0.01;
            else if (secondObject is double doubleFloatingPoint)
                isEqual = System.Math.Abs(doubleFloatingPoint - value) < 0.0000001;
            else if (secondObject is decimal decimalFloatingPoint)
                isEqual = decimalFloatingPoint == value;
            else
                isEqual = false;
            return isEqual;
        }
        
        private static bool CompareInteger16(Integer16 integer16Base, object secondObject)
        {
            bool isEqual;
            short value = integer16Base.Value;
            if (secondObject is Integer8 integer8)
                isEqual = integer8.Value == value;
            else if (secondObject is UInteger8 uInteger8)
                isEqual = uInteger8.Value == value;
            else if (secondObject is Integer16 integer16)
                isEqual = integer16.Value == value;
            else if (secondObject is UInteger16 uInteger16)
                isEqual = uInteger16.Value == value;
            else if (secondObject is Integer32 integer32)
                isEqual = integer32.Value == value;
            else if (secondObject is UInteger32 uInteger32)
                isEqual = uInteger32.Value == value;
            else if (secondObject is Integer64 integer64)
                isEqual = integer64.Value == value;
            else if (secondObject is UInteger64 uInteger64)
                isEqual = uInteger64.Value == (ulong) value;
            else if (secondObject is int integer)
                isEqual = integer == value;
            else if (secondObject is uint uinteger)
                isEqual = uinteger == value;
            else if (secondObject is Int16 integer16Struct)
                isEqual = integer16Struct == value;
            else if (secondObject is UInt16 uinteger16Struct)
                isEqual = uinteger16Struct == value;
            else if (secondObject is Int64 integer64Struct)
                isEqual = integer64Struct == value;
            else if (secondObject is UInt64 uinteger64Struct)
                isEqual = uinteger64Struct == (ulong) value;
            else if (secondObject is float floatingPoint)
                isEqual = System.Math.Abs(floatingPoint - value) < 0.01;
            else if (secondObject is double doubleFloatingPoint)
                isEqual = System.Math.Abs(doubleFloatingPoint - value) < 0.0000001;
            else if (secondObject is decimal decimalFloatingPoint)
                isEqual = decimalFloatingPoint == value;
            else
                isEqual = false;
            return isEqual;
        }
        
        private static bool CompareInteger32(Integer32 integer32Base, object secondObject)
        {
            bool isEqual;
            int value = integer32Base.Value;
            if (secondObject is Integer8 integer8)
                isEqual = integer8.Value == value;
            else if (secondObject is UInteger8 uInteger8)
                isEqual = uInteger8.Value == value;
            else if (secondObject is Integer16 integer16)
                isEqual = integer16.Value == value;
            else if (secondObject is UInteger16 uInteger16)
                isEqual = uInteger16.Value == value;
            else if (secondObject is Integer32 integer32)
                isEqual = integer32.Value == value;
            else if (secondObject is UInteger32 uInteger32)
                isEqual = uInteger32.Value == value;
            else if (secondObject is Integer64 integer64)
                isEqual = integer64.Value == value;
            else if (secondObject is UInteger64 uInteger64)
                isEqual = uInteger64.Value == (ulong) value;
            else if (secondObject is int integer)
                isEqual = integer == value;
            else if (secondObject is uint uinteger)
                isEqual = uinteger == value;
            else if (secondObject is Int16 integer16Struct)
                isEqual = integer16Struct == value;
            else if (secondObject is UInt16 uinteger16Struct)
                isEqual = uinteger16Struct == value;
            else if (secondObject is Int64 integer64Struct)
                isEqual = integer64Struct == value;
            else if (secondObject is UInt64 uinteger64Struct)
                isEqual = uinteger64Struct == (ulong) value;
            else if (secondObject is float floatingPoint)
                isEqual = System.Math.Abs(floatingPoint - value) < 0.01;
            else if (secondObject is double doubleFloatingPoint)
                isEqual = System.Math.Abs(doubleFloatingPoint - value) < 0.0000001;
            else if (secondObject is decimal decimalFloatingPoint)
                isEqual = decimalFloatingPoint == value;
            else
                isEqual = false;
            return isEqual;
        }
        
        private static bool CompareInteger64(Integer64 integer64Base, object secondObject)
        {
            bool isEqual;
            long value = integer64Base.Value;
            if (secondObject is Integer8 integer8)
                isEqual = integer8.Value == value;
            else if (secondObject is UInteger8 uInteger8)
                isEqual = uInteger8.Value == value;
            else if (secondObject is Integer16 integer16)
                isEqual = integer16.Value == value;
            else if (secondObject is UInteger16 uInteger16)
                isEqual = uInteger16.Value == value;
            else if (secondObject is Integer32 integer32)
                isEqual = integer32.Value == value;
            else if (secondObject is UInteger32 uInteger32)
                isEqual = uInteger32.Value == value;
            else if (secondObject is Integer64 integer64)
                isEqual = integer64.Value == value;
            else if (secondObject is UInteger64 uInteger64)
                isEqual = uInteger64.Value == (ulong) value;
            else if (secondObject is int integer)
                isEqual = integer == value;
            else if (secondObject is uint uinteger)
                isEqual = uinteger == value;
            else if (secondObject is Int16 integer16Struct)
                isEqual = integer16Struct == value;
            else if (secondObject is UInt16 uinteger16Struct)
                isEqual = uinteger16Struct == value;
            else if (secondObject is Int64 integer64Struct)
                isEqual = integer64Struct == value;
            else if (secondObject is UInt64 uinteger64Struct)
                isEqual = uinteger64Struct == (ulong) value;
            else if (secondObject is float floatingPoint)
                isEqual = System.Math.Abs(floatingPoint - value) < 0.01;
            else if (secondObject is double doubleFloatingPoint)
                isEqual = System.Math.Abs(doubleFloatingPoint - value) < 0.0000001;
            else if (secondObject is decimal decimalFloatingPoint)
                isEqual = decimalFloatingPoint == value;
            else
                isEqual = false;
            return isEqual;
        }
        private static bool CompareUInteger8(UInteger8 uInteger8Base, object secondObject)
        {
            bool isEqual;
            byte value = uInteger8Base.Value;
            if (secondObject is Integer8 integer8)
                isEqual = integer8.Value == value;
            else if (secondObject is UInteger8 uInteger8)
                isEqual = uInteger8.Value == value;
            else if (secondObject is Integer16 integer16)
                isEqual = integer16.Value == value;
            else if (secondObject is UInteger16 uInteger16)
                isEqual = uInteger16.Value == value;
            else if (secondObject is Integer32 integer32)
                isEqual = integer32.Value == value;
            else if (secondObject is UInteger32 uInteger32)
                isEqual = uInteger32.Value == value;
            else if (secondObject is Integer64 integer64)
                isEqual = integer64.Value == value;
            else if (secondObject is UInteger64 uInteger64)
                isEqual = uInteger64.Value == value;
            else if (secondObject is int integer)
                isEqual = integer == value;
            else if (secondObject is uint uinteger)
                isEqual = uinteger == value;
            else if (secondObject is Int16 integer16Struct)
                isEqual = integer16Struct == value;
            else if (secondObject is UInt16 uinteger16Struct)
                isEqual = uinteger16Struct == value;
            else if (secondObject is Int64 integer64Struct)
                isEqual = integer64Struct == value;
            else if (secondObject is UInt64 uinteger64Struct)
                isEqual = uinteger64Struct == value;
            else if (secondObject is float floatingPoint)
                isEqual = System.Math.Abs(floatingPoint - value) < 0.01;
            else if (secondObject is double doubleFloatingPoint)
                isEqual = System.Math.Abs(doubleFloatingPoint - value) < 0.0000001;
            else if (secondObject is decimal decimalFloatingPoint)
                isEqual = decimalFloatingPoint == value;
            else
                isEqual = false;
            return isEqual;
        }
        
        private static bool CompareUInteger16(UInteger16 uInteger16Base, object secondObject)
        {
            bool isEqual;
            ushort value = uInteger16Base.Value;
            if (secondObject is Integer8 integer8)
                isEqual = integer8.Value == value;
            else if (secondObject is UInteger8 uInteger8)
                isEqual = uInteger8.Value == value;
            else if (secondObject is Integer16 integer16)
                isEqual = integer16.Value == value;
            else if (secondObject is UInteger16 uInteger16)
                isEqual = uInteger16.Value == value;
            else if (secondObject is Integer32 integer32)
                isEqual = integer32.Value == value;
            else if (secondObject is UInteger32 uInteger32)
                isEqual = uInteger32.Value == value;
            else if (secondObject is Integer64 integer64)
                isEqual = integer64.Value == value;
            else if (secondObject is UInteger64 uInteger64)
                isEqual = uInteger64.Value == value;
            else if (secondObject is int integer)
                isEqual = integer == value;
            else if (secondObject is uint uinteger)
                isEqual = uinteger == value;
            else if (secondObject is Int16 integer16Struct)
                isEqual = integer16Struct == value;
            else if (secondObject is UInt16 uinteger16Struct)
                isEqual = uinteger16Struct == value;
            else if (secondObject is Int64 integer64Struct)
                isEqual = integer64Struct == value;
            else if (secondObject is UInt64 uinteger64Struct)
                isEqual = uinteger64Struct == value;
            else if (secondObject is float floatingPoint)
                isEqual = System.Math.Abs(floatingPoint - value) < 0.01;
            else if (secondObject is double doubleFloatingPoint)
                isEqual = System.Math.Abs(doubleFloatingPoint - value) < 0.0000001;
            else if (secondObject is decimal decimalFloatingPoint)
                isEqual = decimalFloatingPoint == value;
            else
                isEqual = false;
            return isEqual;
        }
        
        private static bool CompareUInteger32(UInteger32 uInteger32Base, object secondObject)
        {
            bool isEqual;
            uint value = uInteger32Base.Value;
            if (secondObject is Integer8 integer8)
                isEqual = integer8.Value == value;
            else if (secondObject is UInteger8 uInteger8)
                isEqual = uInteger8.Value == value;
            else if (secondObject is Integer16 integer16)
                isEqual = integer16.Value == value;
            else if (secondObject is UInteger16 uInteger16)
                isEqual = uInteger16.Value == value;
            else if (secondObject is Integer32 integer32)
                isEqual = integer32.Value == value;
            else if (secondObject is UInteger32 uInteger32)
                isEqual = uInteger32.Value == value;
            else if (secondObject is Integer64 integer64)
                isEqual = integer64.Value == value;
            else if (secondObject is UInteger64 uInteger64)
                isEqual = uInteger64.Value == value;
            else if (secondObject is int integer)
                isEqual = integer == value;
            else if (secondObject is uint uinteger)
                isEqual = uinteger == value;
            else if (secondObject is Int16 integer16Struct)
                isEqual = integer16Struct == value;
            else if (secondObject is UInt16 uinteger16Struct)
                isEqual = uinteger16Struct == value;
            else if (secondObject is Int64 integer64Struct)
                isEqual = integer64Struct == value;
            else if (secondObject is UInt64 uinteger64Struct)
                isEqual = uinteger64Struct == value;
            else if (secondObject is float floatingPoint)
                isEqual = System.Math.Abs(floatingPoint - value) < 0.01;
            else if (secondObject is double doubleFloatingPoint)
                isEqual = System.Math.Abs(doubleFloatingPoint - value) < 0.0000001;
            else if (secondObject is decimal decimalFloatingPoint)
                isEqual = decimalFloatingPoint == value;
            else
                isEqual = false;
            return isEqual;
        }
        
        private static bool CompareUInteger64(UInteger64 uInteger64Base, object secondObject)
        {
            bool isEqual;
            ulong value = uInteger64Base.Value;
            if (secondObject is Integer8 integer8)
                isEqual = integer8.Value == (int) value;
            else if (secondObject is UInteger8 uInteger8)
                isEqual = uInteger8.Value == value;
            else if (secondObject is Integer16 integer16)
                isEqual = integer16.Value == (int) value;
            else if (secondObject is UInteger16 uInteger16)
                isEqual = uInteger16.Value == value;
            else if (secondObject is Integer32 integer32)
                isEqual = integer32.Value == (int) value;
            else if (secondObject is UInteger32 uInteger32)
                isEqual = uInteger32.Value == value;
            else if (secondObject is Integer64 integer64)
                isEqual = integer64.Value == (long) value;
            else if (secondObject is UInteger64 uInteger64)
                isEqual = uInteger64.Value == value;
            else if (secondObject is int integer)
                isEqual = integer == (int) value;
            else if (secondObject is uint uinteger)
                isEqual = uinteger == value;
            else if (secondObject is Int16 integer16Struct)
                isEqual = integer16Struct == (int) value;
            else if (secondObject is UInt16 uinteger16Struct)
                isEqual = uinteger16Struct == value;
            else if (secondObject is Int64 integer64Struct)
                isEqual = integer64Struct == (long) value;
            else if (secondObject is UInt64 uinteger64Struct)
                isEqual = uinteger64Struct == value;
            else if (secondObject is float floatingPoint)
                isEqual = System.Math.Abs(floatingPoint - value) < 0.01;
            else if (secondObject is double doubleFloatingPoint)
                isEqual = System.Math.Abs(doubleFloatingPoint - value) < 0.0000001;
            else if (secondObject is decimal decimalFloatingPoint)
                isEqual = decimalFloatingPoint == value;
            else
                isEqual = false;
            return isEqual;
        }
        private static bool CompareToRegularIntType(object regularIntRegular, object secondRegular)
        {
            bool isEqual;
            if (IsRegularIntType(secondRegular) || IsRegularDecimal(secondRegular))
                isEqual = regularIntRegular == secondRegular;
            else if (secondRegular is float floatRegular)
                isEqual = System.Math.Abs(floatRegular - (float)regularIntRegular) < 0.01;
            else if (secondRegular is double doubleRegular)
                isEqual = System.Math.Abs(doubleRegular - (double) regularIntRegular) < 0.0000001;
            else
                isEqual = false;
            return isEqual;
        }
        private static bool CompareToRegularFloatType(object regularFloatRegular, object secondRegular)
        {
            bool isEqual;
            if (IsRegularIntType(secondRegular) || IsRegularDecimal(secondRegular))
            {
                if (regularFloatRegular is float floatRegular)
                    isEqual = System.Math.Abs(floatRegular - (float) secondRegular) < 0.01;
                else if (regularFloatRegular is double doubleRegular)
                    isEqual = System.Math.Abs(doubleRegular - (double) secondRegular) < 0.0000001;
                //should never happen
                else
                    isEqual = false;
            }
            else if (IsRegularFloatType(secondRegular))
                isEqual = regularFloatRegular == secondRegular;
            else
                isEqual = false;
            return isEqual;
        }
        public static bool CompareWithInteger8(Integer8 integer8, object secondObject)
        {
            bool isEqual;
            if (integer8 is null && secondObject is null)
                isEqual = true;
            else if (integer8 is null || secondObject is null)
                isEqual = false;
            else
                isEqual = CompareInteger8(integer8, secondObject);
            return isEqual;
        }
        
        public static bool CompareWithUInteger8(UInteger8 uInteger8, object secondObject)
        {
            bool isEqual;
            if (uInteger8 is null && secondObject is null)
                isEqual = true;
            else if (uInteger8 is null || secondObject is null)
                isEqual = false;
            else
                isEqual = CompareUInteger8(uInteger8, secondObject);
            return isEqual;
        }
        
        public static bool CompareWithInteger16(Integer16 integer16, object secondObject)
        {
            bool isEqual;
            if (integer16 is null && secondObject is null)
                isEqual = true;
            else if (integer16 is null || secondObject is null)
                isEqual = false;
            else
                isEqual = CompareInteger16(integer16, secondObject);
            return isEqual;
        }
        
        public static bool CompareWithUInteger16(UInteger16 uInteger16, object secondObject)
        {
            bool isEqual;
            if (uInteger16 is null && secondObject is null)
                isEqual = true;
            else if (uInteger16 is null || secondObject is null)
                isEqual = false;
            else
                isEqual = CompareUInteger16(uInteger16, secondObject);
            return isEqual;
        }
        
        public static bool CompareWithInteger32(Integer32 integer32, object secondObject)
        {
            bool isEqual;
            if (integer32 is null && secondObject is null)
                isEqual = true;
            else if (integer32 is null || secondObject is null)
                isEqual = false;
            else
                isEqual = CompareInteger32(integer32, secondObject);
            return isEqual;
        }
        
        public static bool CompareWithUInteger32(UInteger32 uInteger32, object secondObject)
        {
            bool isEqual;
            if (uInteger32 is null && secondObject is null)
                isEqual = true;
            else if (uInteger32 is null || secondObject is null)
                isEqual = false;
            else
                isEqual = CompareUInteger32(uInteger32, secondObject);
            return isEqual;
        }
        
        public static bool CompareWithInteger64(Integer64 integer64, object secondObject)
        {
            bool isEqual;
            if (integer64 is null && secondObject is null)
                isEqual = true;
            else if (integer64 is null || secondObject is null)
                isEqual = false;
            else
                isEqual = CompareInteger64(integer64, secondObject);
            return isEqual;
        }
        
        public static bool CompareWithUInteger64(UInteger64 uInteger64, object secondObject)
        {
            bool isEqual;
            if (uInteger64 is null && secondObject is null)
                isEqual = true;
            else if (uInteger64 is null || secondObject is null)
                isEqual = false;
            else
                isEqual = CompareUInteger64(uInteger64, secondObject);
            return isEqual;
        }
        private static bool CompareToRegularDecimalType(object regularDecimalRegular, object secondRegular)
        {
            return CompareToRegularIntType(regularDecimalRegular, secondRegular);
        }
        public static bool IsRegularIntType(object obj)
        {
            return obj is int || obj is uint || obj is Int16 || obj is UInt16 || obj is Int64 || obj is UInt64;
        }
        public static bool IsRegularFloatType(object obj)
        {
            return obj is float || obj is double;
        }
        public static bool IsRegularDecimal(object obj)
        {
            return obj is decimal;
        }
        public static bool CompareTwoRegular(object firstRegular, object secondRegular)
        {
            bool isEqual;
            if (IsRegularIntType(firstRegular))
                isEqual = CompareToRegularIntType(firstRegular, secondRegular);
            else if (IsRegularFloatType(firstRegular))
                isEqual = CompareToRegularFloatType(firstRegular, secondRegular);
            else if (IsRegularDecimal(firstRegular))
                isEqual = CompareToRegularDecimalType(firstRegular, secondRegular);
            else
                isEqual = false;
            return isEqual;
        }
        private static bool IntegersEqual(object firstObject, object secondObject)
        {
            bool isEqual;
            if (firstObject is Integer8 firstInteger8)
                isEqual = CompareInteger8(firstInteger8, secondObject);
            else if (secondObject is Integer8 secondInteger8)
                isEqual = CompareInteger8(secondInteger8, firstObject);
            else if (firstObject is UInteger8 firstUInteger8)
                isEqual = CompareUInteger8(firstUInteger8, secondObject);
            else if (secondObject is UInteger8 secondUInteger8)
                isEqual = CompareUInteger8(secondUInteger8, firstObject);
            else if (firstObject is Integer16 firstInteger16)
                isEqual = CompareInteger16(firstInteger16, secondObject);
            else if (secondObject is Integer16 secondInteger16)
                isEqual = CompareInteger16(secondInteger16, firstObject);
            else if (firstObject is UInteger16 firstUInteger16)
                isEqual = CompareUInteger16(firstUInteger16, secondObject);
            else if (secondObject is UInteger16 secondUInteger16)
                isEqual = CompareUInteger16(secondUInteger16, firstObject);
            else if (firstObject is Integer32 firstInteger32)
                isEqual = CompareInteger32(firstInteger32, secondObject);
            else if (secondObject is Integer32 secondInteger32)
                isEqual = CompareInteger32(secondInteger32, firstObject);
            else if (firstObject is UInteger32 firstUInteger32)
                isEqual = CompareUInteger32(firstUInteger32, secondObject);
            else if (secondObject is UInteger32 secondUInteger32)
                isEqual = CompareUInteger32(secondUInteger32, firstObject);
            else if (firstObject is Integer64 firstInteger64)
                isEqual = CompareInteger64(firstInteger64, secondObject);
            else if (secondObject is Integer64 secondInteger64)
                isEqual = CompareInteger64(secondInteger64, firstObject);
            else if (firstObject is UInteger64 firstUInteger64)
                isEqual = CompareUInteger64(firstUInteger64, secondObject);
            else if (secondObject is UInteger64 secondUInteger64)
                isEqual = CompareUInteger64(secondUInteger64, firstObject);
            else if (IsRegularIntType(firstObject))
                isEqual = CompareToRegularIntType(firstObject, secondObject);
            else if (IsRegularFloatType(firstObject))
                isEqual = CompareToRegularFloatType(firstObject, secondObject);
            else if (IsRegularDecimal(firstObject))
                isEqual = CompareToRegularDecimalType(firstObject, secondObject);
            else if (IsRegularIntType(secondObject))
                isEqual = CompareToRegularIntType(secondObject, firstObject);
            else if (IsRegularFloatType(secondObject))
                isEqual = CompareToRegularFloatType(secondObject, firstObject);
            else if (IsRegularDecimal(secondObject))
                isEqual = CompareToRegularDecimalType(secondObject, firstObject);
            else
                isEqual = false;

            return isEqual;
        }

        public static bool CheckGeneric(object firstObject, object secondObject)
        {
            bool isEqual;
            if (firstObject is null && secondObject is null)
                isEqual = true;
            else if (firstObject is null || secondObject is null)
                isEqual = false;
            else
                isEqual = IntegersEqual(firstObject, secondObject);
            return isEqual;
        }

        public static void CheckForNull(object firstObject)
        {
            if (firstObject is null)
                throw new NullReferenceException("Error: this object can't be null for this operation but is null");
        }
        
        public static void CheckForNull(object firstObject, object secondObject)
        {
            if (firstObject is null)
                throw new NullReferenceException("Error: the first object can't be null for this operation but is null");
            if (secondObject is null)
                throw new NullReferenceException("Error: the second object can't be null for this operation but is null");
        }
        public static Integer8 AddWithInteger8(Integer8 integer8Param, object secondObject)
        {
            sbyte addedValue;
            sbyte value = integer8Param.Value;
            if (secondObject is Integer8 integer8)
                addedValue = (sbyte) (integer8.Value +  value);
            else if (secondObject is UInteger8 uInteger8)
                addedValue = (sbyte) (uInteger8.Value + value);
            else if (secondObject is Integer16 integer16)
                addedValue = (sbyte) (integer16.Value + value);
            else if (secondObject is UInteger16 uInteger16)
                addedValue = (sbyte) (uInteger16.Value + value);
            else if (secondObject is Integer32 integer32)
                addedValue = (sbyte) (integer32.Value + value);
            else if (secondObject is UInteger32 uInteger32)
                addedValue = (sbyte) (uInteger32.Value + value);
            else if (secondObject is Integer64 integer64)
                addedValue = (sbyte) (integer64.Value + (long) value);
            else if (secondObject is UInteger64 uInteger64)
                addedValue = (sbyte) (uInteger64.Value + (ulong) value);
            else if (secondObject is int integer)
                addedValue = (sbyte) (integer + value);
            else if (secondObject is uint uinteger)
                addedValue = (sbyte) (uinteger + value);
            else if (secondObject is Int16 integer16Struct)
                addedValue = (sbyte) (integer16Struct + (int) value);
            else if (secondObject is UInt16 uinteger16Struct)
                addedValue = (sbyte) (uinteger16Struct + value);
            else if (secondObject is Int64 integer64Struct)
                addedValue = (sbyte) (integer64Struct + (long) value);
            else if (secondObject is UInt64 uinteger64Struct)
                addedValue = (sbyte) (uinteger64Struct + (ulong) value);
            else if (secondObject is float floatingPoint)
                addedValue = (sbyte) (floatingPoint + value);
            else if (secondObject is double doubleFloatingPoint)
                addedValue = (sbyte) (doubleFloatingPoint + value);
            else if (secondObject is decimal decimalFloatingPoint)
                addedValue = (sbyte) (decimalFloatingPoint + value);
            else
                throw new ArithmeticException($"Error: unsupported type for adding to Integer 8");
            return new Integer8(addedValue);
            
        }
        public static UInteger8 AddWithUInteger8(UInteger8 uInteger8Param, object secondObject)
        {
            byte addedValue;
            byte value = uInteger8Param.Value;
            if (secondObject is Integer8 integer8)
                addedValue = (byte) (integer8.Value +  value);
            else if (secondObject is UInteger8 uInteger8)
                addedValue = (byte) (uInteger8.Value + value);
            else if (secondObject is Integer16 integer16)
                addedValue = (byte) (integer16.Value + value);
            else if (secondObject is UInteger16 uInteger16)
                addedValue = (byte) (uInteger16.Value + value);
            else if (secondObject is Integer32 integer32)
                addedValue = (byte) (integer32.Value + value);
            else if (secondObject is UInteger32 uInteger32)
                addedValue = (byte) (uInteger32.Value + value);
            else if (secondObject is Integer64 integer64)
                addedValue = (byte) (integer64.Value + (long) value);
            else if (secondObject is UInteger64 uInteger64)
                addedValue = (byte) (uInteger64.Value + (ulong) value);
            else if (secondObject is int integer)
                addedValue = (byte) (integer + value);
            else if (secondObject is uint uinteger)
                addedValue = (byte) (uinteger + value);
            else if (secondObject is Int16 integer16Struct)
                addedValue = (byte) (integer16Struct + (int) value);
            else if (secondObject is UInt16 uinteger16Struct)
                addedValue = (byte) (uinteger16Struct + value);
            else if (secondObject is Int64 integer64Struct)
                addedValue = (byte) (integer64Struct + (long) value);
            else if (secondObject is UInt64 uinteger64Struct)
                addedValue = (byte) (uinteger64Struct + (ulong) value);
            else if (secondObject is float floatingPoint)
                addedValue = (byte) (floatingPoint + value);
            else if (secondObject is double doubleFloatingPoint)
                addedValue = (byte) (doubleFloatingPoint + value);
            else if (secondObject is decimal decimalFloatingPoint)
                addedValue = (byte) (decimalFloatingPoint + value);
            else
                throw new ArithmeticException($"Error: unsupported type for adding to Integer 8");
            return new UInteger8(addedValue);
        }
        
        public static Integer16 AddWithInteger16(Integer16 integer16Param, object secondObject)
        {
            short addedValue;
            short value = integer16Param.Value;
            if (secondObject is Integer8 integer8)
                addedValue = (short) (integer8.Value +  value);
            else if (secondObject is UInteger8 uInteger8)
                addedValue = (short) (uInteger8.Value + value);
            else if (secondObject is Integer16 integer16)
                addedValue = (short) (integer16.Value + value);
            else if (secondObject is UInteger16 uInteger16)
                addedValue = (short) (uInteger16.Value + value);
            else if (secondObject is Integer32 integer32)
                addedValue = (short) (integer32.Value + value);
            else if (secondObject is UInteger32 uInteger32)
                addedValue = (short) (uInteger32.Value + value);
            else if (secondObject is Integer64 integer64)
                addedValue = (short) (integer64.Value + (long) value);
            else if (secondObject is UInteger64 uInteger64)
                addedValue = (short) (uInteger64.Value + (ulong) value);
            else if (secondObject is int integer)
                addedValue = (short) (integer + value);
            else if (secondObject is uint uinteger)
                addedValue = (short) (uinteger + value);
            else if (secondObject is Int16 integer16Struct)
                addedValue = (short) (integer16Struct + (int) value);
            else if (secondObject is UInt16 uinteger16Struct)
                addedValue = (short) (uinteger16Struct + value);
            else if (secondObject is Int64 integer64Struct)
                addedValue = (short) (integer64Struct + (long) value);
            else if (secondObject is UInt64 uinteger64Struct)
                addedValue = (short) (uinteger64Struct + (ulong) value);
            else if (secondObject is float floatingPoint)
                addedValue = (short) (floatingPoint + value);
            else if (secondObject is double doubleFloatingPoint)
                addedValue = (short) (doubleFloatingPoint + value);
            else if (secondObject is decimal decimalFloatingPoint)
                addedValue = (short) (decimalFloatingPoint + value);
            else
                throw new ArithmeticException($"Error: unsupported type for adding to Integer 8");
            return new Integer16(addedValue);
        }
        
        public static UInteger16 AddWithUInteger16(UInteger16 uInteger16Param, object secondObject)
        {
            ushort addedValue;
            ushort value = uInteger16Param.Value;
            if (secondObject is Integer8 integer8)
                addedValue = (ushort) (integer8.Value +  value);
            else if (secondObject is UInteger8 uInteger8)
                addedValue = (ushort) (uInteger8.Value + value);
            else if (secondObject is Integer16 integer16)
                addedValue = (ushort) (integer16.Value + value);
            else if (secondObject is UInteger16 uInteger16)
                addedValue = (ushort) (uInteger16.Value + value);
            else if (secondObject is Integer32 integer32)
                addedValue = (ushort) (integer32.Value + value);
            else if (secondObject is UInteger32 uInteger32)
                addedValue = (ushort) (uInteger32.Value + value);
            else if (secondObject is Integer64 integer64)
                addedValue = (ushort) (integer64.Value + (long) value);
            else if (secondObject is UInteger64 uInteger64)
                addedValue = (ushort) (uInteger64.Value + (ulong) value);
            else if (secondObject is int integer)
                addedValue = (ushort) (integer + value);
            else if (secondObject is uint uinteger)
                addedValue = (ushort) (uinteger + value);
            else if (secondObject is Int16 integer16Struct)
                addedValue = (ushort) (integer16Struct + (int) value);
            else if (secondObject is UInt16 uinteger16Struct)
                addedValue = (ushort) (uinteger16Struct + value);
            else if (secondObject is Int64 integer64Struct)
                addedValue = (ushort) (integer64Struct + (long) value);
            else if (secondObject is UInt64 uinteger64Struct)
                addedValue = (ushort) (uinteger64Struct + (ulong) value);
            else if (secondObject is float floatingPoint)
                addedValue = (ushort) (floatingPoint + value);
            else if (secondObject is double doubleFloatingPoint)
                addedValue = (ushort) (doubleFloatingPoint + value);
            else if (secondObject is decimal decimalFloatingPoint)
                addedValue = (ushort) (decimalFloatingPoint + value);
            else
                throw new ArithmeticException($"Error: unsupported type for adding to Integer 8");
            return new UInteger16(addedValue);
        }
    }
}