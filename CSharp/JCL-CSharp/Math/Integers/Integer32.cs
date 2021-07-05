using GeneralTools;

namespace Math
{
    public class Integer32 : ICopiable<Integer32>, IZeroable<Integer32>, IIdentityable<Integer32>
    {
        public int Value;
        public Integer32(ParticularStatus particularStatus)
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
        public Integer32()
        {
            Value = 0;
        }

        public Integer32(int value)
        {
            Value = value;
        }
        public Integer32(Integer8 original)
        {
            Value = original.Value;
        }
        public Integer32(Integer16 original)
        {
            Value = original.Value;
        }

        public Integer32(Integer32 original)
        {
            Value = original.Value;
        }
        
        public Integer32(Integer64 original)
        {
            Value = (int) original.Value;
        }
        
        public Integer32(UInteger8 original)
        {
            Value = original.Value;
        }
        
        public Integer32(UInteger16 original)
        {
            Value = original.Value;
        }
        
        public Integer32(UInteger32 original)
        {
            Value = (int) original.Value;
        }
        
        public Integer32(UInteger64 original)
        {
            Value = (int) original.Value;
        }
        
        public Integer32 ShallowCopy()
        {
            return this;
        }

        public Integer32 SimpleDeepCopy()
        {
            return new(Value);
        }

        public Integer32 GetZero()
        {
            return new (0);
        }

        public bool IsZero()
        {
            return Value == 0;
        }

        public Integer32 GetIdentity()
        {
            return new (1);
        }

        public bool IsIdentity()
        {
            return Value == 1;
        }

        public Integer32 GetIdentityFactor()
        {
            return new (1 / Value);
        }
        
        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(object obj)
        {
            return IntegerTools.CompareWithInteger32(this, obj);
        }

        protected bool Equals(Integer32 other)
        {
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public static bool operator ==(Integer32 firstInt, object secondInt)
        {
            return IntegerTools.CompareWithInteger32(firstInt, secondInt);
        }

        public static bool operator !=(Integer32 firstInt, object secondInt)
        {
            return !(firstInt == secondInt);
        }

        public static Integer32 operator +(Integer32 firstInt)
        {
            IntegerTools.CheckForNull(firstInt);
            return new Integer32(firstInt.Value);
        }
        
        public static Integer32 operator +(Integer32 firstInt, Integer32 secondInt)
        {
            IntegerTools.CheckForNull(firstInt);
            return new Integer32(firstInt.Value + secondInt.Value);
        }
        
        public static Integer32 operator +(Integer16 firstInt, Integer32 secondInt)
        {
            IntegerTools.CheckForNull(firstInt);
            return new Integer32(firstInt.Value + secondInt.Value);
        }
        
    }
}