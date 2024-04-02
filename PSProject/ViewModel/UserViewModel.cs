using PSProject.Model;
using PSProject.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSProject.ViewModel
{
    public class UserViewModel
    {
        private User _user;

        public UserViewModel(User user)
        {
            _user = user;
        }

        public string UserName => _user.Name;
        public UserEnumRoles UserRole => _user.Role;
    }
}
