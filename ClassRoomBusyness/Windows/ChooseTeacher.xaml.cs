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
using static ClassRoomBusyness.ClassHelper.DataTransmission;

namespace ClassRoomBusyness.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChooseTeacher.xaml
    /// </summary>
    public partial class ChooseTeacher : Window
    {
        public ChooseTeacher()
        {
            InitializeComponent();
            lvTeachers.ItemsSource = ClassHelper.AppData.Context.Teacher.ToList();
            btnAdd.IsEnabled = false;
        }
        private void Filter()
        {
            List<EF.Teacher> teachers = ClassHelper.AppData.Context.Teacher.ToList();
            teachers = teachers.Where(t => t.IsDeleted == false).ToList();
            teachers = teachers.Where(i => i.FIO.ToLower().Contains(tbSearchTeacher.Text.ToLower())
            || i.FirstName.ToLower().Contains(tbSearchTeacher.Text.ToLower())
            || i.SecondName.ToLower().Contains(tbSearchTeacher.Text.ToLower())
            || i.Patronymic.ToLower().Contains(tbSearchTeacher.Text.ToLower())
            ).ToList();
            lvTeachers.ItemsSource = teachers;
        }

        private void tbSearchTeacher_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lvTeachers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvTeachers.SelectedItem is EF.Teacher)
            {
                var teacher = lvTeachers.SelectedItem as EF.Teacher;
                GetTeacher= teacher;
                this.Close();
            }
        }
    }
}
