using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_Station.Stations
{
    public static class StationInputs
    {
        public static void PromptForTravel()
        {
            Console.WriteLine("Enter Source and Destenetion stations");
        }
        public static string PromtForSourceStation()
        {
            Console.Write("Source Station - ");
            string sourceStation = Console.ReadLine();
            return sourceStation;
        }
        public static string PromtForDestenetionStation()
        {
            Console.Write("destination Station - ");
            string destinationStation = Console.ReadLine();
            return destinationStation;
        }
    }
}
