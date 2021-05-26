enum FloatingPointValueType{
    POSITIVE_INFINITY,
    NEGATIVE_INFINITY,
    POSITIVE_ZERO,
    NEGATIVE_ZERO,
    NORMALIZED,
    DENORMALIZED,
    NOT_A_NUMBER
}

class FloatingPointNumber{
    private precision: FloatingPointNumber;
    private value: number;
    private signArray: Array<number>;
    private exponentArray: Array<number>;
    private mantissaArray: Array<number>;
    private floatingPointValueType: FloatingPointValueType;
}