using StaffTable.Database;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// Логика взаимодействия для AddUnitsPage.xaml
    /// </summary>
    public partial class AddUnitsPage : Page
    {
        List<StaffTableTabularPart> staffTables = new List<StaffTableTabularPart>();
        int id;
        int workid;
        public AddUnitsPage(int tableid, int wid)
        {
            InitializeComponent();
            foreach (var type in StaffTableDB.entities.Post.ToList())
            {
                Post.Items.Add(type);
            }
            id = tableid;
            workid = wid;
        }

        private void AddButon_Click(object sender, RoutedEventArgs e)
        {
            Post post = Post.SelectedItem as Post;
            if(post != null && Count.Text != String.Empty)
            {
                if(decimal.TryParse(Count.Text, out decimal d))
                {
                    bool b = false;
                    foreach(var items in staffTables)
                    {
                        if(items.PostID == post.PostID)
                        {
                            b = true;
                            break;
                        }
                        
                    }
                    if (b) MessageBox.Show("Такая единица уже есть", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                    {
                        StaffTableTabularPart staff = new StaffTableTabularPart();
                        staff.PostID = post.PostID;
                        staff.StaffUnits = d;
                        staff.Notes = Notes.Text;
                        staffTables.Add(staff);
                        TableDataGrid.ItemsSource = null;
                        TableDataGrid.ItemsSource = staffTables;
                    }
                }
                else MessageBox.Show("Введены некорректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if(staffTables.Count !=0)
            {
                 foreach(var i in staffTables)
                {
                    StaffTableDB.entities.addRowInStaffTable(id, i.PostID, i.StaffUnits, i.Notes);
                }
                MessageBox.Show("Документ сформирован", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                Worker w = StaffTableDB.entities.Worker.First(x=> x.WorkerID == workid);
                NavigationService.Navigate(new StaffTablesPage(w));
            }
            else
            {
                MessageBox.Show("Список пуст", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Count_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (var item in e.Text)
            {
                if (!char.IsDigit(item))
                {
                    e.Handled = true;
                }
            }
        }

        private void Count_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
