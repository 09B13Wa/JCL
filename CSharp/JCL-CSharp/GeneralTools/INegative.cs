namespace GeneralTools
{
    public interface INegative<T>
    {
        public void OppositeInstance();

        public T OppositeInstance(T element);
    }
}