using System.Collections.Generic;

namespace GeneralTools
{
    public interface IDecompasable<T>
    {
        public List<T> Decompose();

        public List<T> Decompose(T element);
    }
}