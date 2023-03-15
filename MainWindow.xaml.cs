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
using System.Globalization;
using System.IO;

namespace lwrncLandgemWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var file = @"content\pollutants.csv";
            var lines = File.ReadAllLines(file);
            foreach ( var line in lines)
            {
                var tokens = line.Split(',');
                comboPollutant.Items.Add(tokens[0]);
                comboPollutant1.Items.Add(tokens[0]);
                comboPollutant2.Items.Add(tokens[0]);
                comboPollutant3.Items.Add(tokens[0]);

            }
            txtCloseYear.MaxLength = 4;
            txtOpenYear.MaxLength = 4;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
        if(radioNo.IsChecked == true)
            {
                radioNo.IsChecked = false;
            }
        }

        private void radioNo_Checked(object sender, RoutedEventArgs e)
        {
            if(radioYes.IsChecked == true)
            {
                radioYes.IsChecked = false;
            }
        }

        public void fillDataGrid()
        {
            int startingYear = 0;
            int closingYear = 0;
            startingYear = int.Parse(txtOpenYear.Text);
            closingYear = int.Parse(txtCloseYear.Text);
            int differnce = closingYear - startingYear;
            for (int i = 0; i < differnce; i++)
            {

            }
        }

        private void txtCloseYear_TextChanged(object sender, TextChangedEventArgs e)
        {
            int parsedValue;
            if(!int.TryParse(txtCloseYear.Text, out parsedValue)) //Get rid of any non numerical data
            {
                txtCloseYear.Clear();
            }
            int countChar = txtOpenYear.Text.ToString().Length;
            int countCharClose = txtCloseYear.Text.ToString().Length;
            if (countChar == 4 && countCharClose == 4) //If both values are full of numerical data then create years on data grid.
            {
                fillDataGrid();
            }
        }

        private void txtOpenYear_TextChanged(object sender, TextChangedEventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(txtOpenYear.Text, out parsedValue)) //Get rid of any non numerical data
            {
                txtOpenYear.Clear();
            }
            int countChar = txtOpenYear.Text.ToString().Length;
            int countCharClose = txtCloseYear.Text.ToString().Length;
            if(countChar == 4 && countCharClose == 4) //If both values are full of numerical data then create years on data grid.
            {
                fillDataGrid();
            }

        }
    }
}

