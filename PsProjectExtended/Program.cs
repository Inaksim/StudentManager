using PSProject.Model;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using PSProject.Other;
using PsProjectExtended.Others;
using Microsoft.Extensions.Logging;
using PSProject.ViewModel;
using PSProject.View;
using PsProjectExtended.Helpers;
using PsProjectExtended.Data;


namespace PsProjectExtended
{
    class Program
    {

        static void Main(string[] args)
        {

            /* ILogger logger = LoggerHelper.GetLogger("Main");
             try
             {
                 var user = new User
                 {
                     Name = "Test",
                     Password = "password",
                     Role = UserEnumRoles.ANONYMOUS
                 };

                 var viewModel = new UserViewModel(user);
                 var view = new UserView(viewModel);
                 view.Display();
                 view.DisplayError();
             } catch (Exception ex)
             {
                 logger.LogError(ex, "Error: {ErrorMessage}", ex.Message);
             } finally
             {
                 logger.LogInformation("Finish");
             }
             Console.ReadKey();*/

            

            UserData userData = new();

            User studentUSer = new User()
            {
                Name = "student",
                Password = "password",
                Role = UserEnumRoles.STUDENT

            };
            userData.AddUser(studentUSer);

            User teacherUser = new User()
            {
                Name = "Teacher",
                Password = "1234",
                Role = UserEnumRoles.PROFESSOR
            };
            userData.AddUser(teacherUser);

            User adminUser = new User()
            {
                Name = "Admin",
                Password = "12345",
                Role = UserEnumRoles.ADMIN
            };
            userData.AddUser(adminUser);

            Console.WriteLine("Enter your username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();

            
            string validationMessage = UserHelper.ValidateCredentials(username, password);
            if (!string.IsNullOrEmpty(validationMessage))
            {
                Console.WriteLine(validationMessage);
                return;
            }

            
            User currentUser = UserHelper.GetUser(userData, username, password);
            if (currentUser != null)
            {
                
                Console.WriteLine($"User details:{UserHelper.ToString(currentUser)}");
            }
            else
            {
                
                Console.WriteLine("User not found.");
            }

            Console.ReadKey();
        }
    }

}