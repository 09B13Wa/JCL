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
    }
}