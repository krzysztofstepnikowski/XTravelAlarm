using System.Collections.Generic;
using Prism.Mvvm;

namespace XTravelAlarm.Models
{
    public class AutoCompleteViewModel : BindableBase
    {
        private List<string> autoCompletePredictions = new List<string>();

        public List<string> AutoCompletePredictions
        {
            get { return autoCompletePredictions; }
            set { SetProperty(ref autoCompletePredictions, value); }
        }

        public AutoCompleteViewModel()
        {
        }
    }
}
