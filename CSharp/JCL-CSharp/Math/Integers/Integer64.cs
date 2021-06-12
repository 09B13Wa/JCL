using GeneralTools;

namespace Math
{
    public class Integer64: ICopiable<Integer64>, IZeroable<Integer64>, IIdentityable<Integer64>
    {
        public long Value;

        public Integer64()
        {
            Value = 0;
        }
        
        public Integer64(ParticularStatus particularStatus)
        {
            switch (particularStatus)
            {
                case ParticularStatus.ZERO:
                    Value = 0;
                    break;
                case ParticularStatus.IDENTITY:
                    Value = 1;
                    break;
                case ParticularStatus.NONE:
                    break;
            }
        }

        public Integer64(long value)
        {
            Value = value;
        }
        
        public Integer64 ShallowCopy()
        {
            return this;
        }

        public Integer64 SimpleDeepCopy()
        {
            return new(Value);
        }

        public Integer64 GetZero()
        {
            return new ((long) 0);
        }

        public bool IsZero()
        {
            return Value == 0;
        }

        public Integer64 GetIdentity()
        {
            return new (1);
        }

        public bool IsIdentity()
        {
            return Value == 1;
        }

        public Integer64 GetIdentityFactor()
        {
            return new (1 / Value);
        }
        
        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(object obj)
        {
            bool equals;
            if (obj is null)
                equals = false;
            else
            {
                equals = true;
            }

            return equals;
        }
    }
}