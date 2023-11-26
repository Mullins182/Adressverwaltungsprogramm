using Adressverwaltungsprogramm.Controller;
using Adressverwaltungsprogramm.Models;
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

namespace Adressverwaltungsprogramm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void saveData_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "Kontaktdaten.dat";
            FormData contactData = new FormData();
            List<FormData> writeData = new List<FormData>();

            contactData.Vorname = Vorname.Text;
            contactData.Nachname = Nachname.Text;
            contactData.Strasse = Straße.Text;
            contactData.Postleitzahl = PLZ.Text;
            contactData.Ort = Ort.Text;
            contactData.Telefonnummer = Telefonnummer.Text;
            contactData.Mobilnummer = Handynummer.Text;
            contactData.Email = Emailadresse.Text;

            writeData.Add(contactData);

            FileAccess.WriteData(writeData, filePath);
        }

        private void saveData_MouseEnter(object sender, MouseEventArgs e)
        {

        }
    }
}