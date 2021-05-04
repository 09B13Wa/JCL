package Architecture;

import java.util.List;
import java.util.Vector;

public class SignedBinaryNumber {
    private List<Integer> BinaryRepresentation;
    private int TotalLength;
    private int ValueLength;
    private int MaxValue;
    private int MinValue;
    private int SignBit;
    private BaseSign sign;
    private boolean UserDefinedLength;
    private SignedBinaryEncoding Encoding;

    public SignedBinaryNumber(int value){

    }

    public SignedBinaryNumber(List<Integer> integers){
        BinaryRepresentation = integers;
        int length = integers.size();
        if (length == 0) {
            TotalLength = 1;
            integers.add(0);
        }
        else
            TotalLength = length;
        ValueLength = TotalLength - 1;
        MaxValue = UnsignedBinaryNumber.MaxValueAbsoluteForLength(ValueLength);
        MinValue = -MaxValue - 1;
        SignBit = integers.get(0);
        Encoding = SignedBinaryEncoding.TWOS_COMPLEMENT_ENCODING;
        if (SignBit == 0)
            sign = BaseSign.POSITIVE;
        else
            sign = BaseSign.NEGATIVE;
        UserDefinedLength = false;
    }

    public List<Integer> getBinaryRepresentation() {
        return BinaryRepresentation;
    }

    public static List<Integer> toBinaryRepresentation(int value, SignedBinaryEncoding encoding){
        List<Integer> binaryRepresentation = new Vector<Integer>();
        List<Integer> binaryRepresentationToAdd = null;
        switch (encoding){
            case MAGNITUDE:
                binaryRepresentationToAdd = getMagnitudeEncoding(value);
                break;
            case ONES_COMPLEMENT_ENCODING:

                break;
            case TWOS_COMPLEMENT_ENCODING:
                if (value < 0) {
                    binaryRepresentation.add(1);
                    binaryRepresentationToAdd = UnsignedBinaryNumber.toBinNumber(value * -1);
                    binaryRepresentationToAdd = BinNumberOnesComplement(binaryRepresentationToAdd);
                }
                else {
                    binaryRepresentation.add(0);
                    binaryRepresentationToAdd = UnsignedBinaryNumber.toBinNumber(value);
                }
                for (int digit:binaryRepresentationToAdd) {
                    binaryRepresentation.add(digit);
                }
                break;
        }
        if (binaryRepresentationToAdd != null)
            for (int digit : binaryRepresentationToAdd)
                binaryRepresentation.add(digit);
        return binaryRepresentation;
    }

    public static List<Integer> getMagnitudeEncoding(int value){
        List<Integer> binaryRepresentationToAdd = new Vector<Integer>();
        if (value < 0) {
            binaryRepresentationToAdd.add(1);
            binaryRepresentationToAdd = UnsignedBinaryNumber.toBinNumber(value * -1);
        }
        else {
            binaryRepresentationToAdd.add(0);
            binaryRepresentationToAdd = UnsignedBinaryNumber.toBinNumber(value);
        }
        return binaryRepresentationToAdd;
    }

    public static List<Integer> getOnesComplementEncoding(int value){
        List<Integer> binaryRepresentationToAdd = new Vector<Integer>();
        if (value < 0) {
            binaryRepresentationToAdd = UnsignedBinaryNumber.toBinNumber(value * -1);
            binaryRepresentationToAdd = BinNumberOnesComplement(binaryRepresentationToAdd);
            binaryRepresentationToAdd.add(0, -1);
        }
        else {
            binaryRepresentationToAdd = UnsignedBinaryNumber.toBinNumber(value);
            binaryRepresentationToAdd.add(0, 0);
        }
        return binaryRepresentationToAdd;
    }

    public static List<Integer> getTwosComplementEncoding(int value){
        List<Integer> binaryRepresentationToAdd = new Vector<Integer>();
        if (value < 0) {
            binaryRepresentationToAdd = UnsignedBinaryNumber.toBinNumber(value * -1);
            binaryRepresentationToAdd = BinNumberTwosComplement(binaryRepresentationToAdd);
            binaryRepresentationToAdd.add(0, -1);
        }
        else {
            binaryRepresentationToAdd = UnsignedBinaryNumber.toBinNumber(value);
            binaryRepresentationToAdd.add(0, 0);
        }
        return binaryRepresentationToAdd;
    }

    public static List<Integer> BinNumberOnesComplement(List<Integer> binaryRepresentation){
        List<Integer> newRepresentation = new Vector<Integer>();
        for (int digit:binaryRepresentation)
            if (digit == 0)
                newRepresentation.add(1);
            else if (digit == 1)
                newRepresentation.add(0);
            else
                throw new IllegalArgumentException("Error: this is not the representation of a binary number");
        return newRepresentation;
    }

    public static List<Integer> BinNumberTwosComplement(List<Integer> binaryRepresentation){

        List<Integer> newRepresentation = new Vector<Integer>();
        for (int digit:binaryRepresentation)
            if (digit == 0)
                newRepresentation.add(1);
            else if (digit == 1)
                newRepresentation.add(0);
            else
                throw new IllegalArgumentException("Error: this is not the representation of a binary number");
        return newRepresentation;
    }
}
