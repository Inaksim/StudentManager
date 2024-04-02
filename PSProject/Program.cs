// See https://aka.ms/new-console-template for more information
using PSProject.Model;
using PSProject.ViewModel;
using PSProject.Other;
using PSProject.View;
class Program
{
    public static void Main()
    {
        User user = new()
        {
            Name = "John",
            Password = "password123",
            Role = UserEnumRoles.STUDENT
        };

        UserViewModel userViewModel = new(user);

        UserView userView = new(userViewModel);

        userView.Display();

        Console.ReadKey();
    }
}



