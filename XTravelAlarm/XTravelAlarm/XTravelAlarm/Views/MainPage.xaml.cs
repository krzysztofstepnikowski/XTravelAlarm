using Xamarin.Forms;
using XTravelAlarm.ViewModels;

namespace XTravelAlarm.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MyMap = (BindingContext as MainPageViewModel)?.Map;
        }
    }
}
