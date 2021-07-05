namespace GeneralTools
{
    public interface IMultipliable<T>
    {
        public void MultiplyInstance(T element);

        public T MultiplyInstance(T firstElement, T secondElement);

    }
}