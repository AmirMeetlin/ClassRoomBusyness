using ClassRoomBusyness.Windows;
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

namespace ClassRoomBusyness
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTimeTable_Click(object sender, RoutedEventArgs e)
        {
            bool Access = false;
            TimeTable timeTable=new TimeTable(Access);
            this.Hide();
            timeTable.ShowDialog();
            this.ShowDialog();
        }

        private void btnForAdmins_Click(object sender, RoutedEventArgs e)
        {
            PasswordWindow passwordWindow=new PasswordWindow();
            this.Hide();
            passwordWindow.ShowDialog();
            this.ShowDialog();
        }
    }
}
