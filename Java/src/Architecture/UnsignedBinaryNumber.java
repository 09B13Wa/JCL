package Architecture;

import com.sun.jdi.event.ExceptionEvent;

import java.awt.*;
import java.nio.BufferOverflowException;
import java.util.List;
import java.util.Vector;

public class UnsignedBinaryNumber {
    private List<Integer> BinaryRepresentation;
    private int Length;
    private int MaxValue;
    private int MinValue;
    private boolean Overflown;
    private boolean UserDefinedLength;

    public UnsignedBinaryNumber(int entryValue) {
        entryValue = CheckIfPositive(entryValue);
        BinaryRepresentation = toBinNumber(entryValue);
        Length = BinaryRepresentation.size();
        MinValue = 0;
        MaxValue = MaxValueAbsoluteForLength(Length);
        UserDefinedLength = false;
    }

    public UnsignedBinaryNumber(int entryValue, int length) {
        entryValue = CheckIfPositive(entryValue);
        BinaryRepresentation = toBinNumber(entryValue, length);
        int actualLength = BinaryRepresentation.size();
        if (actualLength <= length) {
            Length = length;
            ExtendTo(length);
            MinValue = 0;
            MaxValue = MaxValueAbsoluteForLength(Length);
            UserDefinedLength = true;
        } else {
            throw new IllegalArgumentException("Error: the desired length is too small to represent this number." +
                    "Minimum is " + actualLength + " but got " + length);
        }
    }

    public UnsignedBinaryNumber(String number) {
        char[] numberChars = number.toCharArray();
        List<Integer> list = new Vector<>();
        List<Integer> binaryRepresentation = new Vector<Integer>();
        int computedLength = 0;
        for (char digit : numberChars) {
            if (digit == '0')
                binaryRepresentation.add(0);
            else if (digit == '1')
                binaryRepresentation.add(1);
            else
                throw new IllegalArgumentException("Declaring an unsigned binary number from a string requires the" +
                        "ti be made up of only 0s and 1s");
            computedLength += 1;
        }
        BinaryRepresentation = binaryRepresentation;
        Length = computedLength;
        MaxValue = MaxValueAbsoluteForLength(computedLength);
        MinValue = 0;
        UserDefinedLength = false;
    }

    public UnsignedBinaryNumber(String number, int length) {
        char[] numberChars = number.toCharArray();
        List<Integer> binaryRepresentation = new Vector<Integer>();
        int computedLength = 0;
        for (char digit : numberChars) {
            if (digit == '0')
                binaryRepresentation.add(0);
            else if (digit == '1')
                binaryRepresentation.add(1);
            else
                throw new IllegalArgumentException("Declaring an unsigned binary number from a string requires the" +
                        "string to be made up of only 0s and 1s");
            computedLength += 1;
        }
        if (computedLength <= length) {
            BinaryRepresentation = binaryRepresentation;
            ExtendTo(length);
            MinValue = 0;
            MaxValue = MaxValueAbsoluteForLength(Length);
            Length = length;
        } else {
            throw new IllegalArgumentException("Error: the desired length is too small to represent this number." +
                    "Minimum is " + computedLength + " but got " + length);
        }
        UserDefinedLength = true;
    }

    public UnsignedBinaryNumber(List<Integer> integers){
        BinaryRepresentation = integers;
        Length = integers.size();
        MaxValue = MaxValueAbsoluteForLength(Length);
        MinValue = 0;
        UserDefinedLength = false;
    }

    public UnsignedBinaryNumber(SignedBinaryNumber signedBinaryNumber){
        List<Integer> binaryRepresentation = signedBinaryNumber.getBinaryRepresentation();
        int signBit = binaryRepresentation.get(0);
        if (signBit == 0){
            List<Integer> newRepresentation = new Vector<Integer>();
            int currentLength = binaryRepresentation.size();
            for (int i = 1; i < currentLength; i++)
                newRepresentation.add(binaryRepresentation.get(i));
            BinaryRepresentation = newRepresentation;
            Length = currentLength - 1;
            MinValue = 0;
            MaxValue = MaxValueAbsoluteForLength(Length);
            UserDefinedLength = false;
        }
        else
            throw new IllegalArgumentException("Error: Unsigned binary numbers must be positive");
    }

    public UnsignedBinaryNumber(SignedBinaryNumber signedBinaryNumber, int length){
        List<Integer> binaryRepresentation = signedBinaryNumber.getBinaryRepresentation();
        int signBit = binaryRepresentation.get(0);
        if (signBit == 0){
            List<Integer> newRepresentation = new Vector<Integer>();
            int currentLength = binaryRepresentation.size();
            for (int i = 1; i < currentLength; i++)
                newRepresentation.add(binaryRepresentation.get(i));
            int actualLength = currentLength - 1;
            if (actualLength <= length){
                BinaryRepresentation = newRepresentation;
                ExtendTo(length);
                Length = actualLength;
                MinValue = 0;
                MaxValue = MaxValueAbsoluteForLength(Length);
                UserDefinedLength = true;
            } else {
                throw new IllegalArgumentException("Error: the desired length is too small to represent this number." +
                        "Minimum is " + actualLength + " but got " + length);
            }
        }
        else
            throw new IllegalArgumentException("Error: Unsigned binary numbers must be positive");
    }

    public UnsignedBinaryNumber(BasedInt basedNumber){
        if (basedNumber.getSign() == BaseSign.POSITIVE) {
            int equivalentValue = basedNumber.getValue();
            BinaryRepresentation = toBinNumber(equivalentValue);
            Length = BinaryRepresentation.size();
            MinValue = 0;
            MaxValue = MaxValueAbsoluteForLength(Length);
            UserDefinedLength = true;
        } else {
            throw new IllegalArgumentException("Error: Unsigned binary numbers must be positive");
        }
    }

    public UnsignedBinaryNumber(BasedInt basedNumber, int length){
        if (basedNumber.getSign() == BaseSign.POSITIVE || basedNumber.getSign() == BaseSign.NIL) {
            int equivalentValue = basedNumber.getValue();
            BinaryRepresentation = toBinNumber(equivalentValue);
            int actualLength = BinaryRepresentation.size();
            if (actualLength <= length) {
                ExtendTo(length);
                MinValue = 0;
                MaxValue = MaxValueAbsoluteForLength(Length);
                Length = length;
                UserDefinedLength = false;
            } else {
                throw new IllegalArgumentException("Error: the desired length is too small to represent this number." +
                        "Minimum is " + actualLength + " but got " + length);
            }
        } else {
            throw new IllegalArgumentException("JCL-Error: Unsigned binary numbers must be positive");
        }
    }

    public int CheckIfPositive(int value){
        if (value >= 0)
            return value;
        else
            throw new IllegalArgumentException("JCL-Error: Unsigned binary numbers must be positive");
    }

    public static List<Integer> toBinNumber(int integer){
        int listSize = MinimumLengthForRepresentation(integer);
        int powerOfTwo = (int)Math.pow(2, listSize - 1);
        List<Integer> newRepresentation = new Vector<Integer>();
        for (int i = 0; i < listSize; i++){
            int valueToAdd = 0;
            if (integer >= powerOfTwo) {
                valueToAdd = 1;
                integer -= powerOfTwo;
            }
            newRepresentation.add(valueToAdd);
            powerOfTwo /= 2;
        }

        return newRepresentation;
    }

    private List<Integer> toBinNumber(int integer, int length){
        int powerOfTwo = (int)Math.pow(2, length - 1);
        List<Integer> newRepresentation = new Vector<Integer>();
        for (int i = 0; i < length; i++){
            int valueToAdd = 0;
            if (integer >= powerOfTwo) {
                valueToAdd = 1;
                integer -= powerOfTwo;
            }
            newRepresentation.add(valueToAdd);
            powerOfTwo /= 2;
        }

        return newRepresentation;
    }

    @Override
    public String toString() {
        String toPrint = "";
        for (int digit: BinaryRepresentation){
            if (digit == 0)
                toPrint += "0";
            else
                toPrint += "1";
        }

        return toPrint;
    }

    public void Add(UnsignedBinaryNumber toAdd){
        UnsignedBinaryNumber resultingBinaryNumber = Add(this, toAdd);
        List<Integer> result = resultingBinaryNumber.getBinaryRepresentation();
        int totalResultLength = result.size();
        if (UserDefinedLength) {
            if (!Overflown && totalResultLength > Length)
                throw new BufferOverflowException();
            else {
                BinaryRepresentation = result;
                ShortenTo(Length);
            }
        }
        else {
            BinaryRepresentation = result;
            Length = totalResultLength;
            MaxValue = MaxValueAbsoluteForLength(Length);
        }
    }

    public static UnsignedBinaryNumber Add(UnsignedBinaryNumber firstElement, UnsignedBinaryNumber secondElement){
        List<Integer> toAddAfter = new Vector<Integer>();
        int numberOfNumberLength = secondElement.CurrentLength();
        int numberOfNumbersCurrent = firstElement.CurrentLength();
        int maximumNumberOfNumbers = numberOfNumberLength;
        int minimumNumberOfNumbers = numberOfNumbersCurrent;
        if (numberOfNumbersCurrent > numberOfNumberLength) {
            maximumNumberOfNumbers = numberOfNumbersCurrent;
            minimumNumberOfNumbers = numberOfNumberLength;
        }
        List<Integer> otherRepresentation = secondElement.getBinaryRepresentation();
        List<Integer> firstRepresentation = firstElement.getBinaryRepresentation();
        for (int i = 0; i < maximumNumberOfNumbers + 1; i++){
            toAddAfter.add(0);
        }

        List<Integer> result = new Vector<Integer>();
        for (int i = minimumNumberOfNumbers - 1; i >= 0; i--){
            int sum = otherRepresentation.get(i) + firstRepresentation.get(i) + toAddAfter.get(i);
            int directResult = 0;
            int toAddOn = 0;
            switch (sum) {
                case 0:
                    break;
                case 1:
                    directResult = 1;
                    break;
                case 2:
                    toAddOn = 1;
                    break;
                case 3:
                    directResult = 1;
                    toAddOn = 1;
                    break;
                default:
                    throw new ArithmeticException("Error: addition of sub-parts too great");
            }
            result.add(directResult);
            toAddAfter.add(i + 1, toAddOn);
        }

        for (int i = minimumNumberOfNumbers; i < maximumNumberOfNumbers; i++){
            int sum = otherRepresentation.get(i) + firstRepresentation.get(i) + toAddAfter.get(i);
            int directResult = 0;
            int toAddOn = 0;
            switch (sum) {
                case 0:
                    break;
                case 1:
                    directResult = 1;
                    break;
                case 2:
                    toAddOn = 1;
                    break;
                default:
                    throw new ArithmeticException("Error: addition of sub-parts too great");
            }
            result.add(i, directResult);
            toAddAfter.add(i + 1, toAddOn);
        }
        int totalResultLength = maximumNumberOfNumbers;
        if (toAddAfter.get(maximumNumberOfNumbers + 1) == 1) {
            result.add(maximumNumberOfNumbers + 1, toAddAfter.get(maximumNumberOfNumbers + 1));
            totalResultLength += 1;
        }

        return new UnsignedBinaryNumber(result);
    }

    public void Subtract(UnsignedBinaryNumber toSubtract){
        UnsignedBinaryNumber subtractionResult = Subtract(this, toSubtract);
        this.BinaryRepresentation = subtractionResult.getBinaryRepresentation();
    }

    public static UnsignedBinaryNumber Subtract(UnsignedBinaryNumber firstElement, UnsignedBinaryNumber secondElement){
        UnsignedBinaryNumber secondElementComplement = ToTwosComplement(secondElement);
        UnsignedBinaryNumber result = Add(firstElement, secondElementComplement);
        result.ShortenBy(1);
        result.Squeeze();
        return result;
    }

    public void Multiply(UnsignedBinaryNumber toMultiply){
        throw new UnsupportedOperationException();
    }

    public static UnsignedBinaryNumber Multiply(UnsignedBinaryNumber firstElement, UnsignedBinaryNumber secondElement){
        throw new UnsupportedOperationException();
    }

    public void Divide(UnsignedBinaryNumber toDivide){
        throw new UnsupportedOperationException();
    }

    public static UnsignedBinaryNumber Divide(UnsignedBinaryNumber firstElement, UnsignedBinaryNumber secondElement){
        throw new UnsupportedOperationException();
    }

    public void ToOnesComplement(){
        UnsignedBinaryNumber result = ToOnesComplement(this);
        BinaryRepresentation = result.getBinaryRepresentation();
    }

    public static UnsignedBinaryNumber ToOnesComplement(UnsignedBinaryNumber binaryNumber){
        List<Integer> onesComplement = new Vector<Integer>();
        for (int digit: binaryNumber.getBinaryRepresentation())
            if (digit == 0)
                onesComplement.add(1);
            else
                onesComplement.add(0);
        return new UnsignedBinaryNumber(onesComplement);
    }

    public void ToTwosComplement(){
        UnsignedBinaryNumber twosComplement = ToTwosComplement(this);
        this.BinaryRepresentation = twosComplement.getBinaryRepresentation();
    }

    public static UnsignedBinaryNumber ToTwosComplement(UnsignedBinaryNumber binaryNumber){
        UnsignedBinaryNumber onesComplement = ToOnesComplement(binaryNumber);
        UnsignedBinaryNumber binaryNumber1 = new UnsignedBinaryNumber(1, onesComplement.Length);
        binaryNumber1.setOverflown(true);
        return Add(onesComplement, binaryNumber1);
    }

    public SignedBinaryNumber ToOpposite(){
        UnsignedBinaryNumber twosComplement = ToTwosComplement(this);
        return new SignedBinaryNumber(twosComplement.getBinaryRepresentation());
    }

    public SignedBinaryNumber toSigned(){
        List<Integer> oppositeBinaryRepresentation = new Vector<Integer>();
        oppositeBinaryRepresentation.add(0);
        for (int digit: BinaryRepresentation)
            oppositeBinaryRepresentation.add(digit);
        return new SignedBinaryNumber(oppositeBinaryRepresentation);
    }

    public SignedBinaryNumber toSigned(SignedBinaryEncoding encoding){
        List<Integer> oppositeBinaryRepresentation = new Vector<Integer>();
        //TODO: Finish this when signed binary numbers are implemented
        switch (encoding) {
            case MAGNITUDE:
                break;
            case ONES_COMPLEMENT_ENCODING:
                break;
            case TWOS_COMPLEMENT_ENCODING:
                break;
            case BASE_2:
                break;
            case SIGNED_DIGIT:
                break;
            case OFFSET_BINARY:
                break;
            case ZIG_ZAG:
                break;
            default:
                throw new IllegalArgumentException("Unknown encoding for signed binary numbers");
        }
        oppositeBinaryRepresentation.add(0);
        for (int digit: BinaryRepresentation)
            oppositeBinaryRepresentation.add(digit);
        return new SignedBinaryNumber(oppositeBinaryRepresentation);
    }

    public static boolean CanFitInRepresentation(int value, int length){
        return value > -1 && MaxValueAbsoluteForLength(length) >= length;
    }

    public boolean CanFitInRepresentation(int value){
        if (UserDefinedLength)
            return value >= 0 && value < MaxValue;
        else
            return value >= 0;
    }

    public static boolean CanFitInRepresentation(UnsignedBinaryNumber value, int length){
        UnsignedBinaryNumber shortened = Squeeze(value);
        return true;
    }

    public static boolean CanFitInRepresentation(SignedBinaryNumber value, int length){
        throw new UnsupportedOperationException();
    }

    public static boolean CanFitInRepresentation(BasedInt value, int length){
        throw new UnsupportedOperationException();
    }

    public static int MinimumLengthForRepresentation(UnsignedBinaryNumber unsignedBinaryNumber){
        UnsignedBinaryNumber squeezedUnsignedBinaryNumber = UnsignedBinaryNumber.Squeeze(unsignedBinaryNumber);
        return squeezedUnsignedBinaryNumber.CurrentLength();
    }

    public static int MinimumLengthForRepresentation(SignedBinaryNumber signedBinaryNumber){
        throw new UnsupportedOperationException();
    }

    public static int MinimumLengthForRepresentation(BasedInt basedInt){
        throw new UnsupportedOperationException();
    }

    public static int MinimumLengthForRepresentation(int value){
        int length = 0;
        if (value == 0)
            length = 1;
        else{
            int powerOfTwo = 1;
            while (powerOfTwo - 1 < value){
                length += 1;
                powerOfTwo *= 2;
            }
        }
        return length;
    }

    public static int MaxValueForRepresentation(UnsignedBinaryNumber unsignedBinaryNumber){
        return unsignedBinaryNumber.getMaxValue();
    }

    public static int MaxValueForRepresentation(SignedBinaryNumber signedBinaryNumber){
        throw new UnsupportedOperationException();
    }

    public static int MaxValueForRepresentation(BasedInt basedInt){
        throw new UnsupportedOperationException();
    }

    public static int MaxValueAbsoluteForLength(int length){
        int maxValue = 0;
        int powerOfTwo = 1;
        for (int i = 0; i < length; i++){
            maxValue += powerOfTwo;
            powerOfTwo *= 2;
        }
        return maxValue;
    }

    public boolean isOverflown() {
        return Overflown;
    }

    public void setOverflown(boolean overflown){
        Overflown = overflown;
    }

    public int ToValue(){
        int value = 0;
        int powerOfTwo = 1;
        for (int index = Length - 1; index > -1; index--){
            int digit = BinaryRepresentation.get(index);
            if (digit == 1)
                value += powerOfTwo;
            powerOfTwo *= 2;
        }

        return value;
    }

    public BasedInt toBasedInt(Base base){
        throw new UnsupportedOperationException();
    }

    public void ExtendTo(int length){
        int currentSize = Length;
        ExtendBy(length - currentSize);
    }

    public void ExtendBy(int extendedLength){
        List<Integer> newBinaryRepresentation = new Vector<Integer>();
        for (int count = 0; count < extendedLength; count++){
            newBinaryRepresentation.add(0);
        }
        for (int digit: BinaryRepresentation){
            newBinaryRepresentation.add(digit);
        }
        BinaryRepresentation = newBinaryRepresentation;
    }

    public int Squeeze(){
        int amountToShortenBy = 0;
        if (Length > 0){
            int index = 0;
            int digit = BinaryRepresentation.get(0);
            while (index < Length && digit == 0){
                index += 1;
                amountToShortenBy += 1;
                digit = BinaryRepresentation.get(digit);
            }
        }
        ShortenBy(amountToShortenBy);
        return amountToShortenBy;
    }

    public static UnsignedBinaryNumber Squeeze(UnsignedBinaryNumber input){
        UnsignedBinaryNumber toSqueeze = new UnsignedBinaryNumber(input.ToValue());
        toSqueeze.Squeeze();
        return toSqueeze;
    }

    public void ShortenBy(int amount){
        if (amount <= Length){
            List<Integer> newRepresentation = new Vector<Integer>();
            int target = Length - amount;
            int newLength = 0;
            for (int i = target; i < Length; i++){
                newRepresentation.add(BinaryRepresentation.get(i));
                newLength += 1;
            }
            MaxValue = MaxValueAbsoluteForLength(newLength);
            Length = newLength;
            BinaryRepresentation = newRepresentation;
        }
        else throw new IllegalArgumentException("Error: the amount " + amount + " is to great for to shorten by for the" +
                "\nunsigned binary number of length " + Length);
    }

    public void ShortenTo(int newPosition){
        if (newPosition < 0)
            throw new IndexOutOfBoundsException("Error: " + newPosition + " is too low to be a valid index (negative value).");
        else if (newPosition >= Length)
            throw new IndexOutOfBoundsException("Error: " + newPosition + " is outside of the range. The maximum is " + (Length - 1));
        else {
            int shortenByLength = Length - newPosition - 1;
            ShortenBy(shortenByLength);
        }
    }

    public int CurrentLength(){
        return Length;
    }

    public int RepresentationSize(){
        return Length;
    }

    public int getMaxValue() {
        return MaxValue;
    }

    public int getMinValue() {
        return MinValue;
    }

    public List<Integer> getBinaryRepresentation() {
        return BinaryRepresentation;
    }

    public static boolean Equals(UnsignedBinaryNumber firstNumber, UnsignedBinaryNumber secondNumber){
        UnsignedBinaryNumber firstSqueezed = Squeeze(firstNumber);
        UnsignedBinaryNumber secondSqueezed = Squeeze(secondNumber);
        int representationSizeFirst = firstSqueezed.RepresentationSize();
        int representationSizeSecond = secondSqueezed.RepresentationSize();
        if (representationSizeFirst == representationSizeSecond) {
            List<Integer> objRepresentationFirst = firstSqueezed.getBinaryRepresentation();
            List<Integer> objRepresentationSecond = secondSqueezed.getBinaryRepresentation();
            int i = 0;
            while (i < representationSizeFirst && objRepresentationFirst.get(i) == objRepresentationSecond.get(i)) {
                i += 1;
            }
            return i == representationSizeFirst;
        }
        else
            return false;
    }

    @Override
    public boolean equals(Object obj) {
        if (obj instanceof UnsignedBinaryNumber){
            return Equals(this, (UnsignedBinaryNumber) obj);
        }
        else if (obj instanceof SignedBinaryNumber){
            //TODO
            return false;
        }
        else if (obj instanceof BasedInt){
            //TODO
            return false;
        }
        else
            return false;
    }
}
