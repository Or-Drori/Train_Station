using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_Station
{
    public static class GeoDistanceHelper
    {
        public static double CalculateDistance(GeoCoordinate coordinate1, GeoCoordinate coordinate2)
        {
            double lat1 = coordinate1.latitude;
            double lon1 = coordinate1.longitude;
            double lat2 = coordinate2.latitude;
            double lon2 = coordinate2.longitude;
            // Radius of the Earth in kilometers
            const double R = 6371.0;

            // Convert degrees to radians
            double lat1Rad = DegreesToRadians(lat1);
            double lon1Rad = DegreesToRadians(lon1);
            double lat2Rad = DegreesToRadians(lat2);
            double lon2Rad = DegreesToRadians(lon2);

            // Haversine formula
            double dlon = lon2Rad - lon1Rad;
            double dlat = lat2Rad - lat1Rad;
            double a = Math.Sin(dlat / 2) * Math.Sin(dlat / 2) +
                       Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                       Math.Sin(dlon / 2) * Math.Sin(dlon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // Distance in kilometers
            double distance = R * c;

            return distance;
        }

        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
    }
}
