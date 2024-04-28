namespace maui_calculator
{
    public partial class MainPage : ContentPage
    {
       // int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            labelResult.Text += "X";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}