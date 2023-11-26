using Adressverwaltungsprogramm.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                    string cache = $"{item.Vorname},{item.Nachname},{item.Strasse},{item.Postleitzahl},{item.Ort},{item.Telefonnummer},{item.Mobilnummer},{item.Email}";
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
                    string cache = $"{item.Vorname},{item.Nachname},{item.Strasse},{item.Postleitzahl},{item.Ort},{item.Telefonnummer},{item.Mobilnummer},{item.Email}";
                    writeCache.Add(cache);
                }
                
                File.WriteAllLines(path, writeCache);                
            }
        }
    }
}
