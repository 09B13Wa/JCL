package Architecture;

import java.util.List;
import java.util.Vector;

public class UnsignedBinaryNumber {
    private List<Integer> BinaryRepresentation;
    private int Length;
    private int MaxValue;
    private int MinValue;
    private boolean Overflown;

    public UnsignedBinaryNumber(int entryValue) {
        throw new UnsupportedOperationException();
    }

    public UnsignedBinaryNumber(int entryValue, int length) {
        throw new UnsupportedOperationException();
    }

    public UnsignedBinaryNumber(String number) {
        throw new UnsupportedOperationException();
    }

    public UnsignedBinaryNumber(String number, int length) {
        throw new UnsupportedOperationException();
    }

    public UnsignedBinaryNumber(SignedBinaryNumber signedBinaryNumber){
        throw new UnsupportedOperationException();
    }

    public UnsignedBinaryNumber(SignedBinaryNumber signedBinaryNumber, int length){
        throw new UnsupportedOperationException();
    }

    public UnsignedBinaryNumber(BasedInt signedBinaryNumber){
        throw new UnsupportedOperationException();
    }

    public UnsignedBinaryNumber(BasedInt signedBinaryNumber, int length){
        throw new UnsupportedOperationException();
    }

    private List<Integer> toBinNumber(int integer){
        int listSize = MaxValueAbsoluteForLength(integer);
        int powerOfTwo = (int)Math.pow(2, listSize);
        List<Integer> newRepresentation = new Vector<Integer>();

        for (int i = 0; i < listSize; i++){
            newRepresentation.add(0);
        }

        for (int index = listSize - 1; index > -1; index--){
            int valueToAdd = 0;
            if (integer >= powerOfTwo){
                valueToAdd = 1;
                integer -= powerOfTwo;
            }
            newRepresentation.add(index, valueToAdd);
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

    @Override
    public boolean equals(Object obj) {
        throw new UnsupportedOperationException();
    }
}
