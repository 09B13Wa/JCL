package Architecture;

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
        entryValue = checkIfPositive(entryValue);
        BinaryRepresentation = toBinNumber(entryValue);
        Length = BinaryRepresentation.size();
        MinValue = 0;
        MaxValue = maxValueAbsoluteForLength(Length);
        UserDefinedLength = false;
    }

    public UnsignedBinaryNumber(int entryValue, int length) {
        entryValue = checkIfPositive(entryValue);
        BinaryRepresentation = toBinNumber(entryValue);
        int actualLength = BinaryRepresentation.size();
        if (actualLength <= length) {
            Length = length;
            extendTo(length);
            MinValue = 0;
            MaxValue = maxValueAbsoluteForLength(Length);
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
        MaxValue = maxValueAbsoluteForLength(computedLength);
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
                        "ti be made up of only 0s and 1s");
            computedLength += 1;
        }
        if (computedLength <= length) {
            BinaryRepresentation = binaryRepresentation;
            extendTo(length);
            MinValue = 0;
            MaxValue = maxValueAbsoluteForLength(Length);
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
        MaxValue = maxValueAbsoluteForLength(Length);
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
            MaxValue = maxValueAbsoluteForLength(Length);
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
                extendTo(length);
                Length = actualLength;
                MinValue = 0;
                MaxValue = maxValueAbsoluteForLength(Length);
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
            MaxValue = maxValueAbsoluteForLength(Length);
            UserDefinedLength = true;
        } else {
            throw new IllegalArgumentException("Error: Unsigned binary numbers must be positive");
        }
    }

    public UnsignedBinaryNumber(BasedInt basedNumber, int length){
        if (basedNumber.getSign() == BaseSign.POSITIVE) {
            int equivalentValue = basedNumber.getValue();
            BinaryRepresentation = toBinNumber(equivalentValue);
            int actualLength = BinaryRepresentation.size();
            if (actualLength <= length) {
                extendTo(length);
                MinValue = 0;
                MaxValue = maxValueAbsoluteForLength(Length);
                Length = length;
                UserDefinedLength = false;
            } else {
                throw new IllegalArgumentException("Error: the desired length is too small to represent this number." +
                        "Minimum is " + actualLength + " but got " + length);
            }
        } else {
            throw new IllegalArgumentException("Error: Unsigned binary numbers must be positive");
        }
    }

    public static UnsignedBinaryNumber getFromIntString(String value){
        int actualValue;
        actualValue = getActualValueFromString(value);
        return new UnsignedBinaryNumber(actualValue);
    }

    public static UnsignedBinaryNumber getFromIntString(String value, int length){
        int actualValue;
        actualValue = getActualValueFromString(value);
        return new UnsignedBinaryNumber(actualValue, length);
    }

    private static int getActualValueFromString(String value) {
        int actualValue = 0;
        int numberOfDigits = value.length();
        int multiplier = 1;
        for (int i = numberOfDigits - 1; i >= 0; i--){
            char digit = value.charAt(i);
            switch (digit){
                case '0':
                    break;
                case '1':
                    actualValue += multiplier;
                    break;
                case '2':
                    actualValue += 2 * multiplier;
                    break;
                case '3':
                    actualValue += 3 * multiplier;
                    break;
                case '4':
                    actualValue += 4 * multiplier;
                    break;
                case '5':
                    actualValue += 5 * multiplier;
                    break;
                case '6':
                    actualValue += 6 * multiplier;
                    break;
                case '7':
                    actualValue += 7 * multiplier;
                    break;
                case '8':
                    actualValue += 8 * multiplier;
                    break;
                case '9':
                    actualValue += 9 * multiplier;
                    break;
                default:
                    throw new IllegalArgumentException("Error: " + actualValue + " isn't an acceptable value for this method." +
                            " Each character in the string must be a digit.");
            }
            multiplier *= 10;
        }
        return actualValue;
    }

    public int checkIfPositive(int value){
        if (value >= 0)
            return value;
        else
            throw new IllegalArgumentException("Error: Unsigned binary numbers must be positive");
    }

    private List<Integer> toBinNumber(int integer){
        int listSize = minimumLengthForRepresentation(integer);
        int powerOfTwo = (int)Math.pow(2, listSize);
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

    public void add(UnsignedBinaryNumber toAdd){
        UnsignedBinaryNumber resultingBinaryNumber = add(this, toAdd);
        List<Integer> result = resultingBinaryNumber.getBinaryRepresentation();
        int totalResultLength = result.size();
        if (UserDefinedLength) {
            if (!Overflown && totalResultLength > Length)
                throw new BufferOverflowException();
            else {
                BinaryRepresentation = result;
                shortenTo(Length);
            }
        }
        else {
            BinaryRepresentation = result;
            Length = totalResultLength;
            MaxValue = maxValueAbsoluteForLength(Length);
        }
    }

    public static UnsignedBinaryNumber add(UnsignedBinaryNumber firstElement, UnsignedBinaryNumber secondElement){
        List<Integer> toAddAfter = new Vector<Integer>();
        int numberOfNumberLength = secondElement.currentLength();
        int numberOfNumbersCurrent = firstElement.currentLength();
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
        for (int i = 0; i < minimumNumberOfNumbers; i++){
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
            result.add(i, directResult);
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

    public void subtract(UnsignedBinaryNumber toSubtract){
        UnsignedBinaryNumber subtractionResult = subtract(this, toSubtract);
        this.BinaryRepresentation = subtractionResult.getBinaryRepresentation();
    }

    public static UnsignedBinaryNumber subtract(UnsignedBinaryNumber firstElement, UnsignedBinaryNumber secondElement){
        UnsignedBinaryNumber secondElementComplement = toTwosComplement(secondElement);
        UnsignedBinaryNumber result = add(firstElement, secondElementComplement);
        result.shortenBy(1);
        result.squeeze();
        return result;
    }

    public void multiply(UnsignedBinaryNumber toMultiply){
        throw new UnsupportedOperationException();
    }

    public static UnsignedBinaryNumber multiply(UnsignedBinaryNumber firstElement, UnsignedBinaryNumber secondElement){
        throw new UnsupportedOperationException();
    }

    public void divide(UnsignedBinaryNumber toDivide){
        throw new UnsupportedOperationException();
    }

    public static UnsignedBinaryNumber divide(UnsignedBinaryNumber firstElement, UnsignedBinaryNumber secondElement){
        throw new UnsupportedOperationException();
    }

    public void toOnesComplement(){
        UnsignedBinaryNumber result = toOnesComplement(this);
        BinaryRepresentation = result.getBinaryRepresentation();
    }

    public static UnsignedBinaryNumber toOnesComplement(UnsignedBinaryNumber binaryNumber){
        List<Integer> onesComplement = new Vector<Integer>();
        for (int digit: binaryNumber.getBinaryRepresentation())
            if (digit == 0)
                onesComplement.add(1);
            else
                onesComplement.add(0);
        return new UnsignedBinaryNumber(onesComplement);
    }

    public void toTwosComplement(){
        UnsignedBinaryNumber twosComplement = toTwosComplement(this);
        this.BinaryRepresentation = twosComplement.getBinaryRepresentation();
    }

    public static UnsignedBinaryNumber toTwosComplement(UnsignedBinaryNumber binaryNumber){
        UnsignedBinaryNumber onesComplement = toOnesComplement(binaryNumber);
        UnsignedBinaryNumber binaryNumber1 = new UnsignedBinaryNumber(1, onesComplement.Length);
        binaryNumber1.setOverflown(true);
        return add(onesComplement, binaryNumber1);
    }

    public SignedBinaryNumber toOpposite(){
        UnsignedBinaryNumber twosComplement = toTwosComplement(this);
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
        oppositeBinaryRepresentation.add(0);
        for (int digit: BinaryRepresentation)
            oppositeBinaryRepresentation.add(digit);
        return new SignedBinaryNumber(oppositeBinaryRepresentation);
    }

    public static boolean canFitInRepresentation(int value, int length){
        return value > -1 && maxValueAbsoluteForLength(length) >= length;
    }

    public boolean canFitInRepresentation(int value){
        if (UserDefinedLength)
            return value >= 0 && value < MaxValue;
        else
            return value >= 0;
    }

    public static boolean canFitInRepresentation(UnsignedBinaryNumber value, int length){
        throw new UnsupportedOperationException();
    }

    public static boolean canFitInRepresentation(SignedBinaryNumber value, int length){
        throw new UnsupportedOperationException();
    }

    public static boolean canFitInRepresentation(BasedInt value, int length){
        throw new UnsupportedOperationException();
    }

    public static int minimumLengthForRepresentation(UnsignedBinaryNumber unsignedBinaryNumber){
        UnsignedBinaryNumber squeezedUnsignedBinaryNumber = UnsignedBinaryNumber.squeeze(unsignedBinaryNumber);
        return squeezedUnsignedBinaryNumber.currentLength();
    }

    public static int minimumLengthForRepresentation(SignedBinaryNumber signedBinaryNumber){
        throw new UnsupportedOperationException();
    }

    public static int minimumLengthForRepresentation(BasedInt basedInt){
        throw new UnsupportedOperationException();
    }

    public static int minimumLengthForRepresentation(int value){
        throw new UnsupportedOperationException();
    }

    public static int maxValueForRepresentation(UnsignedBinaryNumber unsignedBinaryNumber){
        throw new UnsupportedOperationException();
    }

    public static int maxValueForRepresentation(SignedBinaryNumber signedBinaryNumber){
        throw new UnsupportedOperationException();
    }

    public static int maxValueForRepresentation(BasedInt basedInt){
        throw new UnsupportedOperationException();
    }

    public static int maxValueAbsoluteForLength(int length){
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

    public int toValue(){
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

    public void extendTo(int length){
        int currentSize = Length;
        extendBy(length - currentSize);
    }

    public void extendBy(int extendedLength){
        List<Integer> newBinaryRepresentation = new Vector<Integer>();
        for (int count = 0; count < extendedLength; count++){
            newBinaryRepresentation.add(0);
        }
        for (int digit: BinaryRepresentation){
            newBinaryRepresentation.add(digit);
        }
        BinaryRepresentation = newBinaryRepresentation;
    }

    public int squeeze(){
        throw new UnsupportedOperationException();
    }

    public static UnsignedBinaryNumber squeeze(UnsignedBinaryNumber input){
        throw new UnsupportedOperationException();
    }

    public int shortenBy(int amount){
        throw new UnsupportedOperationException();
    }

    public int shortenTo(int newPosition){
        throw new UnsupportedOperationException();
    }

    public int currentLength(){
        return Length;
    }

    public int representationSize(){
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

    public static boolean equals(UnsignedBinaryNumber firstNumber, UnsignedBinaryNumber secondNumber){
        UnsignedBinaryNumber firstSqueezed = squeeze(firstNumber);
        UnsignedBinaryNumber secondSqueezed = squeeze(secondNumber);
        int representationSizeFirst = firstSqueezed.representationSize();
        int representationSizeSecond = secondSqueezed.representationSize();
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
            return equals(this, (UnsignedBinaryNumber) obj);
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
