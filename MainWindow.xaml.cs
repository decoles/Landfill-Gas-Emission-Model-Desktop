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
        if(radioNo.IsChecked == true) //checks if radio button is pressed to cause a switch between the other radio button
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
            dataInput.Items.Clear();
            int startingYear = 0;
            int closingYear = 0;
            startingYear = int.Parse(txtOpenYear.Text);
            closingYear = int.Parse(txtCloseYear.Text);
            int differnce = closingYear - startingYear;
            for (int i = startingYear; i < differnce + closingYear; i++)
            {

                dataInput.Items.Add(i.ToString());
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
            if(countChar != 4 || countCharClose != 4)
            {
                dataInput.Items.Clear();
            }

        }

        private void comboMethanGen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboMethanGen.SelectedItem != null)
            {
                ComboBoxItem comboBoxItem = (ComboBoxItem)comboMethanGen.SelectedItem;
                string selectedValue = comboBoxItem.Content.ToString();
                if(selectedValue == "User Specified")
                {
                    lblMethaneGen.Visibility = Visibility.Visible;
                    txtMethGen.Visibility = Visibility.Visible;
                }
                else
                {
                    lblMethaneGen.Visibility = Visibility.Hidden;
                    txtMethGen.Visibility = Visibility.Visible;
                }
            }
        }

        private void comboPotentialGen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboPotentialGen.SelectedItem != null)
            {
                ComboBoxItem comboBoxItem = (ComboBoxItem)comboPotentialGen.SelectedItem;
                string selectedValue = comboBoxItem.Content.ToString();
                if (selectedValue == "User Specified")
                {
                    lblPotentialMethGen.Visibility = Visibility.Visible;
                    txtMethGenCap.Visibility = Visibility.Visible;
                }
                else
                {
                    lblPotentialMethGen.Visibility = Visibility.Hidden;
                    txtMethGenCap.Visibility = Visibility.Visible;
                }
            }

        }

        private void comboNMOC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboNMOC.SelectedItem != null)
            {
                ComboBoxItem comboBoxItem = (ComboBoxItem)comboNMOC.SelectedItem;
                string selectedValue = comboBoxItem.Content.ToString();
                if (selectedValue == "User Specified")
                {
                    lblNMOC.Visibility = Visibility.Visible;
                    txtNMOC.Visibility = Visibility.Visible;
                }
                else
                {
                    lblNMOC.Visibility = Visibility.Hidden;
                    txtNMOC.Visibility = Visibility.Visible;
                }
            }
        }

        private void comboMethaneContent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboMethaneContent.SelectedItem != null)
            {
                ComboBoxItem comboBoxItem = (ComboBoxItem)comboMethaneContent.SelectedItem;
                string selectedValue = comboBoxItem.Content.ToString();
                if (selectedValue == "User Specified")
                {
                    lblMethContent.Visibility = Visibility.Visible;
                    txtMethContent.Visibility = Visibility.Visible;
                }
                else
                {
                    lblMethContent.Visibility = Visibility.Hidden;
                    txtMethContent.Visibility = Visibility.Visible;
                }
            }
        }
    }
}

