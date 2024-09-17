using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2TaskPIS
{
    public class MeterDataElectricity: MeterData
    {
        public int numberWatts { get; }
        public int frequency { get; }
        public MeterDataElectricity(string input) : base(input)
        {
            input = input.Replace("'", "");
            string[] dates = input.Split(';');

            numberWatts = int.Parse(dates[3], CultureInfo.InvariantCulture);
            frequency = int.Parse(dates[4], CultureInfo.InvariantCulture);
        }
    }
}
