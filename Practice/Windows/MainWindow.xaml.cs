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
using Practice.Entities;
using Practice.Model;
using Practice.Windows;

namespace Practice
{
    public partial class MainWindow : Window
    {
        Client CurrentClient;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClientListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentClient = (Client)ClientListView.SelectedItem;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ClientListView.ItemsSource = DB.entities.Client.ToList();
        }

        private void EditButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (CurrentClient != null)
            {
                EditWindows editWindows = new EditWindows(CurrentClient);
                editWindows.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Вы не выбрали элемент", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (CurrentClient != null)
            {
                DB.entities.Client.Remove(CurrentClient);
            }
            else
            {
                MessageBox.Show("Вы не выбрали элемент", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
