using Practice.Entities;
using Practice.Model;
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

namespace Practice.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditWindows.xaml
    /// </summary>
    public partial class EditWindows : Window
    {
        Client _client;
        public EditWindows()
        {
            InitializeComponent();
            _client = new Client();
        }
        public EditWindows(Client client)
        {
            InitializeComponent();
            _client = client;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(_client.ClientId == 0)
            {
                DB.entities.Client.Add(_client);
            }
            DB.entities.SaveChanges();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _client;
        }
    }
}
