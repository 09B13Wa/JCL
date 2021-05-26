namespace Numbers
{
    public class Integer
    {
        public static int GetNumberOfDigits(int number)
        {
            int numberOfDigits = 1;
            int baseNumber = 1;
            while (number > baseNumber)
            {
                numberOfDigits += 1;
                baseNumber *= 10;
            }

            return numberOfDigits;
        }
        
        public static int GetBaseWithNDigits(int numberOfDigits)
        {
            int baseNumber = 1;
            int numberOfDigitsComputed = 1;
            while (numberOfDigitsComputed < numberOfDigits)
            {
                numberOfDigitsComputed += 1;
                numberOfDigits *= 10;
            }
            return baseNumber;
        }
    }
}