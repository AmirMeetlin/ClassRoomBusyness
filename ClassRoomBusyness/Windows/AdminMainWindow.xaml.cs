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
    /// Логика взаимодействия для AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public AdminMainWindow()
        {
            InitializeComponent();
        }

        private void btnGroupList_Click(object sender, RoutedEventArgs e)
        {
            GroupWindow groupWindow = new GroupWindow();
            this.Hide();
            groupWindow.ShowDialog();
            this.ShowDialog();
        }

        private void btnTimeTable_Click(object sender, RoutedEventArgs e)
        {
            bool Access = true;
            TimeTable timeTable = new TimeTable(Access);
            this.Hide();
            timeTable.ShowDialog();
            this.ShowDialog();
        }

        private void btnTeacherList_Click(object sender, RoutedEventArgs e)
        {
            TeacherWindow teacherWindow = new TeacherWindow();
            this.Hide();
            teacherWindow.ShowDialog();
            this.ShowDialog();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
