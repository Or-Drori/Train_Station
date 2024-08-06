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

        public IsraelCitiesApiResponse GetCitiesAsync()
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
                return citiesResponce;
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

        public Station? ConvertToStation(IsraelCitiesApiResponse apiResponse)
        {
            if (!apiResponse.results.Any())
            {
                return null;
            }
            var cityProperty = apiResponse.results.First();

            GeoCoordinate geoCoordinate = new(cityProperty.location.latitude, cityProperty.location.longitude);
            Station station = new Station()
            {
                Coordinate = geoCoordinate,
                Name = cityProperty.name,
                Id = cityProperty.cityId
            };
            return station;
        }
    }
}
