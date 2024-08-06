using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_Station.Stations;

namespace Train_Station.IsraelCitiesAPI
{
    public class IsraelCitiesApiResponse
    {
        public List<CityProperties> results { get; set; }
    }

    public class CityProperties
    {
        public int cityId;
        public string name;
        public GeoCoordinate location;

        public Station ToStation()
        {
            GeoCoordinate geoCoordinate = new(this.location.latitude, this.location.longitude);
            Station station = new Station()
            {
                Coordinate = geoCoordinate,
                Name = this.name,
                Id = this.cityId
            };

            return station;
        }
    }
}
