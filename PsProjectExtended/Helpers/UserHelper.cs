using PSProject.Model;
using PsProjectExtended.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PsProjectExtended.Helpers
{
    static class UserHelper
    {
        
        public static string ToString(this User user) 
        {
            return $"Name: {user.Name}, Password: {user.Password}, Role: {user.Role}";
        }

        public static string ValidateCredentials(string name, string password) 
        {
            if (string.IsNullOrEmpty(name))
                return "The name cannot be empty.";

            if (string.IsNullOrEmpty(password))
                return "The password cannot be empty.";

            return string.Empty;

        }

        public static User GetUser(UserData userData, string name, string password) 
        {
            return userData.GetUser(name, password);
        }
    }
}
