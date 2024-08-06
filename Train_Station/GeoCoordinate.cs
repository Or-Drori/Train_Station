using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_Station
{
    public class GeoCoordinate
    {
        public double latitude { get; set; }
        public double longitude { get; set; }

        public GeoCoordinate(double lat, double lon)
        {
            this.latitude = lat;
            this.longitude = lon;
        }
    }
}
