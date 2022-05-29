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
    /// Логика взаимодействия для ChooseClass.xaml
    /// </summary>
    public partial class ChooseClass : Window
    {
        public ChooseClass()
        {
            InitializeComponent();
            lvClasses.ItemsSource=ClassHelper.AppData.Context.Classroom.ToList();
        }
        private void Filter()
        {
            List<EF.Classroom> classrooms = ClassHelper.AppData.Context.Classroom.ToList();
            classrooms= classrooms.Where(i=>i.Number.ToString().Contains(tbSearchClass.Text)).ToList();
            lvClasses.ItemsSource=classrooms;
        }

        private void tbSearchClass_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void lvClasses_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(lvClasses.SelectedItem is EF.Classroom)
            {
                var classroom    = lvClasses.SelectedItem as EF.Classroom;
                GetClassroom = classroom;
                this.Close();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
