namespace GeneralTools
{
    public interface IZeroable<T>
    {
        public T GetZero();

        public bool IsZero();
    }
}