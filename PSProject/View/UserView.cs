using PSProject.Other;
using PSProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSProject.View
{
      public class UserView
    {
        private UserViewModel _viewModel;
        public  UserView (UserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Display()
        {
            Console.WriteLine("Welcome");
            Console.WriteLine($"User: {_viewModel.UserName}");
            Console.WriteLine($"Role: {_viewModel.UserRole}");

        }
        public void DisplayError()
        {
            throw new Exception("Error");

        }
    }


}
