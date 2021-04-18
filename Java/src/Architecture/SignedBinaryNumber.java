package Architecture;

import java.util.List;

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
}
