namespace GeneralTools
{
    public interface ISubstractable<T>
    {
        public void Substract(T element);

        public T Substract(T firstElement, T secondElement);
    }
}