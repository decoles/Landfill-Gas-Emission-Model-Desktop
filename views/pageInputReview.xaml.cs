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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LandGEMWPF.views
{
    /// <summary>
    /// Interaction logic for InputReview.xaml
    /// </summary>
    /// 


    public partial class InputReview : Page
    {

        public InputReview()
        {
            InitializeComponent();
            loadVariables(); //Load all variables on page load
            
            dataReview.ItemsSource = GlobalVariables.globalWasteAcceptanceRates;
        }

        private void loadVariables()
        {
            lblOpenYear.Content = GlobalVariables.globalOpenYear.ToString();
            lblCloseYear.Content = GlobalVariables.globalCloseYear.ToString();
            if(GlobalVariables.globalCalculatedClosureYear == true)
            {
                lblCalculateCloseYr.Content = "Yes";
            }
            else
            {
                lblCalculateCloseYr.Content = "No";
            }
            lblWasteCap.Content = GlobalVariables.globalWasteDesignCapacity.ToString();

            lblMethGenRate.Content = GlobalVariables.globalMethaneGen.ToString();
            lblPotentialMethGenRate.Content = GlobalVariables.globalMethaneContent.ToString();
            lblNMOC.Content = GlobalVariables.globalNMOC.ToString();
            lblMethContent.Content = GlobalVariables.globalMethaneContent.ToString();

            lblPollutant1.Content = GlobalVariables.globalPollutant1.ToString();
            lblPollutant2.Content = GlobalVariables.globalPollutant2.ToString();
            lblPollutant3.Content = GlobalVariables.globalPollutant3.ToString();
            lblPollutant4.Content = GlobalVariables.globalPollutant4.ToString();

            lblName.Content = GlobalVariables.globalCurrentDataSheet.ToString();

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
