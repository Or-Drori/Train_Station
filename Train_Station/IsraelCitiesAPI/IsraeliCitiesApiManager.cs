using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using Train_Station.Stations;

namespace Train_Station.IsraelCitiesAPI
{
    public class IsraeliCitiesApiManager
    {
        public static readonly HttpClient client = new HttpClient();
        public string baseUrl = "https://parseapi.back4app.com/classes/City";
        private string appId = "3weosiutAnAaPOxJsZSr2vCMvYe03u6exstY2RE6"; // Fake app's application id
        private string masterKey = "6OxeLaPRkf89GyFBcbopxOgojfBGO9PXtpQgjyBK";

        public List<Station> GetCitiesAsync()
        {
            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("X-Parse-Application-Id", appId);
                client.DefaultRequestHeaders.Add("X-Parse-Master-Key", masterKey);

                var responce = client.GetAsync(baseUrl).Result;
                responce.EnsureSuccessStatusCode();
                var responseBody = responce.Content.ReadAsStringAsync().Result;

                var citiesResponce = JsonConvert.DeserializeObject<IsraelCitiesApiResponse>(responseBody);
                return ConvertToListStation(citiesResponce);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }
        }
        public Station? GetCitiesByNameAsync(string cityName)
        {
            try
            {
                var whereClause = new
                {
                    name = cityName
                };

                string whereJson = JsonConvert.SerializeObject(whereClause);
                string encodedWhere = HttpUtility.UrlEncode(whereJson);
                string url = $"{baseUrl}?where={encodedWhere}";

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("X-Parse-Application-Id", appId);
                client.DefaultRequestHeaders.Add("X-Parse-Master-Key", masterKey);

                var response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                var responseBody = response.Content.ReadAsStringAsync().Result;

                var citiesResponse = JsonConvert.DeserializeObject<IsraelCitiesApiResponse>(responseBody);

                return ConvertToStation(citiesResponse);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return null;
            }

        }

        private Station? ConvertToStation(IsraelCitiesApiResponse apiResponse)
        {
            if (!apiResponse.results.Any())
            {
                return null;
            }
            var cityProperty = apiResponse.results.First();

            return cityProperty.ToStation();
        }
        private List<Station> ConvertToListStation(IsraelCitiesApiResponse apiResponse)
        {
            if (!apiResponse.results.Any())
            {
                return null;
            }
            List<Station> stations = new List<Station>();
            foreach (var result in apiResponse.results)
            {
                var resultStation = result.ToStation();
                stations.Add(resultStation);
            }
            return stations;
        }
    }
}
