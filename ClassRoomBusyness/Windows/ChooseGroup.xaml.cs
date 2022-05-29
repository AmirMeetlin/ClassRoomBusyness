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
    /// Логика взаимодействия для ChooseGroup.xaml
    /// </summary>
    public partial class ChooseGroup : Window
    {
        public ChooseGroup()
        {
            InitializeComponent();
            lvGroups.ItemsSource = ClassHelper.AppData.Context.Group.ToList();

            btnAdd.IsEnabled = false;
        }
        private void Filter()
        {
            List<EF.Group> groups = new List<EF.Group>();
            groups = ClassHelper.AppData.Context.Group.Where(i => i.IsDeleted == false).ToList();
            groups = groups.Where(i => i.Title.ToLower().Contains(tbSearchGroup.Text.ToLower())).ToList();
            lvGroups.ItemsSource = groups;
        }
        private void tbSearchGroup_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lvGroups_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvGroups.SelectedItem is EF.Group)
            {
                GetGroup= lvGroups.SelectedItem as EF.Group;
                this.Close();
            }
        }
    }
}
