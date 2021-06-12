using System;
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