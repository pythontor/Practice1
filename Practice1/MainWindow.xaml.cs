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
using Practice1.PR5DataSetTableAdapters;
using System.Data.SqlClient;

namespace Practice1
{

    public partial class MainWindow : Window
    {
        accountsTableAdapter adapter = new accountsTableAdapter();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var allAccounts = adapter.GetData().Rows;

            for (int i = 0; i < allAccounts.Count; i++) 
            {
                if (allAccounts[i][1].ToString() == txtUsername.Text &&
                    allAccounts[i][2].ToString() == txtPassword.Password)
                {
                    int role_id = (int)allAccounts[i][3];

                    switch (role_id) 
                    { 
                        case 1:
                            admin_pg role = new admin_pg();
                            role.Show();
                            break;

                        case 2:
                            castomer_pg second = new castomer_pg();
                            second.Show();
                            break;

                        case 3:
                            seller_pg third = new seller_pg();
                            third.Show();
                            break;

                        default:
                            MessageBox.Show("Такого пользователя не существет!");
                            break;
                    
                    }
                }
            
            }
        }
    }
}