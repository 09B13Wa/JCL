using System;
using System.Runtime.Remoting.Messaging;

namespace Math
{
    public class Math
    {
        public static double Pi => 3.141592653589793;
        public static double E => 2.718281828459045;

        public static int PowerToInt(int x, int n)
        {
            int power;
            if (n < 0)
            {
                if (x == 1)
                {
                    power = 1;
                }
                else
                    throw new ArithmeticException($"Error: expected positive int for n but got {n} with x not equal to one. (x = {x})");
            }
            else
            {
                int y = 1;
                if (n == 1)
                    power = 1;
                else
                {
                    while (n > 1)
                    {
                        if (n % 2 == 0)
                        {
                            x *= x;
                            n /= 2;
                        }
                        else
                        {
                            y *= x;
                            x *= x;
                            n = (n - 1) / 2;
                        }
                    }
                }

                power = y * x;
            }

            return power;
        }

        public static uint AbsoluteValue(uint value)
        {
            return value;
        }
        
        public static int AbsoluteValue(int value)
        {
            int absoluteValue;
            if (value < 0)
                absoluteValue = value * -1;
            else
                absoluteValue = value;
            return absoluteValue;
        }
        
        public static byte AbsoluteValue(byte value)
        {
            return value;
        }
        
        public static sbyte AbsoluteValue(sbyte value)
        {
            sbyte absoluteValue;
            sbyte minusOne = -1;
            if (value < 0)
                absoluteValue = (sbyte) (minusOne * value);
            else
                absoluteValue = value;
            return absoluteValue;
        }

        public static ushort AbsoluteValue(ushort value)
        {
            return value;
        }
        
        public static short AbsoluteValue(short value)
        {
            short absoluteValue;
            short minusOne = -1;
            if (value < 0)
                absoluteValue = (short) (minusOne * value);
            else
                absoluteValue = value;
            return absoluteValue;
        }
        
        public static ulong AbsoluteValue(ulong value)
        {
            return value;
        }
        
        public static long AbsoluteValue(long value)
        {
            long absoluteValue;
            if (value < 0)
                absoluteValue = value * -1;
            else
                absoluteValue = value;
            return absoluteValue;
        }
    }
}