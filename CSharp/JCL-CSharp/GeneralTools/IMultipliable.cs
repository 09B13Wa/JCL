namespace GeneralTools
{
    public interface IMultipliable<T>
    {
        public void Multiply(T element);

        public T Multiply(T firstElement, T secondElement);

    }
}