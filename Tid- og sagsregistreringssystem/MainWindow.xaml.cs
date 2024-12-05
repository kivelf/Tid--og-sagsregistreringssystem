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
        public MainWindow()
        {
            InitializeComponent();

            UpdateListAfdelinger();
            UpdateListAlleSager();
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

        private void ComboBoxAlleAfdelinger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedAfdeling = ComboBoxAlleAfdelinger.SelectedItem.ToString();
            if (afdelingBLL.GetAfdeling(Int32.Parse(selectedAfdeling.Substring(0,1))) != null)
            {
                // update Sager and Medarbejdere to show the ones for the selected Afdeling
                ListBoxAlleSager.Items.Clear();
                sagBLL.GetAlleSager(Int32.Parse(selectedAfdeling.Substring(0, 1))).ForEach(sag => ListBoxAlleSager.Items.Add(sag));
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
        }

    }
}
