using GeneralTools;

namespace Math
{
    public class Integer8: ICopiable<Integer8>, IZeroable<Integer8>, IIdentityable<Integer8>
    {
        public sbyte Value;

        public Integer8()
        {
            Value = 0;
        }
        
        public Integer8(ParticularStatus particularStatus)
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

        public Integer8(sbyte value)
        {
            Value = value;
        }
        
        public Integer8 ShallowCopy()
        {
            return this;
        }

        public Integer8 SimpleDeepCopy()
        {
            return new(Value);
        }

        public Integer8 GetZero()
        {
            return new ((long) 0);
        }

        public bool IsZero()
        {
            return Value == 0;
        }

        public Integer8 GetIdentity()
        {
            return new (1);
        }

        public bool IsIdentity()
        {
            return Value == 1;
        }

        public Integer8 GetIdentityFactor()
        {
            return new ((sbyte) (1 / Value));
        }
        
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}