using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandGEMWPF.objects
{
    public static class GlobalVariables
    {
        //Used for handling currently logged file name
        public static string globalCurrentDataSheet = "";
        public static int globalOpenYear = 0;
        public static int globalCloseYear = 0;
        public static bool globalCalculatedClosureYear = false;
        //section 2
        public static string globalWasteDesignCapacity = "";
        public static string globalMethaneGen = "";
        public static string globalPotentialMethaneGenCap = "";
        public static string globalNMOC = "";
        public static string globalMethaneContent = "";
        //section 3
        public static string globalPollutant1 = "";
        public static string globalPollutant2 = "";
        public static string globalPollutant3 = "";
        public static string globalPollutant4 = "";
        public static ObservableCollection<Item> globalWasteAcceptanceRates = new ObservableCollection<Item>(); //public list
    }
}
