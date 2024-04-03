using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataLayer.Database;
using DataLayer.Model;

namespace UI.Components
{
    /// <summary>
    /// Interaction logic for StudentList.xaml
    /// </summary>
    public partial class StudentList : UserControl
    {
        public StudentList()
        {
            InitializeComponent();

        }
        public void LoadUserData()
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
                
               

                var records = context.Users.ToList();
                var existingUser = context.Users.FirstOrDefault();
                MessageBox.Show($"User ID: {existingUser.Id}, Name: {existingUser.Name}, Role: {existingUser.Role}");
                if (records != null)
                {
                    students.DataContext = records;
                    students.ItemsSource = records;
                    MessageBox.Show($"{records.Count}");
                }
                else
                {
                    MessageBox.Show("No records found.");
                }
            }
        }
    }
}
