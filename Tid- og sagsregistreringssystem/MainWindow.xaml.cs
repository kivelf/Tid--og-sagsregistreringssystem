using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL;
using DTO;

namespace Tid__og_sagsregistreringssystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AfdelingBLL afdelingBLL = new AfdelingBLL();
        SagBLL sagBLL = new SagBLL();
        MedarbejderBLL medarbejderBLL = new MedarbejderBLL();
        TidsregistreringBLL tidsregistreringBLL = new TidsregistreringBLL();
        public MainWindow()
        {
            InitializeComponent();

            UpdateListAfdelinger();
            UpdateListAlleSager();
            UpdateListAlleMedarbejdere();
        }

        private void UpdateListAfdelinger() 
        { 
            ComboBoxAlleAfdelinger.Items.Clear();
            afdelingBLL.GetAlleAfdelinger().ForEach(afdeling => ComboBoxAlleAfdelinger.Items.Add(afdeling));
        }

        private void UpdateListAlleSager()
        {
            ListBoxAlleSager.Items.Clear();
            sagBLL.GetAlleSager().ForEach(sag => ListBoxAlleSager.Items.Add(sag));
        }

        private void UpdateListAlleMedarbejdere() 
        { 
            ListBoxAlleMedarbejdere.Items.Clear();
            medarbejderBLL.GetAlleMedarbejdere().ForEach(medarbejder => ListBoxAlleMedarbejdere.Items.Add(medarbejder));
        }

        private void ComboBoxAlleAfdelinger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedAfdeling = ComboBoxAlleAfdelinger.SelectedItem.ToString();
            if (afdelingBLL.GetAfdeling(Int32.Parse(selectedAfdeling.Substring(0,1))) != null)
            {
                // update Sager and Medarbejdere to show the ones for the selected Afdeling
                ListBoxAlleSager.Items.Clear();
                sagBLL.GetAlleSager(Int32.Parse(selectedAfdeling.Substring(0, 1))).ForEach(sag => ListBoxAlleSager.Items.Add(sag));
                ListBoxAlleMedarbejdere.Items.Clear();
                medarbejderBLL.GetAlleMedarbejdere(Int32.Parse(selectedAfdeling.Substring(0, 1))).ForEach(medarbejder => ListBoxAlleMedarbejdere.Items.Add(medarbejder));
            }
        }

        private void ButtonAddSag_Click(object sender, RoutedEventArgs e)
        {
            // validering af data i felter
            if (ComboBoxAlleAfdelinger.SelectedItem == null) 
            {
                MessageBox.Show("Vælg en afdeling!", "Data mangler", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TextBoxSagOverskrift.Text.Length == 0 || TextBoxSagBeskrivelse.Text.Length == 0) 
            {
                MessageBox.Show("En sag skal have en overskrift og beskrivelse!", "Data mangler", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int afdID = Int32.Parse(ComboBoxAlleAfdelinger.SelectedItem.ToString().Substring(0,1));

            // opret ny sag
            sagBLL.AddSag(new Sag(TextBoxSagOverskrift.Text, TextBoxSagBeskrivelse.Text, afdID));
            // clear data input fields
            TextBoxSagOverskrift.Text = "";
            TextBoxSagBeskrivelse.Text = "";
            // refresh view
            ListBoxAlleSager.Items.Clear();
            sagBLL.GetAlleSager(afdID).ForEach(sag => ListBoxAlleSager.Items.Add(sag));
        }

        private void ListBoxAlleSager_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxAlleSager.SelectedItem != null)
            {
                int sagID = GetSagsNr();
                Sag sag = sagBLL.GetSag(sagID);
                TextBoxSagOverskrift.Text = sag.Overskrift;
                TextBoxSagBeskrivelse.Text = sag.Beskrivelse;
            }
            else 
            {
                TextBoxSagOverskrift.Text = "";
                TextBoxSagBeskrivelse.Text = "";
            }
        }

        private void ButtonEditSag_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxAlleSager.SelectedItem != null) 
            {
                if (ComboBoxAlleAfdelinger.SelectedItem == null)
                {
                    MessageBox.Show("Vælg en afdeling!", "Data mangler", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (TextBoxSagOverskrift.Text.Length == 0 || TextBoxSagBeskrivelse.Text.Length == 0)
                {
                    MessageBox.Show("En sag skal have en overskrift og beskrivelse!", "Data mangler", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // opdater sag
                int sagID = GetSagsNr();
                int afdID = Int32.Parse(ComboBoxAlleAfdelinger.SelectedItem.ToString().Substring(0, 1));
                sagBLL.EditSag(new Sag(sagID, TextBoxSagOverskrift.Text, TextBoxSagBeskrivelse.Text, afdID));
                MessageBox.Show($"Sag nr.{sagID} opdateret!", "Opdatering gennemført", MessageBoxButton.OK, MessageBoxImage.Information);
                // refresh view
                ListBoxAlleSager.Items.Clear();
                sagBLL.GetAlleSager(afdID).ForEach(sag => ListBoxAlleSager.Items.Add(sag));
            }
        }

        private int GetSagsNr() 
        {
            char[] stringChars = ListBoxAlleSager.SelectedItem.ToString().ToCharArray();
            string sagsNr = "";
            foreach (char c in stringChars)
            {
                if (char.IsDigit(c))
                {
                    sagsNr += c;
                }
            }
            return Int32.Parse(sagsNr);
        }

        private void ButtonAddMedarbejder_Click(object sender, RoutedEventArgs e)
        {
            // validering af data i felter
            if (ComboBoxAlleAfdelinger.SelectedItem == null)
            {
                MessageBox.Show("Vælg en afdeling!", "Data mangler", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TextBoxMedarbejderNavn.Text.Length == 0 || TextBoxMedarbejderInitialer.Text.Length == 0 || TextBoxMedarbejderCprNr.Text.Length == 0)
            {
                MessageBox.Show("En medarbejder skal have et navn, initialer og cpr-nummer!", "Data mangler", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int afdID = Int32.Parse(ComboBoxAlleAfdelinger.SelectedItem.ToString().Substring(0, 1));

            // opret ny medarbejder
            medarbejderBLL.AddMedarbejder(new Medarbejder(TextBoxMedarbejderNavn.Text, TextBoxMedarbejderInitialer.Text, TextBoxMedarbejderCprNr.Text, afdID));
            // clear data input fields
            TextBoxMedarbejderNavn.Text = "";
            TextBoxMedarbejderInitialer.Text = "";
            TextBoxMedarbejderCprNr.Text = "";
            // refresh view
            ListBoxAlleMedarbejdere.Items.Clear();
            medarbejderBLL.GetAlleMedarbejdere(afdID).ForEach(medarbejder => ListBoxAlleMedarbejdere.Items.Add(medarbejder));
        }

        private void ButtonEditMedarbejder_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxAlleMedarbejdere.SelectedItem != null)
            {
                if (ComboBoxAlleAfdelinger.SelectedItem == null)
                {
                    MessageBox.Show("Vælg en afdeling!", "Data mangler", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (TextBoxMedarbejderNavn.Text.Length == 0 || TextBoxMedarbejderInitialer.Text.Length == 0 || TextBoxMedarbejderCprNr.Text.Length == 0)
                {
                    MessageBox.Show("En medarbejder skal have et navn, initialer og cpr-nummer!", "Data mangler", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // opdater en eksisterende medarbejder
                int medarbejderNr = GetMedarbejderNr();
                int afdID = Int32.Parse(ComboBoxAlleAfdelinger.SelectedItem.ToString().Substring(0, 1));
                medarbejderBLL.EditMedarbejder(new Medarbejder(medarbejderNr, TextBoxMedarbejderNavn.Text, TextBoxMedarbejderInitialer.Text,
                    TextBoxMedarbejderCprNr.Text, afdID));
                MessageBox.Show($"Medarbejder {TextBoxMedarbejderNavn.Text} (nr.{medarbejderNr}) opdateret!", "Opdatering gennemført", 
                    MessageBoxButton.OK, MessageBoxImage.Information);

                // refresh view
                ListBoxAlleMedarbejdere.Items.Clear();
                medarbejderBLL.GetAlleMedarbejdere(afdID).ForEach(medarbejder => ListBoxAlleMedarbejdere.Items.Add(medarbejder));
            }
        }

        private int GetMedarbejderNr()
        {
            char[] stringChars = ListBoxAlleMedarbejdere.SelectedItem.ToString().ToCharArray();
            string medarbejderNr = "";
            foreach (char c in stringChars)
            {
                if (char.IsDigit(c))
                {
                    medarbejderNr += c;
                }
            }
            return Int32.Parse(medarbejderNr);
        }

        private void ListBoxAlleMedarbejdere_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxAlleMedarbejdere.SelectedItem != null)
            {
                int medarbejderID = GetMedarbejderNr();
                Medarbejder medarbejder = medarbejderBLL.GetMedarbejder(medarbejderID);
                TextBoxMedarbejderNavn.Text = medarbejder.Navn;
                TextBoxMedarbejderInitialer.Text = medarbejder.Initialer;
                TextBoxMedarbejderCprNr.Text = medarbejder.CprNr;
            }
            else
            {
                TextBoxMedarbejderNavn.Text = "";
                TextBoxMedarbejderInitialer.Text = "";
                TextBoxMedarbejderCprNr.Text = "";
            }
        }
    }
}
