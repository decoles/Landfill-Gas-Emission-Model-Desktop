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
using System.ComponentModel;
using System.Data;
using System.Collections.ObjectModel;
using LandGEMWPF.objects;
using LandGEMWPF.views;
using System.Text.RegularExpressions;

namespace lwrncLandgemWPF
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Item> items = new ObservableCollection<Item>(); //public list
        private static readonly Regex _regex = new Regex("[^0-9.]+"); //regex that matches disallowed text

        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow = this;  
            var file = @"content\pollutants.csv";
            var lines = File.ReadAllLines(file);
            foreach ( var line in lines)
            {
                var tokens = line.Split(',');
                //Update combo box to have all items from pollutants csv
                comboPollutant.Items.Add(tokens[0]);
                comboPollutant1.Items.Add(tokens[0]);
                comboPollutant2.Items.Add(tokens[0]);
                comboPollutant3.Items.Add(tokens[0]);

            }
            txtCloseYear.MaxLength = 4;
            txtOpenYear.MaxLength = 4; //only allow 4 digits for a given year
            dataInput.ItemsSource = items;
            radioNo.IsChecked = true;
            comboPotentialGen.SelectedIndex = 1;
            comboMethanGen.SelectedIndex = 1;
            comboNMOC.SelectedIndex = 0;
            comboMethaneContent.SelectedIndex = 0;

        }

        //Two following functions just make the radio button switch between to options as we can only select one
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(radioNo.IsChecked == true) //checks if radio button is pressed to cause a switch between the other radio button
            {
                radioNo.IsChecked = false;
            }
            //txtCloseYear.Opacity = 50;
            txtCloseYear.IsEnabled = false;

        }

        private void radioNo_Checked(object sender, RoutedEventArgs e)
        {
            if(radioYes.IsChecked == true)
            {
                radioYes.IsChecked = false;
            }
            txtCloseYear.IsEnabled = true;

        }


        //When both years are 4 digit and valid this will fill the datagrid with those years
        public void fillDataGrid()
        {
            int startingYear = 0;
            int closingYear = 0;

            startingYear = int.Parse(txtOpenYear.Text);
            closingYear = int.Parse(txtCloseYear.Text);
            if(closingYear <= startingYear)
            {
                MessageBox.Show("Closing Year must be greater than Starting Year");
            }
            else
            {
                int listLength = items.Count;
                if(listLength < 1) //If list is emtpy, to prevent list duplicaiotn
                {
                    for (int i = startingYear; i < closingYear + 1; i++)
                    {
                        //dataInput.Items.Add(new Item() { year = i});
                        items.Add(new Item() { year = i, inputUnits = 0, calculatedUnits = 0 });
                    }
                }

                year.Binding = new Binding("year");
                inputUnits.Binding = new Binding("inputUnits");
                calculatedUnits.Binding = new Binding("calculatedUnits"); 
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
                //dataInput.Items.Clear();
            }

        }

        private void hideUserSpecifiedSecTwo()
        {
            lblMethaneGen.Visibility = Visibility.Hidden;
            txtMethGen.Visibility = Visibility.Hidden;
            lblPotentialMethGen.Visibility = Visibility.Hidden;
            txtMethGenCap.Visibility = Visibility.Hidden;
            lblNMOC.Visibility = Visibility.Hidden;
            txtNMOC.Visibility = Visibility.Hidden;
            lblMethContent.Visibility = Visibility.Hidden;
            txtMethContent.Visibility = Visibility.Hidden;
        }
        /// <summary>
        ///     These next lines just switch to the user-specified choice under section 2
        /// </summary>
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
                    txtMethGen.Visibility = Visibility.Hidden;
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
                    txtMethGenCap.Visibility = Visibility.Hidden;
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
                    txtNMOC.Visibility = Visibility.Hidden;
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
                    txtMethContent.Visibility = Visibility.Hidden;
                }
            }
        }
        /// <summary>
        ///     END SECTION 2
        /// </summary>
     
        /////////////////////////MAKE STARTING SCREEN WHERE USER CAN PICK BETWEEN INSERTING FROM CSV OR INSERTING BY HAND

        private void dataInput_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
           if(e.EditAction == DataGridEditAction.Commit)
            {
                var column = e.Column as DataGridBoundColumn;
                if(column != null)
                {
                    int row = e.Row.GetIndex();
                    var el = e.EditingElement as TextBox; //selected column data
                    double shortOut = double.Parse(el.Text) * 1.10001; //retrieve column data
                    int roundedShortOut = Convert.ToInt32(shortOut);
                    //MessageBox.Show("row: " + row.ToString() + " " + el.Text.ToString());
                    items[row].calculatedUnits = roundedShortOut; //Get the units on a row to have the modified value (from 0)
                    
                    fillDataGrid();
                }
            }
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(GlobalVariables.globalCurrentDataSheet.ToString());
        }

        private void btnClearParameters_Click(object sender, RoutedEventArgs e)
        {
            txtCloseYear.Clear();
            txtOpenYear.Clear();
            items.Clear();
            radioNo.IsChecked = true;
            radioYes.IsChecked = false;
            comboWasteDesign.SelectedIndex = 0;
        }

        private void RestoreModelDefault(object sender, RoutedEventArgs e)
        {
            comboMethanGen.SelectedIndex = 1; //1 0 0
            comboPotentialGen.SelectedIndex = 1;
            comboNMOC.SelectedIndex = 0;
            comboMethaneContent.SelectedIndex = 0;
            hideUserSpecifiedSecTwo();
        }
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
               // if (comboMethanGen.SelectedValue.ToString() == "0" || comboPotentialGen.SelectedValue.ToString() == "0" || comboNMOC.SelectedValue.ToString() == "0" || comboMethaneContent.SelectedValue.ToString() == "0")
                //{
                //    if (txtMethGen.Text == "" || txtMethGenCap.Text == "" || txtNMOC.Text == "" || txtMethContent.Text == "")
                 //   {
                 //       MessageBox.Show("Verify All User Input Boxes Are Filled");
                 ///       return;
                 //   }
               // }
               // }

                if(comboMethanGen.SelectedValue.ToString() == "0" && !IsTextAllowed(txtMethGen.Text) && txtMethGen.Text != "")
                {
                    MessageBox.Show("Verify All User Input Boxes Are Filled With Numerical Data");
                    return;
                }
                if (comboPotentialGen.SelectedValue.ToString() == "0" && !IsTextAllowed(txtMethGenCap.Text) && txtMethGenCap.Text != "")
                {
                    MessageBox.Show("Verify All User Input Boxes Are Filled With Numerical Data");
                    return;
                }
                if (comboNMOC.SelectedValue.ToString() == "0" && !IsTextAllowed(txtNMOC.Text) && txtNMOC.Text != "")
                {
                    MessageBox.Show("Verify All User Input Boxes Are Filled With Numerical Data");
                    return;
                }
                if (comboMethaneContent.SelectedValue.ToString() == "0" && !IsTextAllowed(txtMethContent.Text) && txtMethContent.Text != "")
                {
                    MessageBox.Show("Verify All User Input Boxes Are Filled With Numerical Data");
                    return;
                }

                GlobalVariables.globalOpenYear = int.Parse(txtOpenYear.Text);
                GlobalVariables.globalCloseYear = int.Parse(txtCloseYear.Text);
                //GlobalVariables.globalCalculatedClosureYear = 
                GlobalVariables.globalWasteDesignCapacity = comboWasteDesign.Text;

                //User specified combo box values
                if(comboMethanGen.SelectedValue.ToString() == "0")

                    GlobalVariables.globalMethaneGen = txtMethGen.Text;
                else
                    GlobalVariables.globalMethaneGen = comboMethanGen.SelectedValue.ToString();

                if (comboPotentialGen.SelectedValue.ToString() == "0")
                    GlobalVariables.globalPotentialMethaneGenCap = txtMethGenCap.Text;
                else
                    GlobalVariables.globalPotentialMethaneGenCap = comboPotentialGen.SelectedValue.ToString();

                if (comboNMOC.SelectedValue.ToString() == "0")
                    GlobalVariables.globalNMOC = txtNMOC.Text;
                else
                    GlobalVariables.globalNMOC = comboNMOC.SelectedValue.ToString();

                if(comboMethaneContent.SelectedValue.ToString() == "0")
                    GlobalVariables.globalMethaneContent = txtMethContent.Text;
                else
                    GlobalVariables.globalMethaneContent = comboMethaneContent.SelectedValue.ToString();



                GlobalVariables.globalPollutant1 = comboPollutant1.Text;
                GlobalVariables.globalPollutant2 = comboPollutant2.Text;
                GlobalVariables.globalPollutant3 = comboPollutant3.Text;
                GlobalVariables.globalPollutant4 = comboPollutant.Text;

                GlobalVariables.globalWasteAcceptanceRates = items;

                InputReview inputReview = new InputReview(); //change page to review page
                Content = inputReview;
            }
            catch
            {
                MessageBox.Show("Fill all info");
            }

        }
    }
}

