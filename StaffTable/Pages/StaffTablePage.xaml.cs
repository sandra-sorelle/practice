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
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
using Run = DocumentFormat.OpenXml.Wordprocessing.Run;
using Table = DocumentFormat.OpenXml.Wordprocessing.Table;
using TableRow = DocumentFormat.OpenXml.Wordprocessing.TableRow;
using TableCell = DocumentFormat.OpenXml.Wordprocessing.TableCell;

namespace StaffTable.Pages
{
    /// <summary>
    /// Логика взаимодействия для StaffTablePage.xaml
    /// </summary>
    public partial class StaffTablePage : Page
    {
        List<getlinesinTable_Result> table_Results;
        Worker worker;
        StaffTable1 st;
        Organization org = new Organization();
        string dateconv;
        decimal sumOfSalary;
        decimal sumOfUnits;
        public StaffTablePage(StaffTable1 staffTable1, Worker w)
        {
            InitializeComponent();
            worker = w;
            st = staffTable1;
            
            org = StaffTableDB.entities.Organization.First() as Organization;
            OrganizationTextBlock.Text = $"{org.OrganizationFullName}\n{org.OrganizationAbbreviatedName}";
            NumberTextBlock.Text = $"Номер документа: {staffTable1.StaffTableNumber}";
            DateTime dateStart = (DateTime)staffTable1.StaffTableDateStart;
            dateconv = dateStart.ToShortDateString();
            DateSostTextBlock.Text = $"Дата составления: {dateconv}";
            DateStartTextBlock.Text = $"УТВЕРЖДЕНО Приказом организации от {dateconv} №{staffTable1.StaffTableNumber}";
            table_Results = new List<getlinesinTable_Result> ();
            table_Results = StaffTableDB.entities.getlinesinTable(staffTable1.StaffTableNumber).ToList();
            sumOfUnits = 0;
            foreach(var r in table_Results)
            {
                sumOfUnits += (decimal)r.StaffUnits;
            }
            AllStateTextBlock.Text = $"Штат в количестве {sumOfUnits} единиц";
            if(staffTable1.StaffTablePeriod < 12)
            {
                
                PeriodTextBlock.Text = $"на период {staffTable1.StaffTablePeriod} месяцев с {dateconv}";
            }
            else
            {
                double countYears = (int)staffTable1.StaffTablePeriod / 12;
                PeriodTextBlock.Text = $"на период {countYears} год с {dateconv}";
            }
            
            TableDataGrid.ItemsSource = table_Results;
             sumOfSalary = 0;
            foreach (var r in table_Results)
            {
                sumOfSalary += (decimal)r.SumOfSalary;
            }
            SumOfUnitsText.Text += $"{sumOfUnits}";
            SumOfSalaryText.Text += $"{sumOfSalary}";

            List<SignatureTabularPart> signatureTabularParts = new List<SignatureTabularPart> ();
            signatureTabularParts = StaffTableDB.entities.SignatureTabularPart.Where(x => x.SignatureID == staffTable1.StaffTableNumber).ToList();
            bool BuxIsSigned = false;
            bool RukIsSigned = false;

            foreach (var part in signatureTabularParts)
            {
                Worker worker = StaffTableDB.entities.Worker.FirstOrDefault(x => x.WorkerID == part.WorkerID);
                if (worker != null)
                {
                    if (worker.PostID == 2)
                    {
                        BuxIsSigned = true;
                        BuxSignText.Text = worker.WorkerSurname;
                        BuxShifrSignText.Text = worker.WorkerSurname + " " + worker.WorkerName[0] + "." + worker.WorkerPatronimyc[0] + ".";
                        if(w.PostID == 2) SignCheckBox.Visibility = Visibility.Collapsed;
                    }
                    if (worker.PostID == 5)
                    {
                        RukIsSigned = true;
                        PostText.Text = "Начальник отдела";
                        SignText.Text = worker.WorkerSurname;
                        ShifrSignText.Text = worker.WorkerSurname + " " + worker.WorkerName[0] + "." + worker.WorkerPatronimyc[0] + ".";
                        if(w.PostID == 5)  SignCheckBox.Visibility = Visibility.Collapsed;
                    }
                }
            }
            if (BuxIsSigned && RukIsSigned) 
            { 
                SignCheckBox.Visibility = Visibility.Collapsed;
                OutputButton.Visibility = Visibility.Visible;
            }
            if(w.PostID == 2)
            SignCheckBox.Content = $"Подписать (бухгалтер)";
            else if(w.PostID ==5) SignCheckBox.Content = $"Подписать (начальник отдела)";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if(SignCheckBox.IsChecked == true)
            {
                var result = MessageBox.Show("Вы действительно хотите сохранить изменения в документе?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(result == MessageBoxResult.Yes)
                {
                    StaffTableDB.entities.AddSign(worker.WorkerID, st.StaffTableNumber);
                }
            }
            NavigationService.GoBack();
        }


        private void SignCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if(SignCheckBox.IsChecked == true)
            {
                if(worker.PostID == 2)
                {
                    BuxSignText.Text = worker.WorkerSurname;
                    BuxShifrSignText.Text = worker.WorkerSurname + " " + worker.WorkerName[0] + "." + worker.WorkerPatronimyc[0] + ".";
                }
                else
                {
                    PostText.Text = "Начальник отдела";
                    SignText.Text = worker.WorkerSurname;
                    ShifrSignText.Text = worker.WorkerSurname + " " + worker.WorkerName[0] + "." + worker.WorkerPatronimyc[0] + ".";
                }
            }
            else
            {
                if (worker.PostID == 2)
                {
                    BuxSignText.Text = "";
                    BuxShifrSignText.Text = "";
                }
                else
                {
                    PostText.Text = "";
                    SignText.Text = "";
                    ShifrSignText.Text = "";
                }
            }
        }

        private void OutputButton_Click(object sender, RoutedEventArgs e)
        {
            var helper = new WordHelper("stafftablesh5.docx");
            var items = new Dictionary<string, string> {
                {"<OrgName>", org.OrganizationFullName },
                {"<OrgAName>", org.OrganizationAbbreviatedName },
                { "<StNumber>", Convert.ToString(st.StaffTableNumber) },
                { "<StartDate>", dateconv },
                {"<SumOfUnits>", $"{sumOfUnits}" },
                { "<StPeriod>", PeriodTextBlock.Text },
                
            };
            helper.Process(items);


            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open($"stafftable{st.StaffTableNumber}.docx", true))
            {
                MainDocumentPart mainPart = wordDocument.MainDocumentPart;

                Body body = mainPart.Document.Body;

                Table table = new Table();

                // Создание строки таблицы
                TableRow row1 = new TableRow();
                row1.Append(
                    new TableCell(
                        new Paragraph(new Run(new Text("Структурное подразделение")))
                    ),
                    new TableCell(
                        new Paragraph(new Run(new Text("Должность")))
                    ),
                    new TableCell(
                        new Paragraph(new Run(new Text("Кол-во штатных единиц")))
                    ),
                    new TableCell(
                        new Paragraph(new Run(new Text("Тарифная ставка")))
                    ),
                    new TableCell(
                        new Paragraph(new Run(new Text("Всего в месяц")))
                    ),
                    new TableCell(
                        new Paragraph(new Run(new Text("Примечания")))
                    )
                );

                // Добавление строки в таблицу
                table.Append(row1);
                foreach (var t in table_Results)
                {
                    TableRow row2 = new TableRow();
                    row2.Append(
                        new TableCell(
                            new Paragraph(new Run(new Text($"{t.StructualDivisionName}")))
                        ),
                        new TableCell(
                            new Paragraph(new Run(new Text($"{t.PostName}")))
                        ),
                        new TableCell(
                            new Paragraph(new Run(new Text($"{t.StaffUnits}")))
                        ),
                        new TableCell(
                            new Paragraph(new Run(new Text($"{t.FormSalary}")))
                        ),
                        new TableCell(
                            new Paragraph(new Run(new Text($"{t.SumOfSalary}")))
                        ),
                        new TableCell(
                            new Paragraph(new Run(new Text($"{t.NotesFormat}")))
                        )
                    );
                    table.Append(row2);
                }
                // Добавление таблицы в документ
                body.Append(table);
                Paragraph paragraph = new Paragraph(new Run(new Text($"Итого:")));
                body.Append(paragraph);
                Paragraph paragraph1 = new Paragraph(new Run(new Text($"Штатных единиц: {sumOfUnits}")));
                body.Append(paragraph1);
                Paragraph paragraph2 = new Paragraph(new Run(new Text($"Всего в месяц: {sumOfSalary}")));
                body.Append(paragraph2);
                Paragraph paragraph3 = new Paragraph(new Run(new Text($"Руководитель кадровой службы         Начальник отдела (Должность)        {SignText.Text} (Подпись)         {ShifrSignText.Text} (Расшифровка подписи)")));
                body.Append(paragraph3);
                
                Paragraph paragraph5 = new Paragraph(new Run(new Text($"Бухгалтер         {BuxSignText.Text} (Подпись)       {BuxShifrSignText.Text} (Расшифровка подписи)")));
                body.Append(paragraph5);
                
                // Добавление тела документа
                mainPart.Document.Save();
            }

           

        }
    }
}
