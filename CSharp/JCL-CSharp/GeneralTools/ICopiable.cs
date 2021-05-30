using System.Collections.Generic;

namespace GeneralTools
{
    public interface ICopiable<T>
    { 
        public T ShallowCopy();
        public T SimpleDeepCopy();
    }
}