using GeneralTools;

namespace Math
{
    public class UInteger32 : ICopiable<UInteger32>, IZeroable<UInteger32>, IIdentityable<UInteger32>
    {
        public uint Value;

        public UInteger32()
        {
            Value = 0;
        }
        
        public UInteger32(ParticularStatus particularStatus)
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

        public UInteger32(uint value)
        {
            Value = value;
        }
        
        public UInteger32 ShallowCopy()
        {
            return this;
        }

        public UInteger32 SimpleDeepCopy()
        {
            return new(Value);
        }

        public UInteger32 GetZero()
        {
            return new ((uint) 0);
        }

        public bool IsZero()
        {
            return Value == 0;
        }

        public UInteger32 GetIdentity()
        {
            return new (1);
        }

        public bool IsIdentity()
        {
            return Value == 1;
        }

        public UInteger32 GetIdentityFactor()
        {
            return new (1 / Value);
        }
        
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}