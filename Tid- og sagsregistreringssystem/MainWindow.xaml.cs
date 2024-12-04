using System;
using System.Collections.Generic;
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
            Afdeling selectedAfdeling = (Afdeling)ComboBoxAlleAfdelinger.SelectedItem;
            if (afdelingBLL.GetAfdeling(selectedAfdeling.Nummer) != null)
            {
                // update Sager and Medarbejdere to show the ones for the selected Afdeling
                ListBoxAlleSager.Items.Clear();
                sagBLL.GetAlleSager(selectedAfdeling.Nummer).ForEach(sag => ListBoxAlleSager.Items.Add(sag));
            }

        }

        private void ButtonAddSag_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
