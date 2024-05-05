

namespace maui_calculator.Calculator
{
    public class CalcOperation
    {
        private ValidStepsCollector steps;
        private double leftOperand = 0;
        private double rightOperand = 0;
        private string currentOperator;
        private double tempResult = 0;


        public CalcOperation(ValidStepsCollector steps)
        {
            this.steps = steps;
        }

        public double CalculationResult()
        {
            return PrepareCalculation();
        }

        public double GetTempResult()
        {
            return tempResult;
        }

        public void ResetTempResult() 
        {
            this.tempResult = 0; 
        }

        public double PrepareCalculation()
        {
            int stepKey = 0;
            foreach (string step in steps.GetSteps())
            {
                int stepLen = step.Length;

                if (stepKey == 0)
                {
                    if (stepLen > 1)
                    {
                        this.leftOperand = double.Parse(step.Substring(0, stepLen - 1));
                    } 
                    else
                    {
                        this.leftOperand = 0;
                    }
                    this.currentOperator = step[stepLen - 1].ToString();
                }
                else
                {
                    if (stepLen > 1)
                    {
                        this.rightOperand = double.Parse(step.Substring(0, stepLen - 1));
                    }
                    else
                    {
                        this.rightOperand = 0;
                    }

                    if (!MathDefinition.IsOperator(this.currentOperator))
                    {
                        throw new MathDefinitionException("Invalid operator: " + this.currentOperator);
                    }
                    this.leftOperand = ExecuteCalculation();

                    this.currentOperator = step[stepLen - 1].ToString();
                }
                stepKey++;
            }

            return this.leftOperand;
        }

        private double ExecuteCalculation()
        {
            double result;

            switch (this.currentOperator)
            {
                case "+":
                    result = MathDefinition.Add(this.leftOperand, this.rightOperand);
                    break;
                case "-":
                    result = MathDefinition.Subtract(this.leftOperand, this.rightOperand);
                    break;
                case "*":
                    result = MathDefinition.Multiply(this.leftOperand, this.rightOperand);
                    break;
                case "/":
                    try
                    {
                        result = MathDefinition.Divide(this.leftOperand, this.rightOperand);
                    }
                    catch (MathDefinitionException)
                    {
                        result = this.leftOperand;
                    }
                    break;
                default:
                    result = this.leftOperand;

                    return result;
            }
            this.tempResult = result;

            return result;
        }
    }
}
