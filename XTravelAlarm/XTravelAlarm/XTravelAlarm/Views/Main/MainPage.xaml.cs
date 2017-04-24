using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XTravelAlarm.Services;
using ValueChangedEventArgs = Syncfusion.SfAutoComplete.XForms.ValueChangedEventArgs;

namespace XTravelAlarm.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private async void AutoCompleteOnValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.Value == null)
            {
                return;
            }

            var googleLocationAutoComplete = new GoogleLocationAutoComplete();

            var locations = await googleLocationAutoComplete.GetPredictionsAsync(e.Value);

            AutoComplete.AutoCompleteSource = locations.ToList();

            Debug.WriteLine(e.Value);
        }
    }
}
