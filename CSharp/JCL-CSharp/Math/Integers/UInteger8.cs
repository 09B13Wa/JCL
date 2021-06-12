using GeneralTools;

namespace Math
{
    public class UInteger8: ICopiable<UInteger8>, IZeroable<UInteger8>, IIdentityable<UInteger8>
    {
        public byte Value;

        public UInteger8()
        {
            Value = 0;
        }
        
        public UInteger8(ParticularStatus particularStatus)
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

        public UInteger8(byte value)
        {
            Value = value;
        }
        
        public UInteger8 ShallowCopy()
        {
            return this;
        }

        public UInteger8 SimpleDeepCopy()
        {
            return new(Value);
        }

        public UInteger8 GetZero()
        {
            return new ((long) 0);
        }

        public bool IsZero()
        {
            return Value == 0;
        }

        public UInteger8 GetIdentity()
        {
            return new (1);
        }

        public bool IsIdentity()
        {
            return Value == 1;
        }

        public UInteger8 GetIdentityFactor()
        {
            return new ((byte) (1 / Value));
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is not null && IntegerTools.CompareWithUInteger8(this, obj);
        }

        public static bool operator ==(UInteger8 firstInteger8, UInteger8 secondInteger8)
        {
            bool equals;
            if (firstInteger8 is null && secondInteger8 is null)
                equals = true;
            else if (firstInteger8 is null || secondInteger8 is null)
                equals = false;
            else
                equals = firstInteger8.Value == secondInteger8.Value;
            return equals;
        }
        
        public static bool operator !=(UInteger8 firstInteger8, UInteger8 secondInteger8)
        {
            return !(firstInteger8 == secondInteger8);
        }
        
        public static UInteger8 operator +(UInteger8 uInteger8)
        {
            IntegerTools.CheckForNull(uInteger8);
            return new UInteger8(uInteger8.Value);
        }
        
        public static UInteger8 operator -(UInteger8 uInteger8)
        {
            IntegerTools.CheckForNull(uInteger8);
            return new UInteger8((byte) (-1 * uInteger8.Value));
        }

        public static UInteger8 operator +(UInteger8 uInteger8, UInteger8 secondInt)
        {
            IntegerTools.CheckForNull(uInteger8, secondInt);
            return new UInteger8((byte) (uInteger8.Value + secondInt.Value));
        }
        
        public static UInteger8 operator -(UInteger8 uInteger8, UInteger8 secondInt)
        {
            IntegerTools.CheckForNull(uInteger8, secondInt);
            return new UInteger8((byte) (uInteger8.Value - secondInt.Value));
        }
        
        public static UInteger8 operator *(UInteger8 uInteger8, UInteger8 secondInt)
        {
            IntegerTools.CheckForNull(uInteger8, secondInt);
            return new UInteger8((byte) (uInteger8.Value * secondInt.Value));
        }
        
        public static UInteger8 operator /(UInteger8 uInteger8, UInteger8 secondInt)
        {
            IntegerTools.CheckForNull(uInteger8, secondInt);
            return new UInteger8((byte) (uInteger8.Value / secondInt.Value));
        }
    }
}