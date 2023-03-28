using LandGEMWPF.objects;
using lwrncLandgemWPF;
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

namespace LandGEMWPF
{
    /// <summary>
    /// Interaction logic for startup.xaml
    /// </summary>
    public partial class startup : Window
    {
        public startup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(txtName.Text != "")
            {
                Global.globalCurrentDataSheet = txtName.Text;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
        }
    }
}
