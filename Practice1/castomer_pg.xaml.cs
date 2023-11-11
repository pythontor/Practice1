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
using Practice1.PR5DataSetTableAdapters;

namespace Practice1
{
    /// <summary>
    /// Логика взаимодействия для castomer_pg.xaml
    /// </summary>
    public partial class castomer_pg : Window
    {
        private PR5DataSet dataSet;
        private OrdersTableAdapter ordersTableAdapter;
        private GameClassesTableAdapter gameClassesTableAdapter;
        private CoopModesTableAdapter coopModesTableAdapter;
        private EmployeesTableAdapter employeesTableAdapter;
        private EnginesTableAdapter enginesTableAdapter;
        private GenresTableAdapter genresTableAdapter;
        private GraphicsTableAdapter graphicsTableAdapter;
        private PlatformsTableAdapter platformsTableAdapter;
        private AgeRatingsTableAdapter ageRatingsTableAdapter;
        private SettingsTableAdapter settingsTableAdapter;

        public castomer_pg()
        {
            InitializeComponent();

            dataSet = new PR5DataSet();
            ordersTableAdapter = new OrdersTableAdapter();
            gameClassesTableAdapter = new GameClassesTableAdapter();
            coopModesTableAdapter = new CoopModesTableAdapter();
            employeesTableAdapter = new EmployeesTableAdapter();
            enginesTableAdapter = new EnginesTableAdapter();
            genresTableAdapter = new GenresTableAdapter();
            graphicsTableAdapter = new GraphicsTableAdapter();
            platformsTableAdapter = new PlatformsTableAdapter();
            ageRatingsTableAdapter = new AgeRatingsTableAdapter();
            settingsTableAdapter = new SettingsTableAdapter();

            // Загрузка данных таблицы Orders из базы данных
            ordersTableAdapter.Fill(dataSet.Orders);

            // Загрузка данных таблицы GameClasses из базы данных
            gameClassesTableAdapter.Fill(dataSet.GameClasses);

            // Загрузка данных таблицы CoopModes из базы данных
            coopModesTableAdapter.Fill(dataSet.CoopModes);

            // Загрузка данных таблицы Employees из базы данных
            employeesTableAdapter.Fill(dataSet.Employees);

            // Загрузка данных таблицы Engines из базы данных
            enginesTableAdapter.Fill(dataSet.Engines);

            // Загрузка данных таблицы Genres из базы данных
            genresTableAdapter.Fill(dataSet.Genres);

            // Загрузка данных таблицы Graphics из базы данных
            graphicsTableAdapter.Fill(dataSet.Graphics);

            // Загрузка данных таблицы Platforms из базы данных
            platformsTableAdapter.Fill(dataSet.Platforms);

            // Загрузка данных таблицы AgeRatings из базы данных
            ageRatingsTableAdapter.Fill(dataSet.AgeRatings);

            // Загрузка данных таблицы Settings из базы данных
            settingsTableAdapter.Fill(dataSet.Settings);

            // Установка таблицы Orders в качестве источника данных для DataGrid
            ordersDataGrid.ItemsSource = dataSet.Orders.DefaultView;

            // Заполнение выпадающего списка данными таблиц
            tableComboBox.ItemsSource = new string[] { "GameClasses", "CoopModes", "Employees", "Engines", "Genres", "Graphics", "Platforms", "AgeRatings", "Settings" };
        }

        private void tableComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedTableName = tableComboBox.SelectedItem as string;

            if (selectedTableName == "GameClasses")
            {
                ordersDataGrid.ItemsSource = dataSet.GameClasses.DefaultView;
            }
            else if (selectedTableName == "CoopModes")
            {
                ordersDataGrid.ItemsSource = dataSet.CoopModes.DefaultView;
            }
            else if (selectedTableName == "Employees")
            {
                ordersDataGrid.ItemsSource = dataSet.Employees.DefaultView;
            }
            else if (selectedTableName == "Engines")
            {
                ordersDataGrid.ItemsSource = dataSet.Engines.DefaultView;
            }
            else if (selectedTableName == "Genres")
            {
                ordersDataGrid.ItemsSource = dataSet.Genres.DefaultView;
            }
            else if (selectedTableName == "Graphics")
            {
                ordersDataGrid.ItemsSource = dataSet.Graphics.DefaultView;
            }
            else if (selectedTableName == "Platforms")
            {
                ordersDataGrid.ItemsSource = dataSet.Platforms.DefaultView;
            }
            else if (selectedTableName == "AgeRatings")
            {
                ordersDataGrid.ItemsSource = dataSet.AgeRatings.DefaultView;
            }
            else if (selectedTableName == "Settings")
            {
                ordersDataGrid.ItemsSource = dataSet.Settings.DefaultView;
            }
        }

        private void checkoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Расчет суммы заказа на основе значений из таблиц
            DataView ordersView = (DataView)ordersDataGrid.ItemsSource;
            DataTable ordersTable = ordersView.Table;

            foreach (DataRow row in ordersTable.Rows)
            {
                int modeId = Convert.ToInt32(row["mode_id"]);
                int classId = Convert.ToInt32(row["class_id"]);
                int empId = Convert.ToInt32(row["emp_id"]);
                int engId = Convert.ToInt32(row["eng_id"]);
                int genreId = Convert.ToInt32(row["genre_id"]);
                int graphId = Convert.ToInt32(row["graph_id"]);
                int portId = Convert.ToInt32(row["port_id"]);

                double modePrice = (double)coopModesTableAdapter.GetPriceById();
                double classPrice = (double)gameClassesTableAdapter.GetPriceById();
                double empPrice = (double)employeesTableAdapter.GetPriceById();
                double engPrice = (double)enginesTableAdapter.GetPriceById();
                double genrePrice = (double)genresTableAdapter.GetPriceById();
                double graphPrice = (double)graphicsTableAdapter.GetPriceById();
                double portPrice = (double)platformsTableAdapter.GetPriceById();

                double orderPrice = modePrice + classPrice + empPrice + engPrice + genrePrice + graphPrice + portPrice;
                row["order_price"] = orderPrice;
            }

            // Запись данных о заказе в чек
            // ...
        }
    }
}