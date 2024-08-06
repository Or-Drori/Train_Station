using System.Data.SqlTypes;
using System.Text.Json.Nodes;
using Train_Station.DB;
using Train_Station.Wallet;

namespace Train_Station.Users
{
    public static partial class UserInputs
    {

        public static MenuOptions? PromtForMenu()
        {
            Console.WriteLine("Menu Options");
            UserInputs.PrintEnums(typeof(MenuOptions));
            Console.Write("Choose an option: ");
            string choise = Console.ReadLine();

            if (ConsoleUtils.IsValueIntNonNull(choise, out int parsedchoise))
            {
              return (MenuOptions)parsedchoise;
            }
            return null;
        }
        public static double PromptForChangingWallet(MenuOptions option)
        {
            if (option == MenuOptions.SubtractingMoney)
            {
                Console.WriteLine("Enter Sum to witraw from your wallet");
            }
            if (option == MenuOptions.AddingMoney)
            {
                Console.WriteLine("Enter Sum to Load in to your wallet");
            }
            var summoney = Console.ReadLine();
            if (ConsoleUtils.IsValueDoubleNonNull(summoney, out double parsedSummoney))
            {
                return parsedSummoney;
            }
            return 0;
        }

        public static int RegisterOrLogin()
        {
            Console.WriteLine("Press 0 to SignIn or 1 to Register");
            var menuinput = Console.ReadLine();

            if (ConsoleUtils.IsValueIntNonNull(menuinput, out int menu))
            {
               return menu;
            }

            return -999;
        }

        public static User GetRegisterInfo(JsonDBManager<User> userDBManager)
        {
            int id = GetRegisterIdFromUser(userDBManager);
            string name = GetNameFromUser();
            Gender gender = GetGenderFromUser();

            ConsoleUtils.WriteWithColor($"ID: {id}, Name: {name}, Gender: {gender}", ConsoleColor.Green);

            return Factory.CreateUser(id, name, gender);
        }
        private static Gender GetGenderFromUser()
        {
            Console.WriteLine("Lists of genders:");
            PrintEnums(typeof(Gender));

            Gender gender;
            while (true)
            {
                Console.Write("Choose your gender (enter the number): ");
                string genderInput = Console.ReadLine();
                if (int.TryParse(genderInput, out int genderKey) && Enum.IsDefined(typeof(Gender), genderKey))
                {
                    gender = (Gender)genderKey;
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a valid number corresponding to a gender.");
            }

            return gender;
        }

        public static void PrintEnums(Type enumType)
        {
            foreach (var value in Enum.GetValues(enumType))
            {
                string description = EnumHelper.GetEnumDescription((Enum)value);
                Console.WriteLine($"{(int)value} - {description}");
            }
        }
        private static string GetNameFromUser()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            return name;
        }

        public static int GetRegisterIdFromUser(JsonDBManager<User> userdb)
        {
            int id;
            while (true)
            {
                Console.Write("Enter ID: ");
                string idInput = Console.ReadLine();

                if (int.TryParse(idInput, out id) && !userdb.CheckIfIdExists(id))
                {
                    break;
                }

                Console.WriteLine("Invalid input. Please enter a valid integer ID.");
            }

            return id;
        }
        public static int GetSignInIdFromUser(JsonDBManager<User> userdb)
        {
            int id;
            while (true)
            {
                Console.Write("Enter ID: ");
                string idInput = Console.ReadLine();

                if (ConsoleUtils.IsValueIntNonNull(idInput, out id) && userdb.CheckIfIdExists(id))
                {
                    break;
                }

                Console.WriteLine("Invalid input. Please enter a valid integer ID.");
            }

            return id;
        }
        


    }
}