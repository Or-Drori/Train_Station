using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_Station.DB;

namespace Train_Station.Station
{
    public class Station : IStation, IDatabaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coordinate coordinate { get; set; }

   
    }
}
