using System.Data.SqlTypes;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Nodes;
using System.Transactions;
using System.Xml;
using Train_Station.DB;
using Train_Station.Users;
using Train_Station.Wallet;

namespace Train_Station
{
    public class Program
    {
        static void Main(string[] args)
        {
            JsonDBManager<User> userDBManager = new JsonDBManager<User>("Resources\\Users.json");
            JsonDBManager<User> stationDBManager = new JsonDBManager<User>("Resources\\Stations.json");
            LoginManager loginManager = new LoginManager(userDBManager);
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
                        WalletManager walletManager = new WalletManager(userDBManager);
                        walletManager.AddMoney(user, money);
                        break;
                    case MenuOptions.SubtractingMoney:
                        money = UserInputs.PromptForChangingWallet(MenuOptions.SubtractingMoney);
                        walletManager = new WalletManager(userDBManager);
                        walletManager.SubtractMoney(user, money);
                        break;
                    case MenuOptions.BuyingTicket:
                        Console.WriteLine("Buying ticket selected.");
                        break;
                    default:
                        Console.Clear();
                        break;
                }

            }





        }

        
    }
}
