using System;
using System.Collections.Generic;
using GeneralTools;

namespace Math
{
    public class Fraction<T> : ICopiable<Fraction<T>>, IIdentityable<Fraction<T>>, IZeroable<Fraction<T>>,
        IAddable<Fraction<T>>,
        ISubstractable<Fraction<T>>, IMultipliable<Fraction<T>>, IDividable<Fraction<T>>, IDecompasable<T> where T : IIdentityable<T>,
        IZeroable<T>, ICopiable<T>, IAddable<T>, ISubstractable<T>, IMultipliable<T>, IDividable<T>, IDecompasable<T>,
        IEquatable<T>, new()
    {
        private T _numerator;
        private T _denominator;

        public Fraction(T numerator, T denominator)
        {
            _numerator = numerator;
            CheckForZero(denominator);
            _denominator = denominator;
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

        public T Numerator { get => _numerator; private set => _numerator = value; }
        public T Denominator 
        { 
            get => _denominator; 
            private set
            {
                CheckForZero(value);
                _denominator = value; 
            } 
        }

        private void CheckForZero(T element)
        {
            if (element.IsZero())
                throw new ArithmeticException($"Error: expected non - zero denominator but got {element}");
        }
        
        private static void CheckForZeroDenominator(T element)
        {
            if (element.IsZero())
                throw new ArithmeticException($"Error: expected non - zero denominator but got {element}");
        }
        
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
        
        public void Simplify()
        {
            
        }

        private static (T, T, T) ToSameDenominator(Fraction<T> firstElement, Fraction<T> secondElement)
        {
            T denominator;
            T newFirstElement;
            T newSecondElement;
            if (!firstElement.Denominator.Equals(secondElement.Denominator))
            {
                denominator = firstElement.Denominator.MultiplyInstance(firstElement.Denominator, secondElement.Denominator);
                newFirstElement = firstElement.Numerator.MultiplyInstance(firstElement.Numerator, secondElement.Denominator);
                newSecondElement =
                    secondElement.Numerator.MultiplyInstance(secondElement.Numerator, firstElement.Denominator);
            }
            else
            {
                denominator = firstElement.Denominator.SimpleDeepCopy();
                newFirstElement = firstElement.Numerator;
                newSecondElement = secondElement.Numerator;
            }

            return (denominator, newFirstElement, newSecondElement);
        }
        
        public void AddInstance(Fraction<T> element)
        {
            (T denominator, T newFirstElement, T newSecondElement) = ToSameDenominator(this, element);
            CheckForZeroDenominator(denominator);
            _denominator = denominator;
            _numerator = newFirstElement.AddInstance(newFirstElement, newSecondElement);
        }
        public Fraction<T> AddInstance(Fraction<T> firstElement, Fraction<T> secondElement)
        {
            return Add(firstElement, secondElement, false);
        }
        public static Fraction<T> Add(Fraction<T> firstElement, Fraction<T> secondElement, bool simplify=true)
        {
            (T denominator, T newFirstElement, T newSecondElement) = ToSameDenominator(firstElement, secondElement);
            T numerator = newFirstElement.AddInstance(newFirstElement, newSecondElement);
            CheckForZeroDenominator(denominator);
            Fraction<T> addedFunction = new Fraction<T>(numerator, denominator);
            if (simplify)
                addedFunction.Simplify();
            return addedFunction;
        }

        public void SubstractInstance(Fraction<T> element)
        {
            (T denominator, T newFirstElement, T newSecondElement) = ToSameDenominator(this, element);
            CheckForZero(denominator);
            _denominator = denominator;
            _numerator = newFirstElement.SubstractInstance(newFirstElement, newSecondElement);
        }

        public Fraction<T> SubstractInstance(Fraction<T> firstElement, Fraction<T> secondElement)
        {
            return Substract(firstElement, secondElement, false);
        }

        public static Fraction<T> Substract(Fraction<T> firstElement, Fraction<T> secondElement, bool simplify=true)
        {
            (T denominator, T newFirstElement, T newSecondElement) = ToSameDenominator(firstElement, secondElement);
            CheckForZeroDenominator(denominator);
            T numerator = newFirstElement.SubstractInstance(newFirstElement, newSecondElement);
            Fraction<T> addedFunction = new Fraction<T>(numerator, denominator);
            if (simplify)
                addedFunction.Simplify();
            return addedFunction;
        }

        public void MultiplyInstance(Fraction<T> element)
        {
            Numerator = Numerator.MultiplyInstance(element.Numerator, _numerator);
            Denominator = Denominator.MultiplyInstance(element.Denominator, _denominator);
        }

        public Fraction<T> MultiplyInstance(Fraction<T> firstElement, Fraction<T> secondElement)
        {
            return Multiply(firstElement, secondElement);
        }

        public static Fraction<T> Multiply(Fraction<T> firstFraction, Fraction<T> secondFraction)
        {
            T numerator = firstFraction.Numerator.MultiplyInstance(firstFraction.Numerator, secondFraction.Numerator);
            T denominator = firstFraction.Denominator.MultiplyInstance(firstFraction.Denominator, secondFraction.Denominator);
            CheckForZeroDenominator(denominator);
            return new(numerator, denominator);
        }

        public void DivideInstance(Fraction<T> element)
        {
            
        }

        public Fraction<T> DivideInstance(Fraction<T> firstElement, Fraction<T> secondElement)
        {
            throw new NotImplementedException();
        }

        public static Fraction<T> Inverse(Fraction<T> fraction)
        {
            T numerator = fraction.Denominator;
            T denominator = fraction.Numerator;
            CheckForZeroDenominator(denominator);
            return new (numerator, denominator);
        }

        public void Inverse()
        {
            T numerator = Numerator;
            Numerator = Denominator;
            Denominator = numerator;
        }

        public List<T> DecomposeInstance()
        {
            throw new NotImplementedException();
        }

        public List<T> DecomposeInstance(T element)
        {
            throw new NotImplementedException();
        }
    }
}