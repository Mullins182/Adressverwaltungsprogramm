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
    /// 
        
    public partial class MainWindow : Window
    {
        string filePath = "Kontaktdaten.dat";
        bool editContactData = false;
        public MainWindow()
        {
            InitializeComponent();

            ShowVersion.Content = "Version 1.0.3";

            listBoxOutput();
        }

        private void saveData_Click(object sender, RoutedEventArgs e)
        {
            FormData contactData        = new FormData();
            List<FormData> writeData    = new List<FormData>();

            if(Vorname.Text == "" || Nachname.Text == "" || Straße.Text == "" || Ort.Text == "")
            {
                MessageBox.Show("Gib bitte einen Vor und Nachnamen, Straße & Ort ein um einen neuen Datensatz anlegen zu können !", "Fehlerhafte Daten !!!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (editContactData)
                {
                    List<string>? ContactData = new List<string>();

                    ContactData = editFileEntrys.ReadDataForWrite();

                    ContactData[FileData.SelectedIndex * 8]     = Vorname.Text + "*" + Nachname.Text;
                    ContactData[FileData.SelectedIndex * 8 + 1] = Straße.Text;
                    ContactData[FileData.SelectedIndex * 8 + 2] = PLZ.Text;
                    ContactData[FileData.SelectedIndex * 8 + 3] = Ort.Text;
                    ContactData[FileData.SelectedIndex * 8 + 4] = Telefonnummer.Text;
                    ContactData[FileData.SelectedIndex * 8 + 5] = Handynummer.Text;
                    ContactData[FileData.SelectedIndex * 8 + 6] = Emailadresse.Text;
                    //ContactData[FileData.SelectedIndex * 9 + 7] = "------------------------------------------------";

                    Vorname.Text        = "";
                    Nachname.Text       = "";
                    Straße.Text         = "";
                    PLZ.Text            = "";
                    Ort.Text            = "";
                    Telefonnummer.Text  = "";
                    Handynummer.Text    = "";
                    Emailadresse.Text   = "";

                    Controller.FileAccess.OverwriteData(ContactData, filePath);

                    editContactData = false;

                    listBoxOutput();

                    FormLabel.Content = "Neuen Kontakt anlegen";
                }
                else
                {
                    writeData.Clear();

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
        }

        // Löschen einer Zeile aus der ListBox, welche ausgewählt wurde !!!
        private void DeleteFileLine_Click(object sender, RoutedEventArgs e)
        {
            List<string> readFile = new List<string>();

            if (!File.Exists(filePath))
            {
                MessageBox.Show("KEINE DATEN ZUM LÖSCHEN VORHANDEN !!!", "FEHLER", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var readArray = File.ReadAllLines(filePath);

                foreach (var item in readArray)
                {
                    readFile.Add(item);
                }

                if (FileData.SelectedItem != null)
                {
                    if (MessageBox.Show($"Willst Du den Eintrag: {FileData.SelectedItem} wirklich löschen ???", "Bitte bestätige", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        int del = FileData.SelectedIndex;
                        FileData.Items.RemoveAt(del);
                        readFile.RemoveAt(del);
                        File.WriteAllLines(filePath, readFile);
                    }
                }
            }
        }

        private void listBoxOutput()
        {
            List<string> Entrys = new List<string>();
            Entrys = Controller.FileAccess.ReadData();

            if (!File.Exists(filePath))
            {

            }
            else
            {
                FileData.Items.Clear();

                foreach (var item in Entrys)
                {
                    FileData.Items.Add($"{item}");
                }
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FileData_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("KEINE DATEN ZUM EDITIEREN VORHANDEN !!!", "FEHLER", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (FileData.SelectedItem == null)
            {

            }
            else
            {
                FormLabel.Content = "Kontakt bearbeiten";

                List<string>? ContactData = new List<string>();

                ContactData = editFileEntrys.ReadData();

                Vorname.Text        = ContactData[FileData.SelectedIndex * 9];
                Nachname.Text       = ContactData[FileData.SelectedIndex * 9 + 1];
                Straße.Text         = ContactData[FileData.SelectedIndex * 9 + 2];
                PLZ.Text            = ContactData[FileData.SelectedIndex * 9 + 3];
                Ort.Text            = ContactData[FileData.SelectedIndex * 9 + 4];
                Telefonnummer.Text  = ContactData[FileData.SelectedIndex * 9 + 5];
                Handynummer.Text    = ContactData[FileData.SelectedIndex * 9 + 6];
                Emailadresse.Text   = ContactData[FileData.SelectedIndex * 9 + 7];

                editContactData = true;
            }
        }
    }
}