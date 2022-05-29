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

namespace ClassRoomBusyness.Windows
{
    /// <summary>
    /// Логика взаимодействия для TimeTable.xaml
    /// </summary>
    public partial class TimeTable : Window
    {
        bool GloabalAccess;
        public TimeTable(bool Access)
        {
            InitializeComponent();
            lvTimeTable.ItemsSource = ClassHelper.AppData.Context.Busyness.ToList();
            if (Access == false)
            {
                btnAdd.IsEnabled = false;
            }
            GloabalAccess = Access;
        }


        private void Filter()
        {
            List<EF.Busyness> busynesses = new List<EF.Busyness>();
            busynesses = ClassHelper.AppData.Context.Busyness.ToList();

            if (tbSearchClassroom.Text.Length>0)
            {
                busynesses = busynesses.Where(i =>
                i.Classroom.Number.ToString().Contains(tbSearchClassroom.Text)
                ).ToList();
            }
            if (tbSearchGroup.Text.Length > 0)
            {
                busynesses = busynesses.Where(i =>
                i.Group.Title.ToLower().Contains(tbSearchGroup.Text.ToLower())
                ).ToList();
            }
            if (dpSelectDate.SelectedDate!=null)
            {
                busynesses = busynesses.Where(i =>
                i.DateOfClasses == dpSelectDate.SelectedDate
                ).ToList();
            }

            lvTimeTable.ItemsSource = busynesses;
        }

        private void tbSearchClassroom_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void dpSelectDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void tbSearchGroup_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lvTimeTable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(GloabalAccess==true&& lvTimeTable.SelectedItem is EF.Busyness)
            {
                var tbl= lvTimeTable.SelectedItem as EF.Busyness;
                AddTimeTable addTimeTable = new AddTimeTable(tbl);
                addTimeTable.ShowDialog();
                Filter();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddTimeTable addTimeTable = new AddTimeTable();
            addTimeTable.ShowDialog();
            Filter();
        }

        private void lvTimeTable_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Delete || e.Key == Key.Back)&& GloabalAccess==true)
            {
                var resClick = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (resClick == MessageBoxResult.No)
                {
                    return;
                }
                try
                {
                    if (lvTimeTable.SelectedItem is EF.Busyness)
                    {
                        var tbl = lvTimeTable.SelectedItem as EF.Busyness;

                        ClassHelper.AppData.Context.Busyness.Remove(tbl);

                        ClassHelper.AppData.Context.SaveChanges();

                        MessageBox.Show("Запись успешно удалена", "Готово", MessageBoxButton.OK, MessageBoxImage.Information);
                        Filter();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
