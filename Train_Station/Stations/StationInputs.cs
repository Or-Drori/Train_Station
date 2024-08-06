using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_Station.Stations
{
    public static class StationInputs
    {
        public static (string? source, string? destention)? PromptForTravel()
        {
            Console.WriteLine("Enter Source Station and destination station");
            string? sourceStation = Console.ReadLine();
            string? destinationStation = Console.ReadLine();
            var Travel = (sourceStation, destinationStation);
            return Travel;
        }
    }
}
