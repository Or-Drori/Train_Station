using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_Station.DB;

namespace Train_Station.Users
{
    public class User : IUser, IDatabaseEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Wallet { get; set; }
        public Gender Gender { get; set; }

        public User(int id, string name, Gender gender)
        {
            Id = id;
            Name = name;
            Wallet = 0;
            Gender = gender;
        }
        

    }
}
