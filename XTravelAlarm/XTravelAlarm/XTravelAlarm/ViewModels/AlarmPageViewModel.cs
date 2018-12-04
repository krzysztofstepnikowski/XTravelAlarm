using System;
using System.Collections.ObjectModel;
using System.Linq;
using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using XTravelAlarm.Models.PO;
using XTravelAlarm.Views.Alarms;
using XTravelAlarm.Utils;

namespace XTravelAlarm.ViewModels
{
    public partial class AlarmPageViewModel : BindableBase, INavigationAware, IMultiPageNavigationAware
    {
        private readonly IAlarmPageFeatures alarmPageFeatures;
        private readonly IPageDialogService pageDialogService;
        
        public AlarmPageViewModel(IAlarmPageFeatures alarmPageFeatures, IPageDialogService pageDialogService)
        {
            this.alarmPageFeatures = alarmPageFeatures;
            this.pageDialogService = pageDialogService;

            RemoveAlarm = new DelegateCommand<AlarmLocationViewModel>(DeleteAlarm);
        }

        private async void GetAlarms()
        {
            var alarms = await alarmPageFeatures.GetAllAsync();

            Alarms = new ObservableCollection<AlarmLocationViewModel>(alarms);

            IsAlarmListPlaceholderVisible = !Alarms.Any();

            foreach (var alarm in alarms)
            {
                alarm.RunningStatusChanged = new DelegateCommand<bool?>(x => RunningStatusChanged(x, alarm));
            }
        }

        private async void DeleteAlarm(AlarmLocationViewModel alarmLocation)
        {
            var result = await pageDialogService.DisplayAlertAsync("Usuwanie alarmu",
                $"Czy chcesz usunąć alarm\n{alarmLocation.Name}?", "Tak", "Nie");

            if (!result)
            {
                return;
            }

            await alarmPageFeatures.RemoveAlarmAsync(alarmLocation.Id);
            GetAlarms();
        }

        private void RunningStatusChanged(bool? isRunning, AlarmLocationViewModel alarmLocation)
        {
            if (!isRunning.HasValue)
            {
                throw new Exception("IsRunning is null");
            }

            if (isRunning.Value)
            {
                alarmPageFeatures.Enable(alarmLocation.Id);
                UserDialogs.Instance.Toast("Alarm włączony");
            }

            else
            {
                alarmPageFeatures.Disable(alarmLocation.Id);
                UserDialogs.Instance.Toast("Alarm wyłączony");
            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        { 
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            GetAlarms();
        }

        public void OnInternalNavigatedFrom(NavigationParameters navParams)
        {
        }

        public void OnInternalNavigatedTo(NavigationParameters navParams)
        {
            GetAlarms();
        }
    }
}
