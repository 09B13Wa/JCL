using System;
using System.Collections;

namespace Numbers
{
    public interface INumerable : IComparable, IList
    {
        public void Add();
        public BaseSign GetSign();
        public Number ToValue();
        public FloatingPointNumber ToFloatingPoint();
        public int ToInt();
        public long ToLong();
        public short ToShort();
        public sbyte ToSByte();
    }
}