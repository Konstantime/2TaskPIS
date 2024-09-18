using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2TaskPIS
{
    public class MeterDataWater: MeterData{
        public bool isСold { get; }
        public int quantity { get; }
        public MeterDataWater(string input) : base(input){
            input = input.Replace("'", "");
            string[] dates = input.Split(';');

            isСold = bool.Parse(dates[3]);
            quantity = int.Parse(dates[4], CultureInfo.InvariantCulture);
        }

    }
}
