using Adressverwaltungsprogramm.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace Adressverwaltungsprogramm
{
    public static class editFileEntrys
    {
                
        public static List <string> ReadData()
        {
            List <string> empty = new List<string>();
            List <string> FileData = new List <string>();
            string filePath = "Kontaktdaten.dat";

            if (!File.Exists(filePath))
            {
                return empty;
            }
            else
            {
                var fileLines = File.ReadAllLines(filePath);

                foreach (var line in fileLines)
                {                                        
                    if(line.Contains('*'))
                    {
                        var splitterCache = line.Split('*', 2, StringSplitOptions.None);

                        foreach (var item in splitterCache)
                        {
                            FileData.Add(item);
                        }
                    }
                    else
                    {
                        FileData.Add(line);
                    }

                    //var output = line.Remove(",", " ");
                }

                return FileData;
            }
        }
        public static List<string> ReadDataForWrite()
        {
            List<string> empty = new List<string>();
            List<string> FileData = new List<string>();
            string filePath = "Kontaktdaten.dat";

            if (!File.Exists(filePath))
            {
                return empty;
            }
            else
            {
                var fileLines = File.ReadAllLines(filePath);

                foreach (var line in fileLines)
                {
                    FileData.Add(line);
                }

                return FileData;
            }
        }

    }
}