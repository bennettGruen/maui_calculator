using maui_calculator.Calculator;

namespace maui_calculator
{
    public partial class MainPage : ContentPage
    {
        private ValidStepsCollector steps;
        private CalcOperation calc;

        public MainPage()
        {
            InitializeComponent();

            steps = new ValidStepsCollector();
            calc = new CalcOperation(steps);
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                double result;

                switch (button.AutomationId)
                {
                    case "btnDelete":
                        labelResult.Text = "";
                        labelInput.Text = "";

                        steps.ClearAll();
                        break;

                    case "btnDeleteStep":
                        steps.RemoveLast();
                        labelInput.Text = steps.GetConcatStepsLastRemoved();
                        break;

                    case "btnEquals":
                        steps.AddNext(button.Text);

                        result = calc.CalculationResult();
                        labelResult.Text = result.ToString();
                        labelInput.Text = "";

                        steps.ClearAll();
                        break;

                    default:
                        steps.AddNext(button.Text, calc.GetTempResult());
                        calc.ResetTempResult();

                        labelInput.Text += button.Text;
                        break;
                }
            }
        }
    }
}
