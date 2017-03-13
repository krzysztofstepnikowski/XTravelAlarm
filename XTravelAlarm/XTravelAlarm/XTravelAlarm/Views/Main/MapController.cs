using Xamarin.Forms.Maps;

namespace XTravelAlarm.Views.Main
{
    public class MapController : IMainPageView
    {
        private readonly Map map;

        public MapController(Map map)
        {
            this.map = map;
        }

        public void MoveMap(Features.Position position)
        {
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude),
               Xamarin.Forms.Maps.Distance.FromMeters(1)));
        }


    }
}
