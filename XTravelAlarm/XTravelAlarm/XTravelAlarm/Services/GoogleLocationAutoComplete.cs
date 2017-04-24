using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace XTravelAlarm.Services
{
    public class GoogleLocationAutoComplete
    {
        private readonly string key;

        public GoogleLocationAutoComplete()
        {
            key = "AIzaSyDcPhALdqGkeHyInWu0XtiU6IDnemuiqis";
        }

        public async Task<string[]> GetPredictionsAsync(string name)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(
                $"https://maps.googleapis.com/maps/api/place/autocomplete/json?input={name}&types=geocode&key={key}");
            var json = await response.Content.ReadAsStringAsync();

            var data = JObject.Parse(json);
            var predictions = data["predictions"].Children();
            var descriptions = predictions.Select(x => x["description"].ToString()).ToArray();

            return descriptions;
        }
    }
}
