using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressverwaltungsprogramm.Models
{
    public class FormData
    {
        public string? Vorname         { get; set; }
        public string? Nachname        { get; set; }
        public string? Strasse         { get; set; }
        public string? Postleitzahl    { get; set; }
        public string? Ort             { get; set; }
        public string? Telefonnummer   { get; set; }
        public string? Mobilnummer     { get; set; }
        public string? Email           { get; set; }
    }
}
