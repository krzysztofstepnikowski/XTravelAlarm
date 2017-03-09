using Xamarin.Forms;
using XTravelAlarm.ViewModels;

namespace XTravelAlarm.Views.Main
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MyMap = (BindingContext as MainPageViewModel)?.Map;
        }

        private void SliderOnValueChanged(object sender, ValueChangedEventArgs e)
        {
            var distance = (int) DistanceSlider.Value;
            DistanceLabel.Text = distance.ToString();
        }
    }
}
