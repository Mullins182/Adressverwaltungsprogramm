using Adressverwaltungsprogramm.Controller;
using Adressverwaltungsprogramm.Models;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Adressverwaltungsprogramm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string filePath = "Kontaktdaten.dat";
        public MainWindow()
        {
            InitializeComponent();

            ShowVersion.Content = "Version 1.0.0";

            listBoxOutput();
        }

        private void saveData_Click(object sender, RoutedEventArgs e)
        {
            FormData contactData        = new FormData();
            List<FormData> writeData    = new List<FormData>();

            if(Vorname.Text == "" || Nachname.Text == "" || Straße.Text == "" || Ort.Text == "")
            {
                MessageBox.Show("Gib bitte einen Vor und Nachnamen, Straße & Ort ein, um einen neuen Datensatz anlegen zu können !", "Kann Datei nicht schreiben !!!", MessageBoxButton.OK);
            }
            else
            {
                contactData.Vorname         = Vorname.Text;
                contactData.Nachname        = Nachname.Text;
                contactData.Strasse         = Straße.Text;
                contactData.Postleitzahl    = PLZ.Text;
                contactData.Ort             = Ort.Text;
                contactData.Telefonnummer   = Telefonnummer.Text;
                contactData.Mobilnummer     = Handynummer.Text;
                contactData.Email           = Emailadresse.Text;

                writeData.Add(contactData);

                Vorname.Text                = "";
                Nachname.Text               = "";
                Straße.Text                 = "";
                PLZ.Text                    = "";
                Ort.Text                    = "";
                Telefonnummer.Text          = "";
                Handynummer.Text            = "";
                Emailadresse.Text           = "";

                Controller.FileAccess.WriteData(writeData, filePath);

                listBoxOutput();
            }
        }

        // Löschen einer Zeile aus der ListBox, welche ausgewählt wurde !!!
        private void DeleteFileLine_Click(object sender, RoutedEventArgs e)
        {
            List<string> readFile = new List<string>();

            if(!File.Exists(filePath))
            {
                throw new Exception("KEINE DATEN ZUM LÖSCHEN VORHANDEN");
            }

            var readArray = File.ReadAllLines(filePath);

            foreach (var item in readArray)
            {
            readFile.Add(item);                
            }
            
            if (FileData.SelectedItem != null)
            {
                if (MessageBox.Show("Willst Du den Datei-Eintrag wirklich löschen ???", "Bitte bestätige", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    int del = FileData.SelectedIndex;
                    FileData.Items.RemoveAt(del);
                    readFile.RemoveAt(del);
                    File.WriteAllLines(filePath, readFile);
                }
            }
        }

        private void saveData_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void listBoxOutput()
        {
            
            if(!File.Exists(filePath))
            {

            }
            else
            {
                FileData.Items.Clear();

                var fileLines   = File.ReadAllLines(filePath);

                foreach (var line in fileLines)
                {
                    var output  = line.Replace(",", " ");
                    FileData.Items.Add($"{output}");
                }
            }
        }
    }
}