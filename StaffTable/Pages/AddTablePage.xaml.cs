using StaffTable.Database;
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

namespace StaffTable.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddTablePage.xaml
    /// </summary>
    public partial class AddTablePage : Page
    {
        int number;
        DateTime date;
        int id;
        public AddTablePage(int workerid)
        {
            InitializeComponent();
            number = StaffTableDB.entities.StaffTable1.Max(x => x.StaffTableNumber);
            Number.Text = (++number).ToString();
            date = DateTime.Now;
            Date.Text = date.ToShortDateString();
            id = workerid;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if(Period.Text == String.Empty)
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    int per = int.Parse(Period.Text);
                    StaffTableDB.entities.AddSignature();
                    int signid = StaffTableDB.entities.Signature.Max(x => x.SignatureID);
                    StaffTableDB.entities.addStaffTable(date.AddMonths(per), per, signid);
                    NavigationService.Navigate(new AddUnitsPage(signid, id));
                }
                catch (Exception e2)
                {
                    //Worker w = StaffTableDB.entities.Worker.First(x => x.WorkerID == id);
                    //SendMistake s = new SendMistake();
                    //s.SendMessage(w.WorkerEmail, w.WorkerEmailPassword, e2);
                    ////SupportDatabase.Task task = new SupportDatabase.Task();
                    ////task.Subject = e2.Message;
                    ////task.Body = e2.ToString();
                    ////task.Date = DateTime.Now;
                    ////DBClass.suport.Task.Add(task);
                    ////DBClass.suport.SaveChanges();
                }
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Period_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckDigit(e, Period);
        }

        static public void CheckDigit(TextCompositionEventArgs e, TextBox textbox)
        {
            foreach (var item in e.Text)
            {
                if (!char.IsDigit(item))
                {
                    e.Handled = true;
                }
            }
        }

        private void Period_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space) 
            { 
                e.Handled = true;
            }
        }
    }
}
