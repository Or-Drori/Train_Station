using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_Station.DB;
using Train_Station.Users;

namespace Train_Station.Wallet
{
    public class WalletManager : IWalletManager
    {

        JsonDBManager<User> _userDbManager;
        public WalletManager(JsonDBManager<User> jsondb)
        {
            _userDbManager = jsondb;
        }
        public void AddMoney(User user, double money)
        {
            user.Wallet += money;
            _userDbManager.Update(user);
        }
        public void SubtractMoney(User user, double money)
        {

            user.Wallet -= money;
            _userDbManager.Update(user);
        }
    }
}
