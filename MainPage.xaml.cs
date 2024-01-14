using System.ComponentModel;

namespace WlasciwosciCzcionki
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private string[] quotes = { "Dzień dobry", "Good morning", "Buenos dias" };
        private int currentQuoteIndex = 0;


        private double sliderValue;
        public double SliderValue
        {
            get { return sliderValue; }
            set
            {
                if (sliderValue != value)
                {
                    sliderValue = value;
                    OnPropertyChanged(nameof(SliderValue));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            SliderValue = value;
            label.FontSize = value;
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            currentQuoteIndex = (currentQuoteIndex + 1) % quotes.Length;
            label.Text = quotes[currentQuoteIndex];
        }
    }
}
