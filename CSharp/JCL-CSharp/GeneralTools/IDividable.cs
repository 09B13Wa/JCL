namespace GeneralTools
{
    public interface IDividable<T>
    {
        public void Divide(T element);

        public T Divide(T firstElement, T secondElement);

    }
}