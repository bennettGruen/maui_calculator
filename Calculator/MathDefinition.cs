

namespace maui_calculator.Calculator
{
    public static class MathDefinition
    {
        public static bool IsOperator(string s)
        {
            string[] operators = { "+", "-", "*", "/", "=" };

            foreach (string op in operators)
            {
                if (s == op)
                {
                    return true;
                }
            }

            return false;
        }

        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new MathDefinitionException("Division by zero not allowed.");
            }

            return a / b;
        }
    }
}
