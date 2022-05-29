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
    /// Логика взаимодействия для PasswordWindow.xaml
    /// </summary>
    public partial class PasswordWindow : Window
    {
        public PasswordWindow()
        {
            InitializeComponent();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            if(tbPassword.Text == "1")
            {
                this.Hide();
                AdminMainWindow adminMainWindow = new AdminMainWindow();
                adminMainWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Введен неверный пароль","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
                this.Close();
            }
        }
    }
}
