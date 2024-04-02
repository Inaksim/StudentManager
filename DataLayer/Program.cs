using DataLayer.Database;
using DataLayer.Model;

class Program
{
    public static void Main(string[] args)
    {
        using (var context = new DatabaseContext())
        {
            context.Database.EnsureCreated();
            context.Add<DataBaseUser>(new DataBaseUser()
            {
                Name = "Test",
                Password = "password",
                Expire = DateTime.Now,
                Role = PSProject.Other.UserEnumRoles.STUDENT
            });
            context.SaveChanges();
            var users = context.Users.ToList();

            Console.WriteLine("Username:");
            string username = Console.ReadLine();

            Console.WriteLine("password:");
            string password = Console.ReadLine();


            bool isValid = context.Users.Any(u => u.Name == username && u.Password == password);
            if (isValid) Console.WriteLine("Valid"); 
            else Console.WriteLine("Invalid");
            Console.ReadKey();
        }


    
    }
}