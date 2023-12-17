using Adressverwaltungsprogramm;
using Adressverwaltungsprogramm.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Adressverwaltungsprogramm.Controller
{
    public static class FileAccess
    {
        public static void WriteData(List<FormData> form, string path)
        {
            List<string> writeCache = new List<string>();
            
            if (!File.Exists(path)) 
            {
                foreach (var item in form)
                {
                    string cache = $"{item.Vorname}*{item.Nachname}";
                    writeCache.Add(cache);
                    cache = $"{item.Strasse}";
                    writeCache.Add(cache);
                    cache = $"{item.Postleitzahl}";
                    writeCache.Add(cache);
                    cache = $"{item.Ort}";
                    writeCache.Add(cache);
                    cache = $"{item.Telefonnummer}";
                    writeCache.Add(cache);
                    cache = $"{item.Mobilnummer}";
                    writeCache.Add(cache);
                    cache = $"{item.Email}";
                    writeCache.Add(cache);
                    cache = "------------------------------------------------";
                    writeCache.Add(cache);
                }

                File.WriteAllLines(path, writeCache);
            }
            else
            {
                var fileLines = File.ReadAllLines(path);

                foreach (var item in fileLines)
                {
                    writeCache.Add(item);                    
                }

                foreach (var item in form)
                {
                    string cache = $"{item.Vorname}*{item.Nachname}";
                    writeCache.Add(cache);
                    cache = $"{item.Strasse}";
                    writeCache.Add(cache);
                    cache = $"{item.Postleitzahl}";
                    writeCache.Add(cache);
                    cache = $"{item.Ort}";
                    writeCache.Add(cache);
                    cache = $"{item.Telefonnummer}";
                    writeCache.Add(cache);
                    cache = $"{item.Mobilnummer}";
                    writeCache.Add(cache);
                    cache = $"{item.Email}";
                    writeCache.Add(cache);
                    cache = "------------------------------------------------";
                    writeCache.Add(cache);
                }

                File.WriteAllLines(path, writeCache);                
            }
        }

        public static void OverwriteData(List<string> form, string path)
        {
            File.WriteAllLines(path, form);
        }

        public static List<string> ReadData()
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
                string cache;

                foreach (var line in fileLines)
                {
                    if (line.Contains('*'))
                    {
                        cache = line.Replace('*', ' ');
                        FileData.Add(cache);
                    }
                    else
                    {
                        //FileData.Add(line);                    

                        //var output = line.Remove(",", " ");
                    }                     
                }

                return FileData;
            }
        }
    }
}
