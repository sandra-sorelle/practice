
using MaterialDesignThemes.Wpf;
using StaffTable.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для StaffTablesPage.xaml
    /// </summary>
    public partial class StaffTablesPage : Page
    {
        Worker worker1;

        public StaffTablesPage(Worker worker)
        {
            InitializeComponent();
            try
            {
                StaffTableListView.ItemsSource = StaffTableDB.entities.StaffTable1.ToList();
            }
            catch (Exception e)
            {
                SendMistake s = new SendMistake();
                s.SendMessage(worker.WorkerEmail, worker.WorkerEmailPassword, e);
            }
            
            worker1 = worker;
            if(worker1.PostID == 5)
            {
                AddButton.Visibility = Visibility.Collapsed;
                DeleteButton.Visibility = Visibility.Collapsed;
            }
                
        }

        //private void SeeOrderImage_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    var Img = sender as Image;
        //    var SelectedOrder = Img.DataContext as StaffTable1;
        //    if (SelectedOrder != null)
        //    {
        //        NavigationService.Navigate(new StaffTablePage(SelectedOrder, worker1));
        //    }
        //}

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTablePage(worker1.WorkerID));
        }

        private void SeeOrderIcon_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var Icn = sender as PackIcon;
            var SelectedOrder = Icn.DataContext as StaffTable1;
            if (SelectedOrder != null)
            {
                NavigationService.Navigate(new StaffTablePage(SelectedOrder, worker1));
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            StaffTableListView.ItemsSource = StaffTableDB.entities.StaffTable1.ToList();
        }

        private void ErrorButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            StaffTable1 CurrentStaff = (StaffTable1)StaffTableListView.SelectedItem; if (CurrentStaff != null)
            {
                if (MessageBox.Show("Вы точно хотите удалить документ?", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    Database.StaffTableDB.entities.DeleteStaffTable(CurrentStaff.StaffTableNumber);
                    StaffTableListView.ItemsSource = StaffTableDB.entities.StaffTable1.ToList();
                }
                else
                {
                    MessageBox.Show("Данные не будут удалены.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали документ!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
