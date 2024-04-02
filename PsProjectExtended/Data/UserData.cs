using Microsoft.VisualBasic.FileIO;
using PSProject.Model;
using PSProject.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PsProjectExtended.Data
{
    public class UserData
    {
        private List<User> _users;
        private int _nextId;

        public UserData()
        {
            _users = new List<User>();
            _nextId = 0;
        }

        public void AddUser(User user)
        {
            _users.Add(user);
            user.Id = _nextId++;
        }

        public void DeleteUser(User user)
        {
            _users.Remove(user);
        }

        public bool ValidateUser(string name, string password)
        {
            foreach (var user in _users)
            {
                if (user.Name == name && user.Password == password)
                {
                    return true;
                }

            }
            return false;
        }
        
        public User GetUser(string name, string password) 
        {
            return _users.FirstOrDefault(u => u.Name == name && u.Password == password);
        }
        public bool ValidateUserLambda(string name, string password)
        {
            return _users.Where(x => x.Name == name && x.Password == password)
                .FirstOrDefault() != null ? true : false;
        }

        public bool ValidateUserLinq(string name, string password)
        {
            var ret = from user in _users
                      where user.Name == name && user.Password == password
                      select user.Id;
            return ret != null ? true : false;
        }

        public void setActive(string name, DateTime expires)
        {
            var user = _users.FirstOrDefault(u => u.Name == name);
            if (user != null)
            {
                user.Expire = expires;
            }


        }
        

        public void AssignUserRole(string name ,string role)
        {
            User u = (User)(from user in _users
                            where user.Name == name
                            select user);

            switch (role)
            {
                case "STUDENT": u.Role = (UserEnumRoles.STUDENT); break;
                case "ANONYMOUS": u.Role = (UserEnumRoles.ANONYMOUS); break;
                case "ADMIN": u.Role = (UserEnumRoles.ADMIN); break;
                case "INSPECTOR": u.Role = (UserEnumRoles.INSPECTOR); break;
                case "PROFESSOR": u.Role = (UserEnumRoles.PROFESSOR); break;

            }
        }
    }
}
