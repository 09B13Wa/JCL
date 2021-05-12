class BinaryNumber{
    private binaryRepresentation : Array<number>;
    private minValue: number;
    private maxValue: number;
    private currentLength: number;

    static OnesComplement(representation: Array<number>) : Array<number>{
        let newRepresentation: Array<number> = [];
        let numberOfDigits = representation.length;
        for (let position = 0; position < numberOfDigits; position++){
            let digit = representation[position];
            if (digit == 0)
                newRepresentation.push(1);
            else if (digit == 1)
                newRepresentation.push(0);
            else
                throw Error(`Error: The digit ${digit} is not 0 or 1 at position {position}` +
                    "can't be part of a binary number.");
        }

        return newRepresentation;
    }
}