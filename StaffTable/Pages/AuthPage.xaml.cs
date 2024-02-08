using StaffTable.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace StaffTable.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
           
                Database.Worker LoginUser = Database.StaffTableDB.entities.Worker.FirstOrDefault(x => x.WorkerLogin == TextBoxLogin.Text && x.WorkerPassword == PasswordBoxPassword.Password);
                if (LoginUser != null)
                {
                    MessageBox.Show("Вход осуществлен", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new StaffTablesPage(LoginUser));
                }
                else
                {
                    MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                }
           
            
        }
    }
}
