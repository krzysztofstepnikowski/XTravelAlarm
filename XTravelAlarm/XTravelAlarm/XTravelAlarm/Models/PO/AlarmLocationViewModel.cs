using System;
using System.Windows.Input;
using Prism.Mvvm;

namespace XTravelAlarm.Models.PO
{
    public class AlarmLocationViewModel : BindableBase
    {
        private bool _isRunning;

        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Distance { get; set; }
        public bool IsRunning
        {
            get { return _isRunning; }
            set
            {
                if (_isRunning == value)
                {
                    return;
                }
                SetProperty(ref _isRunning, value);
                RunningStatusChanged?.Execute(value);
            }
        }

        public ICommand RunningStatusChanged { get; set; }
    }
}
