namespace CSharpAdvancedTask1
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class NumeralSystemsConvert
    {
        private static readonly List<string> Alphabet = new List<string>() { "cad", "xoz", "nop", "cyk", "min", "mar", "kon", "iva", "ogi", "yan" };

        const int DecimalSystemNumber = 10;
        const int LengthOfWordInAlphabet = 3;

        private static string FromDecimalToGoshoNumeralSystem(BigInteger convertedNumber)
        {
            string secondResult = string.Empty;

            do
            {
                int index = (int)(convertedNumber % DecimalSystemNumber);
                string piece = Alphabet[index];
                secondResult = piece + secondResult;
                convertedNumber /= DecimalSystemNumber;

            } while (convertedNumber > 0);

            return secondResult;
        }

        private static BigInteger FromGoshoNumeralSystemToDecimal(string number)
        {
            BigInteger result = 0;

            for (int i = 0; i < number.Length; i += LengthOfWordInAlphabet)
            {
                string letter = number.Substring(i, LengthOfWordInAlphabet);
                int decimalValue = Alphabet.IndexOf(letter);
                result = decimalValue + result * DecimalSystemNumber;
            }

            return result;
        }

        public static void Main()
        {
            string firstNumber = Console.ReadLine();
            string substractOrAddition = Console.ReadLine();
            string secondNumber = Console.ReadLine();

            BigInteger firstAnswer = FromGoshoNumeralSystemToDecimal(firstNumber);
            BigInteger secondAnswer = FromGoshoNumeralSystemToDecimal(secondNumber);

            BigInteger result = 0;
            switch (substractOrAddition)
            {
                case "+": result = firstAnswer + secondAnswer; break;
                case "-": result = firstAnswer - secondAnswer; break;
            }

            string output = FromDecimalToGoshoNumeralSystem(result);

            Console.WriteLine(output);
        }
    }
}
