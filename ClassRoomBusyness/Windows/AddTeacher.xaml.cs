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
    /// Логика взаимодействия для AddTeacher.xaml
    /// </summary>
    public partial class AddTeacher : Window
    {
        bool isEdit = false;
        EF.Teacher editTeacher= new EF.Teacher();
        public AddTeacher()
        {
            InitializeComponent();
        }
        public AddTeacher(EF.Teacher teacher)
        {
            InitializeComponent();
            tbFirstName.Text = teacher.FirstName;
            tbSecondName.Text = teacher.SecondName;
            tbPatronymic.Text = teacher.Patronymic;

            isEdit = true;
            editTeacher = teacher;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void textBoxes_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "ячсмитьбюфывапролджэйцукенгшщзхъЯЧСМИТЬБЮФЫВАПРОЛДЖЭЙЦУКЕНГШЩЗХЪ-".IndexOf(e.Text) < 0;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbFirstName.Text))
            {
                MessageBox.Show("Поле ФАМИЛИЯ не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbSecondName.Text))
            {
                MessageBox.Show("Поле ИМЯ не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            

            if (isEdit)
            {
                var resClick = MessageBox.Show("Изменить преподавателя?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (resClick == MessageBoxResult.No)
                {
                    return;
                }
                
                editTeacher.FirstName = tbFirstName.Text;
                editTeacher.SecondName = tbSecondName.Text;
                editTeacher.Patronymic = tbPatronymic.Text;

                ClassHelper.AppData.Context.SaveChanges();
                MessageBox.Show("Преподаватель изменен");
                this.Close();
            }
            else
            {
                var resClick = MessageBox.Show("Добавить преподавателя?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (resClick == MessageBoxResult.No)
                {
                    return;
                }

                EF.Teacher newTeacher = new EF.Teacher();
                newTeacher.FirstName = tbFirstName.Text;
                newTeacher.SecondName = tbSecondName.Text;
                newTeacher.Patronymic = tbPatronymic.Text;

                ClassHelper.AppData.Context.Teacher.Add(newTeacher);
                ClassHelper.AppData.Context.SaveChanges();
                MessageBox.Show("Преподаватель добавлен");
                this.Close();
            }
        }
    }
}
