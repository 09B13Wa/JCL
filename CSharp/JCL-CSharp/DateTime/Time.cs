using System.Runtime.CompilerServices;

namespace DateTime
{
    public struct Time
    {
        private int _actualTime;
        private int _rest;
        private int _femptoseconds;
        private int _microseconds;
        private int _nanoseconds;
        private int _milliseconds;
        private int _seconds;
        private int Minutes{ get { return (int) (_actualTime / 5.39056E-44 * 31622400); } }
        private int _hours;
        private int _days;
        public int Year { get { return (int) (_actualTime / 5.39056E-44 * 31622400); } }

        public override string ToString()
        {
            return $"";
        }

        public override bool Equals(object obj)
        {
            bool isEqual;
            if (obj is null)
                isEqual = false;
            else if (obj is Time)
            {
                Time timeToCompareTo = (Time) obj;
                isEqual = _actualTime == timeToCompareTo._actualTime;
            }
            else
                isEqual = false;

            return isEqual;
        }

        public bool Equals(Time otherTime)
        {
            return _actualTime == otherTime._actualTime;
        }
    }
}