using System.Collections.Generic;
using System.Linq;

namespace TestProject1
{
    public class Number
    {
        public int Integer { get; set; }

        public static bool AreAllNumbersEven(IEnumerable<int> numbers)
        {
            return numbers.Any(number => number % 2 == 0);
        }

        public static bool IsStringArrayOfEvenNumbers(int[] numbers)
        {
            //TODO
            return true;
        }
    }
}