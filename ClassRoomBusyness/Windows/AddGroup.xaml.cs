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
    /// Логика взаимодействия для AddGroup.xaml
    /// </summary>
    public partial class AddGroup : Window
    {
        public AddGroup()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbGroup.Text))
            {
                MessageBox.Show("Поле ГРУППА не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var resClick = MessageBox.Show("Добавить группу?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (resClick == MessageBoxResult.No)
            {
                return;
            }

            EF.Group newGroup = new EF.Group();
            newGroup.Title = tbGroup.Text;

            ClassHelper.AppData.Context.Group.Add(newGroup);
            ClassHelper.AppData.Context.SaveChanges();
            MessageBox.Show("Группа добавлена");
            this.Close();
        }
    }
}
