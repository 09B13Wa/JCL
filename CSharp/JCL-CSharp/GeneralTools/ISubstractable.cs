namespace GeneralTools
{
    public interface ISubstractable<T>
    {
        public void SubstractInstance(T element);

        public T SubstractInstance(T firstElement, T secondElement);
    }
}