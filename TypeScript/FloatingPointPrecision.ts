enum PrecisionValue {
    HALF_PRECISION,
    SINGLE_PRECISION,
    DOUBLE_PRECISION,
    QUAD_PRECISION,
    NON_STANDARD
}

class FloatingPointPrecision{
    private SSize: number;
    private ESize: number;
    private MSize: number;
    private Name: string;
    private Standard: PrecisionValue

    constructor(sSize: number, eSize: number, mSize: number, name: string) {
        if (sSize <= 0)
            throw Error("Error: expected positive value strictly larger than zero for size of sign (s) field but got " + sSize);
        else if (eSize <= 0)
            throw Error("Error: expected positive value strictly larger than zero for size of exponent (e) field but got " + eSize);
        else if (mSize <= 0)
            throw Error("Error: expected positive value strictly larger than zero for size of mantissa (m) field but got " + mSize);
        else {
            this.SSize = sSize;
            this.ESize = eSize;
            this.MSize = mSize;
            this.Name = name.toUpperCase() + "_PRECISION";
        }
    }

    public GetSignSize(): number{
        return this.SSize;
    }

    public GetExponentSize(): number{
        return this.ESize;
    }

    public GetMantissaSize(): number{
        return this.MSize;
    }

    public GetName(): string{
        return this.Name;
    }

    public toString = (): string =>{
        return this.Name;
    }

    public GetTotalSize() : number{
        return this.GetSignSize() + this.GetExponentSize() + this.GetMantissaSize();
    }

    static EquivalentStandardFloatingPoint(name: string = ""): FloatingPointPrecision{
        let equivalentStandard: PrecisionValue = this.DeduceStandarFromName(name);
        let equivalentStandardFloatingPoint: FloatingPointPrecision;
        switch (equivalentStandard) {
            case PrecisionValue.HALF_PRECISION:
                equivalentStandardFloatingPoint = new FloatingPointPrecision(1, 5, 10, "HALF");
                break;
            case PrecisionValue.SINGLE_PRECISION:
                equivalentStandardFloatingPoint = new FloatingPointPrecision(1, 8, 23, "SINGLE");
                break;
            case PrecisionValue.DOUBLE_PRECISION:
                equivalentStandardFloatingPoint = new FloatingPointPrecision(1, 11, 52, "DOUBLE");
                break;
            case PrecisionValue.QUAD_PRECISION:
                equivalentStandardFloatingPoint = new FloatingPointPrecision(1, 15, 112, "QUAD");
                break;
            default:
                throw new Error("Error: " + name + " isn't a standard IEEE floating point precision.");
        }
        return equivalentStandardFloatingPoint;
    }

    private static DeduceStandarFromName(name: string) : PrecisionValue{
        let upperCaseName: string = name.toUpperCase();
        let equivalentStandard: PrecisionValue;
        switch (upperCaseName){
            case "HALF":
            case "HALF_PRECISION":
            case "HALF_":
            case "FLOAT16":
            case "16":
                equivalentStandard = PrecisionValue.HALF_PRECISION;
                break
            case "SINGLE":
            case "SINGLE_PRECISION":
            case "SINGLE_":
            case "SIMPLE":
            case "SIMPLE_PRECISION":
            case "SIMPLE_":
            case "":
            case "REGULAR":
            case "NORMAL":
            case "STANDARD":
            case "FLOAT":
            case "FLOAT32":
            case "32":
                equivalentStandard = PrecisionValue.SINGLE_PRECISION;
                break
            case "DOUBLE":
            case "DOUBLE_PRECISION":
            case "DOUBLE_":
            case "FLOAT64":
            case "64":
                equivalentStandard = PrecisionValue.DOUBLE_PRECISION;
                break
            case "QUAD":
            case "QUAD_PRECISION":
            case "QUAD_":
            case "QUADRUPLE":
            case "QUADRUPLE_PRECISION":
            case "QUADRUPLE_":
            case "LONG":
            case "FLOAT128":
            case "LONG128":
            case "128":
                equivalentStandard = PrecisionValue.QUAD_PRECISION;
                break
            default:
                equivalentStandard = PrecisionValue.NON_STANDARD;
        }
        return equivalentStandard;
    }
}