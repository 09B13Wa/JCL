namespace GeneralTools
{
    public interface IAddable<T>
    {
        public void Add(T element);

        public T Add(T firstElement, T secondElement);
    }
}