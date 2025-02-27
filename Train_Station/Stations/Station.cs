﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_Station.DB;

namespace Train_Station.Stations
{
    public class Station : IStation, IDatabaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GeoCoordinate Coordinate { get; set; }

        public Station(int id, string name, GeoCoordinate coordinate)
        {
            this.Id = id;
            this.Name = name;
            this.Coordinate = coordinate;
        }
        public Station()
        {
              
        }


    }
}
