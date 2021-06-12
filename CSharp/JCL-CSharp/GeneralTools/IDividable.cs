namespace GeneralTools
{
    public interface IDividable<T>
    {
        public void DivideInstance(T element);

        public T DivideInstance(T firstElement, T secondElement);

    }
}