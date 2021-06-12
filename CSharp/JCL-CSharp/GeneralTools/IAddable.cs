namespace GeneralTools
{
    public interface IAddable<T>
    {
        public void AddInstance(T element);

        public T AddInstance(T firstElement, T secondElement);
    }
}