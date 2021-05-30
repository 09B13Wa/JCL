namespace Numbers
{
    public abstract class Number
    {
        public abstract bool IsZero();

        public static bool IsZero(Number number)
        {
            return number.IsZero();
        }
        public abstract Number GetIdentity();
        public static Number GetIdentity(Number number)
        {
            return number.GetIdentity();
        }

        public abstract bool IsIdentity();
        public abstract Number GetIdentityFactor();
        
    }
}