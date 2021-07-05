using GeneralTools;

namespace Math
{
    public class Integer16: ICopiable<Integer16>, IZeroable<Integer16>, IIdentityable<Integer16>
    {
        public short Value;

        public Integer16()
        {
            Value = 0;
        }
        
        public Integer16(ParticularStatus particularStatus)
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

        public Integer16(short value)
        {
            Value = value;
        }
        
        public Integer16 ShallowCopy()
        {
            return this;
        }

        public Integer16 SimpleDeepCopy()
        {
            return new(Value);
        }

        public Integer16 GetZero()
        {
            return new ((long) 0);
        }

        public bool IsZero()
        {
            return Value == 0;
        }

        public Integer16 GetIdentity()
        {
            return new (1);
        }

        public bool IsIdentity()
        {
            return Value == 1;
        }

        public Integer16 GetIdentityFactor()
        {
            return new ((short) (1 / Value));
        }
        
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}