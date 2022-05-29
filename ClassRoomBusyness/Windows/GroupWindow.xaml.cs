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
    /// Логика взаимодействия для GroupWindow.xaml
    /// </summary>
    public partial class GroupWindow : Window
    {
        public GroupWindow()
        {
            InitializeComponent();
            lvGroups.ItemsSource = ClassHelper.AppData.Context.Group.ToList();
        }

        private void Filter()
        {
            List<EF.Group> groups = new List<EF.Group>();
            groups = ClassHelper.AppData.Context.Group.Where(i=>i.IsDeleted==false).ToList();
            groups = groups.Where(i => i.Title.ToLower().Contains(tbSearchGroup.Text.ToLower())).ToList();
            lvGroups.ItemsSource = groups;
        }
        private void tbSearchGroup_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void lvGroups_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                var resClick = MessageBox.Show("Удалить группу?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (resClick == MessageBoxResult.No)
                {
                    return;
                }
                try
                {
                    if (lvGroups.SelectedItem is EF.Group)
                    {
                        var grp = lvGroups.SelectedItem as EF.Group;

                        grp.IsDeleted = true;

                        ClassHelper.AppData.Context.SaveChanges();

                        MessageBox.Show("Группа успешно удалена", "Готово", MessageBoxButton.OK, MessageBoxImage.Information);
                        Filter();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddGroup addGroup= new AddGroup();
            addGroup.ShowDialog();
            Filter();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
