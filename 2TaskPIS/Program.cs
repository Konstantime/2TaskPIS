using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2TaskPIS
{
    internal class Program
    {
        static void Main(string[] args)
        {  //  19   вариант 2
            MeterData meterReading = new MeterData("'water';2024.12.10;10.5");

            MemoryStream memoryStream = new MemoryStream();
            meterReading.print(memoryStream);
        }
    }
}