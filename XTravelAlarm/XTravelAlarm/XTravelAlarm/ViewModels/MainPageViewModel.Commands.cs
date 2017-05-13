using System.Windows.Input;
using Xamarin.Forms;
using ValueChangedEventArgs = Syncfusion.SfAutoComplete.XForms.ValueChangedEventArgs;

namespace XTravelAlarm.ViewModels
{
    partial class MainPageViewModel
    {
        public ICommand SaveAlarmCommand { get; }
        public Command<ValueChangedEventArgs> AutoCompleteCommand { get; }
    }
}
