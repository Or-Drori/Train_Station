using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Train_Station.Users;

namespace Train_Station
{
    public static class ConsoleUtils
    {

        public static void ChangeConsoleColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public static void WriteWithColor(string text, ConsoleColor color)
        {
            var initialColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.WriteLine(text);

            Console.ForegroundColor = initialColor;
        }

        public static void PrintUserInfo(IUser user, ConsoleColor color)
        {
            var initialColor = Console.ForegroundColor;
            Console.ForegroundColor = color;

            Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Gender: {user.Gender}, Wallet: {user.Wallet.ToString("f2")}");
            Console.ForegroundColor = initialColor;
        }

        public static bool IsValueIntNonNull(string userInput, out int parsedValue)
        {
            parsedValue = 0;

            if (string.IsNullOrEmpty(userInput))
            {
                return false;
            }

            return int.TryParse(userInput, out parsedValue);
        }
        public static bool IsValueDoubleNonNull(string userInput, out double parsedValue)
        {
            parsedValue = 0;

            if (string.IsNullOrEmpty(userInput))
            {
                return false;
            }

            return double.TryParse(userInput, out parsedValue);
        }


    }
}
