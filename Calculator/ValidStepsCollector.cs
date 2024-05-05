

namespace maui_calculator.Calculator
{
    public class ValidStepsCollector
    {
        private string currentStep = "";
        private bool isValidStep;
        private List<string> steps;


        public ValidStepsCollector()
        {
            steps = new List<string>();
        }

        public IEnumerable<string> GetSteps()
        {
            return steps.AsReadOnly();
        }

        public string GetConcatSteps()
        {
            return string.Join("", GetSteps());
        }

        public string GetConcatStepsLastRemoved()
        {
            string s = string.Join("", GetSteps());
            if (s.Length > 0)
            {
               s = s.Substring(0, s.Length - 1);
            }

            return s;
        }

        public int GetNumberOfEntries()
        {
            return steps.Count;
        }

        public void RemoveLast()
        {
            if (this.currentStep == "" && GetNumberOfEntries() > 0)
            {
                steps.RemoveAt(GetNumberOfEntries() - 1);
            }
            this.currentStep = "";
        }

        public void RemoveFirst()
        {
            if (steps.Count > 0)
            {
                steps.Remove(steps[0]);
            }
        }
        public void ClearAll()
        {
            steps.Clear();
        }

        private bool continueWithTempResult(string validStep)
        {
            if (validStep.Length == 1)
            {
                return true;
            }
            return false;
        }

        public void AddNext(string step, double tempResult = 0)
        {
            CollectStep(step);

            if (this.isValidStep)
            {
                if (continueWithTempResult(step))
                {
                    if (tempResult == 0)
                    {
                        steps.Add(this.currentStep);
                    }
                    else
                    {
                        steps.Add(tempResult + this.currentStep);
                    }
                }
                else
                {
                    steps.Add(this.currentStep);
                }
                this.currentStep = "";
            }
        }

        // Put to class StepValidator (Single Resp Principle).
        private void CollectStep(string s)
        {
            this.currentStep += s;
            this.isValidStep = MathDefinition.IsOperator(s);
        }
    }
}
