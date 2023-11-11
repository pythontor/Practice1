using Practice1.Model;
using Practice1.PR5DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Practice1
{   
    /// <summary>
    /// Логика взаимодействия для admin_pg.xaml
    /// </summary>
    public partial class admin_pg : Window
    {
        private PR5DataSetTableAdapters.PlatformsTableAdapter platformsTableAdapter;
        private PR5DataSetTableAdapters.AgeRatingsTableAdapter ageTableAdapter;
        private PR5DataSetTableAdapters.SettingsTableAdapter settingTableAdapter;

        public admin_pg()
        {
            InitializeComponent();

            platformsTableAdapter = new PR5DataSetTableAdapters.PlatformsTableAdapter();

            // Загрузка данных из таблицы в DataGrid
            datagrid.ItemsSource = platformsTableAdapter.GetData();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            platformsTableAdapter.InsertQuery(nametbx.Text, Convert.ToInt32(pricetbx.Text));
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object id = (datagrid.SelectedItem as DataRowView).Row[0];
            platformsTableAdapter.UpdateQuery(nametbx.Text, Convert.ToInt32(pricetbx.Text), Convert.ToInt32(id));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (datagrid.SelectedItem as DataRowView).Row[0];
            platformsTableAdapter.DeleteQuery(Convert.ToInt32(id));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            List<platform> forImport = new LabaConverter.DeserializeObject<List<platform>>();
            foreach (var item in forImport) 
            {
                platformsTableAdapter.InsertQuery(item.PlatfromName, item.port_price);
            }

            datagrid.ItemsSource = null;
            datagrid.ItemsSource = platformsTableAdapter.GetData();
        }
    }
}