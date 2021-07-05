using System.Collections.Generic;

namespace GeneralTools
{
    public interface IDecompasable<T>
    {
        public List<T> DecomposeInstance();

        public List<T> DecomposeInstance(T element);
    }
}