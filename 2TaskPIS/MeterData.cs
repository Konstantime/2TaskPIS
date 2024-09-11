using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _2TaskPIS
{
    public class MeterData
    {
        public string typeResourse { get; }
        public DateTime date { get; }
        public double value { get; }

        public MeterData(string input)  //    "'water';2024.12.10;10.5"
        {
            input = input.Replace("'", "");
            string[] dates = input.Split(';');

            typeResourse = dates[0];
            date = DateTime.ParseExact(dates[1], "yyyy.MM.dd", CultureInfo.InvariantCulture);
            value = double.Parse(dates[2], CultureInfo.InvariantCulture);
        }

        public void print(Stream stream)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(typeResourse);
            stream.Write(bytes, 0, bytes.Length);

            bytes = Encoding.UTF8.GetBytes(Convert.ToString(date));
            stream.Write(bytes, 0, bytes.Length);

            bytes = Encoding.UTF8.GetBytes(Convert.ToString(value));
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}