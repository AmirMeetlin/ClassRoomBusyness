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
    /// Логика взаимодействия для AddTimeTable.xaml
    /// </summary>
    public partial class AddTimeTable : Window
    {
        EF.Busyness editBusyness = new EF.Busyness();
        bool IsEdit;

        string[] DoublePeriods = { "1", "2", "3", "4", "5", "6" };
        public AddTimeTable()
        {
            InitializeComponent();
            cbChooseDoublePeriod.ItemsSource = DoublePeriods;
            cbChooseDoublePeriod.SelectedIndex = 0;
        }

        public AddTimeTable(EF.Busyness busyness)
        {
            InitializeComponent();
            cbChooseDoublePeriod.ItemsSource = DoublePeriods;
            cbChooseDoublePeriod.SelectedItem = busyness.NumberOfDoublePeriod;
            btnChooseTeacher.Content= busyness.Teacher.FIO;
            btnChooseGroup.Content = busyness.Group.Title;
            btnChooseClass.Content = busyness.Classroom.Number;
            dpSelectDate.SelectedDate = busyness.DateOfClasses;

            GetClassroom= busyness.Classroom;
            GetGroup=busyness.Group;
            GetTeacher= busyness.Teacher;

            editBusyness=busyness;
            IsEdit=true;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var ClassCheck = ClassHelper.AppData.Context.Busyness.ToList().
                Where(i => i.IdClassroom == GetClassroom.Id && i.NumberOfDoublePeriod == DoublePeriods[cbChooseDoublePeriod.SelectedIndex] && i.DateOfClasses == dpSelectDate.SelectedDate).FirstOrDefault();

            var TeacherCheck = ClassHelper.AppData.Context.Busyness.ToList().
                Where(i => i.IdTeacher == GetTeacher.Id && i.NumberOfDoublePeriod == DoublePeriods[cbChooseDoublePeriod.SelectedIndex] && i.DateOfClasses == dpSelectDate.SelectedDate).FirstOrDefault();

            var GroupCheck = ClassHelper.AppData.Context.Busyness.ToList().
                Where(i => i.IdGroup == GetGroup.Id && i.NumberOfDoublePeriod == DoublePeriods[cbChooseDoublePeriod.SelectedIndex] && i.DateOfClasses == dpSelectDate.SelectedDate).FirstOrDefault();

            if (GetGroup == null)
            {
                MessageBox.Show("Необходимо выбрать ГРУППУ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (GetClassroom == null)
            {
                MessageBox.Show("Необходимо выбрать КАБИНЕТ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (GetTeacher == null)
            {
                MessageBox.Show("Необходимо выбрать ПРЕПОДАВАТЕЛЯ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (dpSelectDate.SelectedDate == null)
            {
                MessageBox.Show("Необходимо выбрать ДАТУ ЗАНЯТИЙ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (ClassCheck != null)
            {
                MessageBox.Show("Данный кабинет уже занят", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (GroupCheck != null)
            {
                MessageBox.Show("Данная группа уже занята", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (TeacherCheck != null)
            {
                MessageBox.Show("Данный преподаватель уже занят", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (IsEdit)
            {
                var resClick = MessageBox.Show("Изменить запись?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (resClick == MessageBoxResult.No)
                {
                    return;
                }

                editBusyness.IdTeacher = GetTeacher.Id;
                editBusyness.IdClassroom = GetClassroom.Id;
                editBusyness.IdGroup = GetGroup.Id;
                editBusyness.NumberOfDoublePeriod = DoublePeriods[cbChooseDoublePeriod.SelectedIndex];
                editBusyness.DateOfClasses = Convert.ToDateTime(dpSelectDate.SelectedDate);

                ClassHelper.AppData.Context.SaveChanges();
                MessageBox.Show("Запись успешно изменена");
                this.Close();
            }
            else
            {
            
                var resClick = MessageBox.Show("Добавить запись?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (resClick == MessageBoxResult.No)
                {
                    return;
                }
                EF.Busyness busyness = new EF.Busyness();

                busyness.IdTeacher = GetTeacher.Id;
                busyness.IdClassroom = GetClassroom.Id;
                busyness.IdGroup = GetGroup.Id;
                busyness.NumberOfDoublePeriod = DoublePeriods[cbChooseDoublePeriod.SelectedIndex];
                busyness.DateOfClasses = Convert.ToDateTime(dpSelectDate.SelectedDate);

                ClassHelper.AppData.Context.Busyness.Add(busyness);
                ClassHelper.AppData.Context.SaveChanges();
                MessageBox.Show("Запись успешно добавлена!");
                this.Close();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            GetClassroom = null;
            GetGroup = null;
            GetTeacher=null;
            this.Close();
        }

        private void btnChooseGroup_Click(object sender, RoutedEventArgs e)
        {
            ChooseGroup chooseGroup= new ChooseGroup();
            chooseGroup.ShowDialog();

            if(GetGroup!=null)
            {
                btnChooseGroup.Content = GetGroup.Title;
            }
        }

        private void btnChooseTeacher_Click(object sender, RoutedEventArgs e)
        {
            ChooseTeacher chooseTeacher= new ChooseTeacher();
            chooseTeacher.ShowDialog();

            if (GetTeacher != null)
            {
                btnChooseTeacher.Content = GetTeacher.FIO;
                btnChooseTeacher.FontSize = 10;
            }
        }

        private void btnChooseClass_Click(object sender, RoutedEventArgs e)
        {
            ChooseClass chooseClass= new ChooseClass();
            chooseClass.ShowDialog();
            if(GetClassroom!=null)
            {
                btnChooseClass.Content = GetClassroom.Number;
            }
        }
    }
}
