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

    public UnsignedBinaryNumber(int entryValue) {
        entryValue = CheckIfPositive(entryValue);
        BinaryRepresentation = toBinNumber(entryValue);
        Length = BinaryRepresentation.size();
        MinValue = 0;
        MaxValue = MaxValueAbsoluteForLength(Length);
    }

    public UnsignedBinaryNumber(int entryValue, int length) {
        entryValue = CheckIfPositive(entryValue);
        int actualLength = BinaryRepresentation.size();
        if (actualLength <= length) {
            BinaryRepresentation = toBinNumber(entryValue);
            ExtendTo(length);
            MinValue = 0;
            MaxValue = MaxValueAbsoluteForLength(Length);
            Length = length;
        } else {
            throw new IllegalArgumentException("Error: the desired length is too small to represent this number." +
                    "Minimum is " + actualLength + " but got " + length);
        }
    }

    public UnsignedBinaryNumber(String number) {
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
        BinaryRepresentation = binaryRepresentation;
        Length = computedLength;
        MaxValue = MaxValueAbsoluteForLength(computedLength);
        MinValue = 0;
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
            ExtendTo(length);
            MinValue = 0;
            MaxValue = MaxValueAbsoluteForLength(Length);
            Length = length;
        } else {
            throw new IllegalArgumentException("Error: the desired length is too small to represent this number." +
                    "Minimum is " + computedLength + " but got " + length);
        }
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
            } else {
                throw new IllegalArgumentException("Error: the desired length is too small to represent this number." +
                        "Minimum is " + actualLength + " but got " + length);
            }

        }
        else
            throw new IllegalArgumentException("Error: Unsigned binary numbers must be positive");
    }

    public UnsignedBinaryNumber(BasedInt signedBinaryNumber){

    }

    public UnsignedBinaryNumber(BasedInt signedBinaryNumber, int length){
        throw new UnsupportedOperationException();
    }

    public int CheckIfPositive(int value){
        if (value >= 0)
            return value;
        else
            throw new IllegalArgumentException("Error: Unsigned binary numbers must be positive");
    }

    private List<Integer> toBinNumber(int integer){
        int listSize = MinimumLengthForRepresentation(integer);
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
        throw new UnsupportedOperationException();
    }

    public void Add(UnsignedBinaryNumber toAdd){
        throw new UnsupportedOperationException();
    }

    public static UnsignedBinaryNumber Add(UnsignedBinaryNumber firstElement, UnsignedBinaryNumber secondElement){
        throw new UnsupportedOperationException();
    }

    public void Substract(UnsignedBinaryNumber toSubstract){
        throw new UnsupportedOperationException();
    }

    public static UnsignedBinaryNumber Substract(UnsignedBinaryNumber firstElement, UnsignedBinaryNumber secondElement){
        throw new UnsupportedOperationException();
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

    public UnsignedBinaryNumber ToOnesComplement(){
        throw new UnsupportedOperationException();
    }

    public UnsignedBinaryNumber ToTwosComplement(){
        throw new UnsupportedOperationException();
    }

    public SignedBinaryNumber ToOpposite(){
        throw new UnsupportedOperationException();
    }

    public UnsignedBinaryNumber toSigned(){
        throw new UnsupportedOperationException();
    }

    public static boolean CanFitInRepresentation(int value, int length){
        throw new UnsupportedOperationException();
    }

    public boolean CanFitInRepresentation(){
        throw new UnsupportedOperationException();
    }

    public static boolean CanFitInRepresentation(UnsignedBinaryNumber value, int length){
        throw new UnsupportedOperationException();
    }

    public static boolean CanFitInRepresentation(SignedBinaryNumber value, int length){
        throw new UnsupportedOperationException();
    }

    public static boolean CanFitInRepresentation(BasedInt value, int length){
        throw new UnsupportedOperationException();
    }

    public static int MinimumLengthForRepresentation(UnsignedBinaryNumber unsignedBinaryNumber){
        throw new UnsupportedOperationException();
    }

    public static int MinimumLengthForRepresentation(SignedBinaryNumber signedBinaryNumber){
        throw new UnsupportedOperationException();
    }

    public static int MinimumLengthForRepresentation(BasedInt basedInt){
        throw new UnsupportedOperationException();
    }

    public static int MinimumLengthForRepresentation(int value){
        throw new UnsupportedOperationException();
    }

    public static int MaxValueForRepresentation(UnsignedBinaryNumber unsignedBinaryNumber){
        throw new UnsupportedOperationException();
    }

    public static int MaxValueForRepresentation(SignedBinaryNumber signedBinaryNumber){
        throw new UnsupportedOperationException();
    }

    public static int MaxValueForRepresentation(BasedInt basedInt){
        throw new UnsupportedOperationException();
    }

    public static int MaxValueAbsoluteForLength(int length){
        throw new UnsupportedOperationException();
    }

    public boolean isOverflown() {
        return Overflown;
    }

    public void setOverflown(boolean overflown){
        Overflown = overflown;
    }

    public int ToValue(){
        throw new UnsupportedOperationException();
    }

    public BasedInt toBasedInt(Base base){
        throw new UnsupportedOperationException();
    }

    public void ExtendTo(int length){

    }

    public void ExtendBy(int extendedLength){

    }

    public int Squeeze(){
        throw new UnsupportedOperationException();
    }

    public int Shorten(){
        throw new UnsupportedOperationException();
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

    @Override
    public boolean equals(Object obj) {
        throw new UnsupportedOperationException();
    }
}
