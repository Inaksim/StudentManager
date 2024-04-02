using PSProject.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSProject.Model
{
    public  class User
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public  UserEnumRoles Role { get; set; }
        public int Id { get;set; }
        public DateTime Expire { get; set; }

        public User(String name, String password, UserEnumRoles role) 
        {
            Name = name;
            Password = password;
            Role = role;
        }

        public User(){}
    }
}
