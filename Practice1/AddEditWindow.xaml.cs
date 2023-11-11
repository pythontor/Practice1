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

namespace Practice1
{
    /// <summary>
    /// Логика взаимодействия для AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        public AddEditWindow()
        {
            InitializeComponent();
        }

        public AddEditWindow(int v1, string v2)
        {
            V1 = v1;
            V2 = v2;
        }

        public int V1 { get; }
        public string V2 { get; }
    }
}
