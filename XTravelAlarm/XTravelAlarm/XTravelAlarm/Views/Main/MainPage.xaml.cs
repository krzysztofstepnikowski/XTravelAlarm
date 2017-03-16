using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XTravelAlarm.ViewModels;

namespace XTravelAlarm.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MyMap = (BindingContext as MainPageViewModel)?.Map;
        }

     
    }
}
