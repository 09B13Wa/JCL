using System;
using System.Collections.Generic;
using System.Linq;
using GeneralTools;

namespace Math
{
    public class Fraction<T> : ICopiable<Fraction<T>>, IIdentityable<Fraction<T>>, IZeroable<Fraction<T>>,
        IAddable<Fraction<T>>, INegative<Fraction<T>>,
        ISubstractable<Fraction<T>>, IMultipliable<Fraction<T>>, IDividable<Fraction<T>>, IDecompasable<T> where T : IIdentityable<T>,
        IZeroable<T>, ICopiable<T>, IAddable<T>, ISubstractable<T>, IMultipliable<T>, IDividable<T>, IDecompasable<T>,
        IEquatable<T>, new()
    {
        private T _numerator;
        private T _denominator;
        private Sign _sign;

        public Fraction(T numerator, T denominator, Sign sign = Sign.POSITIVE)
        {
            _numerator = numerator;
            CheckForZero(denominator);
            _denominator = denominator;
            _sign = sign;
        }

        public Fraction(T numerator, Sign sign = Sign.POSITIVE)
        {
            _numerator = numerator;
            _denominator = numerator.GetIdentity();
            _sign = sign;
        }

        public Fraction(Sign sign = Sign.POSITIVE)
        {
            _numerator = TIdentity;
            _denominator = TIdentity;
            _sign = sign;
        }
        
        public static Fraction<T> Identity => new Fraction<T>(TIdentity, TIdentity);
        public static Fraction<T> Zero => new Fraction<T>(TZero, TIdentity);
        public static T TIdentity => new T().GetIdentity();
        public static T TZero => new T().GetZero();

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
        
        public Sign Sign { get => _sign; private set => _sign = value; }

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
            (List<T> numeratorToSimplify, List<T> denominatorToSimplify) = WithoutDuplicates(this);
            (int numberOfElementsNumerator, int numberOfElementsDenominator) =
                (numeratorToSimplify.Count, denominatorToSimplify.Count);
            T numerator = TIdentity;
            T denominator = TIdentity;
            for (int numeratorIndex = 0; numeratorIndex < numberOfElementsNumerator; numeratorIndex++)
                numerator.MultiplyInstance(numeratorToSimplify[numeratorIndex]);
            for (int denominatorIndex = 0; denominatorIndex < numberOfElementsDenominator; denominatorIndex++)
                denominator.MultiplyInstance(denominatorToSimplify[denominatorIndex]);
            Numerator = numerator;
            Denominator = denominator;
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

        public static Fraction<T> Multiply(Fraction<T> firstFraction, Fraction<T> secondFraction, bool simplify = true)
        {
            T numerator = firstFraction.Numerator.MultiplyInstance(firstFraction.Numerator, secondFraction.Numerator);
            T denominator = firstFraction.Denominator.MultiplyInstance(firstFraction.Denominator, secondFraction.Denominator);
            CheckForZeroDenominator(denominator);
            Fraction<T> multiplied = new Fraction<T>(numerator, denominator);
            if (simplify)
                multiplied.Simplify();
            return multiplied;
        }

        public void DivideInstance(Fraction<T> element)
        {
            Fraction<T> division = Divide(this, element);
            Numerator = division.Numerator;
            Denominator = division.Denominator;
        }

        public Fraction<T> DivideInstance(Fraction<T> firstElement, Fraction<T> secondElement)
        {
            return Divide(firstElement, secondElement);
        }

        public static Fraction<T> Divide(Fraction<T> numerator, Fraction<T> denominator)
        {
            return Multiply(numerator, Inverse(denominator));
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

        private static (List<T>, List<T>) WithoutDuplicates(Fraction<T> fraction)
        {
            List<T> minimalNumberOfElementsList = fraction.Numerator.DecomposeInstance();
            List<T> maximumNumberOfElementsList = fraction.Denominator.DecomposeInstance();
            int numberOfElementsInNumerator = minimalNumberOfElementsList.Count;
            int numberOfElementsInDenominator = maximumNumberOfElementsList.Count;
            int minimalNumberOfElements = numberOfElementsInNumerator;
            int maximumNumberOfElements = numberOfElementsInDenominator;
            bool swaped = false;
            if (numberOfElementsInNumerator > numberOfElementsInDenominator)
            {
                (minimalNumberOfElements, maximumNumberOfElements) = (maximumNumberOfElements, minimalNumberOfElements);
                (minimalNumberOfElementsList, maximumNumberOfElementsList) = (maximumNumberOfElementsList, minimalNumberOfElementsList);
                swaped = true;
            }
            for (int minimalIndex = 0; minimalIndex < minimalNumberOfElements; minimalIndex++)
            {
                for (int maximumIndex = 0; maximumIndex < maximumNumberOfElements; maximumIndex++)
                {
                    if (minimalNumberOfElementsList[minimalIndex].Equals(maximumNumberOfElementsList[maximumIndex]))
                    {
                        minimalNumberOfElementsList.RemoveAt(minimalIndex);
                        maximumNumberOfElementsList.RemoveAt(maximumIndex);
                    }
                }
            }

            (List<T> numerator, List<T> denominator) = (new List<T>(), new List<T>());
            if (swaped)
            {
                numerator = maximumNumberOfElementsList;
                denominator = minimalNumberOfElementsList;
            }
            else
            {
                numerator = minimalNumberOfElementsList;
                denominator = maximumNumberOfElementsList;
            }

            return (numerator, denominator);
        }

        public List<T> DecomposeInstance()
        {
            List<T> minimalNumberOfElementsList = Numerator.DecomposeInstance();
            List<T> maximumNumberOfElementsList = Denominator.DecomposeInstance();
            int numberOfElementsInNumerator = minimalNumberOfElementsList.Count;
            int numberOfElementsInDenominator = maximumNumberOfElementsList.Count;
            int minimalNumberOfElements = numberOfElementsInNumerator;
            int maximumNumberOfElements = numberOfElementsInDenominator;
            bool swaped = false;
            if (numberOfElementsInNumerator > numberOfElementsInDenominator)
            {
                (minimalNumberOfElements, maximumNumberOfElements) = (maximumNumberOfElements, minimalNumberOfElements);
                (minimalNumberOfElementsList, maximumNumberOfElementsList) = (maximumNumberOfElementsList, minimalNumberOfElementsList);
                swaped = true;
            }
            for (int minimalIndex = 0; minimalIndex < minimalNumberOfElements; minimalIndex++)
            {
                for (int maximumIndex = 0; maximumIndex < maximumNumberOfElements; maximumIndex++)
                {
                    if (minimalNumberOfElementsList[minimalIndex].Equals(maximumNumberOfElementsList[maximumIndex]))
                    {
                        minimalNumberOfElementsList.RemoveAt(minimalIndex);
                        maximumNumberOfElementsList.RemoveAt(maximumIndex);
                    }
                }
            }

            List<T> combinedList = new List<T>();
            if (swaped)
            {
                combinedList.AddRange(minimalNumberOfElementsList);
                //TODO: add way of distinguishing
                combinedList.AddRange(maximumNumberOfElementsList);
            }
            else
            {
                combinedList.AddRange(maximumNumberOfElementsList);
                combinedList.AddRange(maximumNumberOfElementsList);
            }

            return combinedList;
        }

        public List<T> DecomposeInstance(T element)
        {
            return element.DecomposeInstance();
        }

        public static Fraction<T> operator +(Fraction<T> fraction)
        {
            return new (fraction.Numerator, fraction.Denominator);
        }

        public void OppositeInstance()
        {
            Sign = Opposite(this).Sign;
        }

        public Fraction<T> OppositeInstance(Fraction<T> element)
        {
            return Opposite(element);
        }

        public static Fraction<T> Opposite(Fraction<T> fraction)
        {
            Sign oppositeSign = fraction.Sign;
            switch (fraction._sign)
            {
                case Sign.POSITIVE:
                    oppositeSign = Sign.NEGATIVE;
                    break;
                case Sign.NEGATIVE:
                    oppositeSign = Sign.POSITIVE;
                    break;
                case Sign.ZERO:
                    oppositeSign = Sign.ZERO;
                    break;
            }

            return new Fraction<T>(fraction.Numerator, fraction.Denominator, oppositeSign);
        }

        public static Fraction<T> operator -(Fraction<T> fraction)
        {
            if (TIdentity is INegative<T>)
            {
                return Opposite(fraction);
            }
            else
                throw new ArithmeticException("Error: cannot change signes as this type only supports positive values");
        }

        private string BuildStringOfCertainLength(char character, int length)
        {
            string line = string.Empty;
            for (int i = 0; i < length; i++)
                line += character;
            return line;
        }

        private string BuildSeperationLine(int length, int spacing)
        {
            string seperationLine = string.Empty;
            int firstTarget = spacing / 2;
            int secondTarget = firstTarget + spacing % 2;
            for (int line = 0; line < firstTarget; line++)
                seperationLine += BuildStringOfCertainLength('=', length);
            for (int line = firstTarget; line < secondTarget; line++)
                seperationLine += BuildStringOfCertainLength('-', length);
            for (int line = secondTarget; line < spacing; line++)
                seperationLine += BuildStringOfCertainLength('=', length);
            return seperationLine;
        }

        private int CountChars(string toCount, char c)
        {
            int charCount = 0;
            foreach (char ch in toCount)
                if (c == ch)
                    charCount += 1;
            return charCount;
        }

        private string ToExtraFatFunction(int spacing = 3)
        {
            (string top, string middle, string bottom) text = (Numerator.ToString(), "", Denominator.ToString());
            (int top, int middle, int bottom) widths = (text.top.Length, 0, text.bottom.Length);
            widths.middle = widths.top;
            (int width, bool top) lowestLength = (widths.bottom, false);
            if (widths.bottom > widths.middle)
            {
                widths.middle = widths.bottom;
                lowestLength.width = widths.top;
                lowestLength.top = true;
            }
            widths.middle += 2;
            (int size, string text) sign = _sign is Sign.NEGATIVE ? (2, "- ") : (0, "");
                
            text.middle = BuildSeperationLine(widths.middle, spacing);
            int requiredOffSet = (widths.middle - lowestLength.width) / 2 + sign.size;
            (string additional, string regular) newSpace = ("", "");
            string[] lines = text.top.Split('\n');
            string extraSpace = BuildStringOfCertainLength(' ', requiredOffSet);
            foreach (string line in lines)
                newSpace.additional = extraSpace + line + '\n';
            lines = text.bottom.Split('\n');
            extraSpace = BuildStringOfCertainLength(' ', sign.size + 1);
            foreach (string line in lines)
                newSpace.regular = extraSpace + line + '\n';
            if (lowestLength.top)
            {
                text.top = newSpace.additional;
                text.bottom = newSpace.regular;
            }
            else
            {
                text.bottom = newSpace.additional;
                text.top = newSpace.regular;
            }

            text.middle = sign.text + text.middle;
            return text.top + text.middle + text.bottom;
        }

        public override bool Equals(object obj)
        {
            bool isEqual;
            if (obj == null)
                isEqual = false;
            else if (obj is Fraction<T>)
            {
                Fraction<T> otherFraction = (Fraction<T>) obj;
                isEqual = Numerator.Equals(otherFraction.Numerator) && Denominator.Equals(otherFraction.Denominator);
            }
            else
                isEqual = false;

            return isEqual;
        }

        public static Fraction<T> operator +(Fraction<T> firstFraction, Fraction<T> secondFraction)
        {
            return Add(firstFraction, secondFraction);
        }
        
        public static Fraction<T> operator -(Fraction<T> firstFraction, Fraction<T> secondFraction)
        {
            return Substract(firstFraction, secondFraction);
        }
        
        public static Fraction<T> operator *(Fraction<T> firstFraction, Fraction<T> secondFraction)
        {
            return Multiply(firstFraction, secondFraction);
        }
        
        public static Fraction<T> operator /(Fraction<T> firstFraction, Fraction<T> secondFraction)
        {
            return Divide(firstFraction, secondFraction);
        }
        
        public static Fraction<T> operator !(Fraction<T> fraction)
        {
            return Opposite(fraction);
        }
        
        public static Fraction<T> operator ~(Fraction<T> fraction)
        {
            return Inverse(fraction);
        }
        
        public static bool operator ==(Fraction<T> firstFraction, Fraction<T> secondFraction)
        {
            bool isEqual;
            if (firstFraction is null && secondFraction is null)
                isEqual = true;
            else if (firstFraction is null || secondFraction is null)
                isEqual = false;
            else
                isEqual = firstFraction.Numerator.Equals(secondFraction.Numerator) && firstFraction.Denominator.Equals(secondFraction.Denominator);
            return isEqual;
        }

        public static bool operator !=(Fraction<T> firstFraction, Fraction<T> secondFraction)
        {
            return !(firstFraction == secondFraction);
        }
    }
}