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
    /// Логика взаимодействия для TeacherWindow.xaml
    /// </summary>
    public partial class TeacherWindow : Window
    {
        public TeacherWindow()
        {
            InitializeComponent();
            lvTeachers.ItemsSource = ClassHelper.AppData.Context.Teacher.ToList();
        }
        private void Filter()
        {
            List<EF.Teacher> teachers = ClassHelper.AppData.Context.Teacher.ToList();
            teachers= teachers.Where(t => t.IsDeleted == false).ToList();
            teachers = teachers.Where(i => i.FIO.ToLower().Contains(tbSearchTeacher.Text.ToLower())
            || i.FirstName.ToLower().Contains(tbSearchTeacher.Text.ToLower())
            || i.SecondName.ToLower().Contains(tbSearchTeacher.Text.ToLower())
            || i.Patronymic.ToLower().Contains(tbSearchTeacher.Text.ToLower())
            ).ToList();
            lvTeachers.ItemsSource= teachers;
        }

        private void tbSearchTeacher_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddTeacher addTeacher= new AddTeacher();
            addTeacher.ShowDialog();
            Filter();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lvTeachers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                var resClick = MessageBox.Show("Удалить преподавателя?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (resClick == MessageBoxResult.No)
                {
                    return;
                }
                try
                {
                    if (lvTeachers.SelectedItem is EF.Teacher)
                    {
                        var grp = lvTeachers.SelectedItem as EF.Teacher;

                        grp.IsDeleted = true;

                        ClassHelper.AppData.Context.SaveChanges();

                        MessageBox.Show("Преподаватель успешно удален", "Готово", MessageBoxButton.OK, MessageBoxImage.Information);
                        Filter();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void lvTeachers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(lvTeachers.SelectedItem is EF.Teacher)
            {
                var teacher = lvTeachers.SelectedItem as EF.Teacher;
                AddTeacher addTeacher = new AddTeacher(teacher);
                addTeacher.ShowDialog();
                Filter();
            }
        }
    }
}
