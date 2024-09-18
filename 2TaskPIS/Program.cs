using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum TypeMeterData
{
    MeterData,
    MeterDataElectricity,
    MeterDataWater,
    invalidType
}

namespace _2TaskPIS {
    internal class Program {
        static void Main(string[] args) {  //  19   вариант 2

            MeterData meterReading = new MeterData("'water';2024.12.10;10.5");
            MeterDataWater meterDataWater = new MeterDataWater("'water';2024.12.10;10.5;true;50");
            MeterDataElectricity meterDataElectricity = new MeterDataElectricity("'water';2024.12.10;10.5;500;50");

            CreateListMeterDatas();

            Console.ReadLine();
        }

        static private void CreateListMeterDatas() {
            string[] codeObject = GetObjectCodesFromTextFile("C:/Users/Kostya/OneDrive/Desktop/MeterData.txt");
            List<MeterData> meterDatas = new List<MeterData>();

            TypeMeterData typeMeterData;
            for (int i = 0; i < codeObject.Length; i++)
            {
                typeMeterData = DetermineTypeOfObject(codeObject[i]);

                if(GetMeterData(typeMeterData, codeObject[i]) != null) {
                    meterDatas.Add(GetMeterData(typeMeterData, codeObject[i]));
                }
                
                Console.WriteLine(meterDatas[i].typeResourse);
            }
        }

        static private MeterData GetMeterData(TypeMeterData typeMeterData, string code) {
            switch (typeMeterData) {
                case TypeMeterData.MeterData:
                    return new MeterData(code);
                case TypeMeterData.MeterDataWater:
                    return new MeterDataWater(code);
                case TypeMeterData.MeterDataElectricity:
                    return new MeterDataElectricity(code);
                default:
                    return null;
            }
        }

        static private string[] GetObjectCodesFromTextFile(string filePath) {
            string fileContent = GetTextFromFile(filePath);

            string[] result = fileContent.Split('\r');

            return result;
        }

        static private string GetTextFromFile(string filePath) {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return null;
            }
        }

        static private TypeMeterData DetermineTypeOfObject( string codeObject) {
            string typeResourse = GetTypeFromString(codeObject);
            switch (typeResourse) {
                case "something":
                    return TypeMeterData.MeterData;
                case "water":
                    return TypeMeterData.MeterDataWater;
                case "electro":
                    return TypeMeterData.MeterDataElectricity;
                default:
                    return TypeMeterData.invalidType;
            }
        }

        static private string GetTypeFromString( string codeObject ) {

            int indexFirstForging = codeObject.IndexOf("'");
            int indexLastForging = codeObject.IndexOf("'", indexFirstForging + 1);

            return codeObject.Substring(indexFirstForging + 1, indexLastForging - indexFirstForging - 1);

        }
    }
}