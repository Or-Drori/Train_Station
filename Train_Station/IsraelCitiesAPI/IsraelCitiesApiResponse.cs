using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
