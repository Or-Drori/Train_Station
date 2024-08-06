using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Train_Station.DB;
using Train_Station.Users;
using Train_Station.Wallet;

namespace Train_Station.Stations
{
    public class StationManager
    {
        private JsonDBManager<Station> _stationDbManager;
        private WalletManager _walletManager;

        public StationManager(JsonDBManager<Station> stationJsonDb, WalletManager walletManager)
        {
            _stationDbManager = stationJsonDb;
            _walletManager = walletManager;
        }

        public void PlanTravel(User user)
        {
            StationInputs.PromptForTravel();
            (var sourceStation, var destinationStation) = ValidateStations();
            double cost = PrintDistanceCost(sourceStation, destinationStation);
            if (user.Wallet - cost < 0)
            {
                Console.WriteLine("You dont have enough money");
            }
            else
            { 
                _walletManager.SubtractMoney(user, cost);
            }
        }

        private (Station ,Station) ValidateStations()
        {
            Station? sourceStation, destinationStation;
            string sourceStationName = StationInputs.PromtForSourceStation();
            sourceStation = GetStation(sourceStationName);
            while (sourceStation == null)
            {
                sourceStationName = StationInputs.PromtForSourceStation();
                sourceStation = GetStation(sourceStationName);
            }

            string destinationStationName = StationInputs.PromtForDestenetionStation();
            destinationStation = GetStation(destinationStationName);
            while (destinationStation == null || sourceStationName == destinationStationName)
            {
                destinationStationName = StationInputs.PromtForDestenetionStation();
                destinationStation = GetStation(destinationStationName);
            }

            return (sourceStation, destinationStation);
        }

        public double PrintDistanceCost(Station sourceStation, Station destinationStation)
        {
            var distance = GeoDistanceHelper.CalculateDistance(sourceStation.Coordinate, destinationStation.Coordinate);
            var cost = TravelCostAlgorithm(distance);
            ConsoleUtils.WriteWithColor($"Cost of the travel: {cost.ToString("F2")}", ConsoleColor.Red);
            return cost;
        }

        public double TravelCostAlgorithm(double distance)
        {
            var cost = (distance / 5) * 2;
            return cost;
        }

        public Station? GetStation(string stationName)
        {
            var station = _stationDbManager.GetByName(stationName);
            return station;
        }



    }
}
