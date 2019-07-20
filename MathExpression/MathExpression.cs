using System;
using System.Reflection;

namespace MathExpressions
{
    public class MathExpression
    {
        public int Calculate(Numbers numbers)
        {
            var multiplyResult = Multiply(numbers.Number1, numbers.Number2);

            var subtractResult = Subtract(numbers.Number4, numbers.Number3);

            var divideResult = Divide(numbers.Number6, numbers.Number5);

            return multiplyResult + subtractResult - divideResult;
        }

        private bool NumbersArePositive(Numbers numbers)
        {
            PropertyInfo[] properties = numbers.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.GetValue(numbers) != null)
                {
                    int value = (int)property.GetValue(numbers);
                    if (value < 0)
                        return false;
                }
            }

            return true;
        }

        private static bool TheFirstTwoNumbersAreZero(Numbers numbers)
        {
            return numbers.Number1 == 0 && numbers.Number2 == 0;
        }

        private static bool TheLastTwoNumbersAreZero(Numbers numbers)
        {
            return numbers.Number5 == 0 && numbers.Number6 == 0;
        }

        private int Subtract(int a, int b)
        {
            return a - b;
        }

        private int Multiply(int a, int b)
        {
            return a * b;
        }

        private int Divide(int a, int b)
        {
            return b / a;
        }

    }

    public struct Numbers
    {
        public int Number1 { get; set; }

        public int Number2 { get; set; }

        public int Number3 { get; set; }

        public int Number4 { get; set; }

        public int Number5 { get; set; }

        public int Number6 { get; set; }
    }
}
