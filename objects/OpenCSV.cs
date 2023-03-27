using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class GetCSV
{
    public List<PollutantsObj> pollutants { get; set; } = getData();
    public static List<PollutantsObj> getData()
    {
        var file = @"C:\Users\David\Documents\Projects\lwrncProject\lwrncLandgemWPF\content\pollutants.csv";
        var lines = File.ReadAllLines(file);
        var result = new List<PollutantsObj>();

        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i].Split(',');
            var GetPollutants = new PollutantsObj()
            {
                Compound = line[0],
                Concentration = line[1],
                MolecularWeight = line[2]
            };
            result.Add(GetPollutants);
        }
        return result;
    }
}

public class PollutantsObj
{
    public string Compound { get; set; }
    public string Concentration { get; set; }
    public string MolecularWeight { get; set; }
}


