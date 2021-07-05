using GeneralTools;

namespace Math
{
    public class UInteger64: ICopiable<UInteger64>, IZeroable<UInteger64>, IIdentityable<UInteger64>
    {
        public ulong Value;

        public UInteger64()
        {
            Value = 0;
        }
        
        public UInteger64(ParticularStatus particularStatus)
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

        public UInteger64(ulong value)
        {
            Value = value;
        }
        
        public UInteger64 ShallowCopy()
        {
            return this;
        }

        public UInteger64 SimpleDeepCopy()
        {
            return new(Value);
        }

        public UInteger64 GetZero()
        {
            return new ((ulong) 0);
        }

        public bool IsZero()
        {
            return Value == 0;
        }

        public UInteger64 GetIdentity()
        {
            return new (1);
        }

        public bool IsIdentity()
        {
            return Value == 1;
        }

        public UInteger64 GetIdentityFactor()
        {
            return new (1 / Value);
        }
        
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}