using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Train_Station.DB;
using Train_Station.Users;

namespace Train_Station
{
    public class LoginManager
    {
        JsonDBManager<User> _userDbManager;
        public LoginManager (JsonDBManager<User> jsondb)
        {
            _userDbManager = jsondb;
        }
        public User? Singin(int id)
        {
            return _userDbManager.GetById(id); 
        }
        public User Register()
        {
            User user = UserInputs.GetRegisterInfo(_userDbManager);
            _userDbManager.Create(user);
            return user;
        }

    }
}
