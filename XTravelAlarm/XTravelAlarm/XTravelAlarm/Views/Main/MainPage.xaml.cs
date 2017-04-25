using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XTravelAlarm.Models;
using XTravelAlarm.Services;
using ValueChangedEventArgs = Syncfusion.SfAutoComplete.XForms.ValueChangedEventArgs;

namespace XTravelAlarm.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private readonly AutoCompleteViewModel tmp = new AutoCompleteViewModel();

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

            foreach (var item in locations)
            {
                tmp.AutoCompletePredictions.Add(item);
                Debug.WriteLine(item);
            }

            AutoComplete.AutoCompleteSource = tmp.AutoCompletePredictions;
        }
    }
}
