namespace maui_calculator
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                switch (button.AutomationId)
                {
                    case "btnDelete":
                        labelResult.Text = "";
                        break;

                    default:
                        labelResult.Text += "0";
                        break;
                }
            }
        }
    }
}