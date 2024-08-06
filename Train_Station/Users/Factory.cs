using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_Station.DB;

namespace Train_Station.Users
{
    public static class Factory
    {
        public static User CreateUser(int id, string name, Gender gender)
        {
            return new User(id, name, gender);
        }
    }
}
