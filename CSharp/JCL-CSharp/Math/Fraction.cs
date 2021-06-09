using System;
using GeneralTools;

namespace Math
{
    public class Fraction<T> : ICopiable<Fraction<T>>, IIdentityable<Fraction<T>>, IZeroable<Fraction<T>>, IAddable<Fraction<T>>, 
        ISubstractable<Fraction<T>>, IMultipliable<Fraction<T>>, IDividable<Fraction<T>> where T : IIdentityable<T>, 
        IZeroable<T>, ICopiable<T>, IAddable<T>, ISubstractable<T>, IMultipliable<T>, IDividable<T>, IDecompasable<T>, new()
    {
        private T _numerator;
        private T _denominator;

        public Fraction(T numerator, T denominator)
        {
            _numerator = numerator;
            if (!_denominator.IsZero())
                _denominator = denominator;
            else
                throw new ArithmeticException($"Error: expected non - zero denominator but got {denominator}");
        }

        public Fraction(T numerator)
        {
            _numerator = numerator;
            _denominator = numerator.GetIdentity();
        }

        public Fraction()
        {
            _numerator = new T().GetIdentity();
            _denominator = new T().GetIdentity();
        }
        
        public static Fraction<T> Identity => new Fraction<T>(new T().GetIdentity(), new T().GetIdentity());
        public static Fraction<T> Zero => new Fraction<T>(new T().GetZero(), new T().GetIdentity());
        
        public T Numerator => _numerator;
        public T Denominator => _denominator;
        
        public Fraction<T> ShallowCopy()
        {
            return this;
        }

        public Fraction<T> SimpleDeepCopy()
        {
            return new Fraction<T>(_numerator, _denominator);
        }

        public Fraction<T> DeepCopy()
        {
            return new (_numerator.SimpleDeepCopy(), _denominator.SimpleDeepCopy());
        }

        public Fraction<T> GetIdentity()
        {
            return Identity;
        }

        public bool IsIdentity()
        {
            return _numerator.IsIdentity() && _denominator.IsIdentity();
        }

        public Fraction<T> GetIdentityFactor()
        {
            return new(_denominator.SimpleDeepCopy(), _numerator.SimpleDeepCopy());
        }

        public Fraction<T> GetZero()
        {
            return Zero;
        }

        public bool IsZero()
        {
            return _numerator.IsZero();
        }

        public void Add(Fraction<T> element)
        {
            
        }

        public Fraction<T> Add(Fraction<T> firstElement, Fraction<T> secondElement)
        {
            Fraction<T> denominator
        }

        public void Substract(Fraction<T> element)
        {
            throw new NotImplementedException();
        }

        public Fraction<T> Substract(Fraction<T> firstElement, Fraction<T> secondElement)
        {
            throw new NotImplementedException();
        }

        public void Multiply(Fraction<T> element)
        {
            throw new NotImplementedException();
        }

        public Fraction<T> Multiply(Fraction<T> firstElement, Fraction<T> secondElement)
        {
            throw new NotImplementedException();
        }

        public void Divide(Fraction<T> element)
        {
            throw new NotImplementedException();
        }

        public Fraction<T> Divide(Fraction<T> firstElement, Fraction<T> secondElement)
        {
            throw new NotImplementedException();
        }
    }
}