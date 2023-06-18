using DemExam2023.Data;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;

namespace DemExam2023.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            var ctx = new ApplicationDbContext();

            var login = LoginTextBox.Text;
            var password = PasswordTextBox.Text;

            var user = ctx.Users.Include(u => u.Role).SingleOrDefault(u => u.Login == login && u.Password == password);

            var userIsExist = user != null;

            if (userIsExist)
            {
                var mainWindow = new MainWindow(user, ctx);
                var currentWindow = Application.Current.MainWindow;
                mainWindow.Show();
                Application.Current.MainWindow = mainWindow;
                currentWindow.Close();
            }
            else
                MessageBox.Show("Данные не корректны!");
        }
    }
}
