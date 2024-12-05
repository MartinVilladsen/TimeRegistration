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
using BLL.Models;
using DTO.Models; 

namespace WPF
{

    public partial class MainWindow : Window
    {
        private List<MedarbejderDTO> Medarbejdere;
        private List<AfdelingDTO> Afdelinger;

        public MainWindow()
        {
            InitializeComponent();
            LoadAfdelinger();
            LoadMedarbejdere();
        }

        private void LoadAfdelinger()
        {
            Afdelinger = AfdelingBLL.GetAllAfdelinger();
            cmbAfdeling.ItemsSource = Afdelinger;
            cmbAfdeling.DisplayMemberPath = "Navn"; 
            cmbAfdeling.SelectedValuePath = "Id";   
            cmbSagAfdeling.ItemsSource = Afdelinger;
            cmbSagAfdeling.DisplayMemberPath = "Navn";
        }

        private void LoadMedarbejdere()
        {
            Medarbejdere = MedarbejderBLL.GetAllMedarbejder();
            dgMedarbejdere.ItemsSource = Medarbejdere;
        }

        private void AddMedarbejder_Click(object sender, RoutedEventArgs e)
        {
            string initial = txtInitial.Text;
            string cprNummer = txtCPR.Text;
            string navn = txtNavn.Text;
            AfdelingDTO selectedAfdeling = cmbAfdeling.SelectedItem as AfdelingDTO;

            if (selectedAfdeling == null || string.IsNullOrEmpty(initial) || string.IsNullOrEmpty(cprNummer) || string.IsNullOrEmpty(navn))
            {
                MessageBox.Show("Udfyld alle felter og vælg en afdeing.");
                return;
            }

            var nyMedarbejder = new MedarbejderDTO
            {
                Initial = initial,
                CprNummer = cprNummer,
                Navn = navn,
                Afdeling = selectedAfdeling
            };

            MedarbejderBLL.CreateMedarbejder(nyMedarbejder.Initial, nyMedarbejder.CprNummer, nyMedarbejder.Navn, nyMedarbejder.Afdeling);
            LoadMedarbejdere(); 
        }

        private void AddSag_Click(object sender, RoutedEventArgs e)
        {
            if (cmbSagAfdeling.SelectedItem is AfdelingDTO selectedAfdeling)
            {
                if (int.TryParse(txtSagsnr.Text, out int sagsnr))
                {
                    var nySag = new SagDTO
                    {
                        Sagsnr = sagsnr,
                        Overskrift = txtOverskrift.Text,
                        Beskrivelse = txtBeskrivelse.Text,
                        Afdeling = selectedAfdeling
                    };

                    SagBLL.CreateSag(nySag.Sagsnr, nySag.Overskrift, nySag.Beskrivelse, selectedAfdeling);
                    MessageBox.Show($"Sag '{nySag.Overskrift}' tilføjet.");
                }
                else
                {
                    MessageBox.Show("Ugyldig Sag");
                }
            }
        }

       

        private void EditSag_Click(object sender, RoutedEventArgs e)
        {
            var sager = SagBLL.GetAllSager();

            var editWindow = new EditSagWindow(sager);
            editWindow.Show();
        }


        private void DeleteMedarbejder_Click(object sender, RoutedEventArgs e)
        {
            if (dgMedarbejdere.SelectedItem is MedarbejderDTO selectedMedarbejder)
            {
                MessageBoxResult result = MessageBox.Show($"Er du sikker på at du vil slette {selectedMedarbejder.Navn}?", "Slettet", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    MedarbejderBLL.DeleteMedarbejder(selectedMedarbejder.Id);
                    LoadMedarbejdere(); 
                }
            }
        }

        private void ShowTidsregistrering_Click(object sender, RoutedEventArgs e)
        {
            if (dgMedarbejdere.SelectedItem is MedarbejderDTO selectedMedarbejder)
            {
                var tidsregistreringsWindow = new TidsregistreringsWindow(selectedMedarbejder); 
                tidsregistreringsWindow.Show();
            }
        }
    }
}
