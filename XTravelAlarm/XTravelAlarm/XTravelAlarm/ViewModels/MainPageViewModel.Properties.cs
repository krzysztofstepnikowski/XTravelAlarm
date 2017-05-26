namespace XTravelAlarm.ViewModels
{
    public partial class MainPageViewModel
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private int _distance;

        public int Distance
        {
            get { return _distance; }
            set { SetProperty(ref _distance, value); }
        }
    }
}
