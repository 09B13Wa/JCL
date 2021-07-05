using GeneralTools;

namespace Math
{
    public class UInteger16: ICopiable<UInteger16>, IZeroable<UInteger16>, IIdentityable<UInteger16>
    {
        public ushort Value;

        public UInteger16()
        {
            Value = 0;
        }
        
        public UInteger16(ParticularStatus particularStatus)
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

        public UInteger16(ushort value)
        {
            Value = value;
        }
        
        public UInteger16 ShallowCopy()
        {
            return this;
        }

        public UInteger16 SimpleDeepCopy()
        {
            return new(Value);
        }

        public UInteger16 GetZero()
        {
            return new ((long) 0);
        }

        public bool IsZero()
        {
            return Value == 0;
        }

        public UInteger16 GetIdentity()
        {
            return new (1);
        }

        public bool IsIdentity()
        {
            return Value == 1;
        }

        public UInteger16 GetIdentityFactor()
        {
            return new ((ushort) (1 / Value));
        }
        
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}