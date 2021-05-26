namespace GeneralTools
{
    public interface ICopiable<T>
    {
        public T ShallowCopy();
        public T SimpleDeepCopy();
        public T DeepCopyTo(int depth);
        public T DeepestCopy();
    }
}