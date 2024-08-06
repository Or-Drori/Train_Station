using System.Data.SqlTypes;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Nodes;
using System.Transactions;
using System.Xml;
using Train_Station.DB;
using Train_Station.IsraelCitiesAPI;
using Train_Station.Stations;
using Train_Station.Users;
using Train_Station.Wallet;

namespace Train_Station
{
    public class Program
    {
        static void Main(string[] args)
        {
            IsraeliCitiesApiManager israeliCitiesApiManager = new IsraeliCitiesApiManager();
            israeliCitiesApiManager.GetCitiesAsync();

            JsonDBManager<User> userDBManager = new JsonDBManager<User>("Resources\\Users.json");
            //JsonDBManager<Station> stationDBManager = new JsonDBManager<Station>("Resources\\Stations.json");

            LoginManager loginManager = new LoginManager(userDBManager);
            WalletManager walletManager = new WalletManager(userDBManager);
            StationManager stationManager = new StationManager(walletManager);
            User? user = null;


            int menu = -1;
            while (menu != 0 && menu != 1)
            {
                menu = UserInputs.RegisterOrLogin();
                if (menu == 0)
                {
                    int id = UserInputs.GetSignInIdFromUser(userDBManager);
                    user = loginManager.Singin(id);
                }
                else if (menu == 1)
                {
                    user = loginManager.Register();
                }
            }
            Console.Clear();
            
            while(true)
            {
                ConsoleUtils.PrintUserInfo(user,ConsoleColor.Green);
                MenuOptions? option = UserInputs.PromtForMenu();
                switch (option)
                {
                    case MenuOptions.AddingMoney:
                        double money = UserInputs.PromptForChangingWallet(MenuOptions.AddingMoney);
                        walletManager.AddMoney(user, money);
                        break;
                    case MenuOptions.SubtractingMoney:
                        money = UserInputs.PromptForChangingWallet(MenuOptions.SubtractingMoney);
                        walletManager.SubtractMoney(user, money);
                        break;
                    case MenuOptions.BuyingTicket:
                        stationManager.PlanTravel(user);
                        
                        break;
                    default:
                        Console.Clear();
                        break;
                }

            }
        }
    }
}
