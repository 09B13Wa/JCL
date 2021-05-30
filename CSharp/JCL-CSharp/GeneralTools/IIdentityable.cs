
namespace GeneralTools
{
    public interface IIdentityable<T>
    {
        public T GetIdentity();

        public bool IsIdentity();

        public T GetIdentityFactor();
    }
}