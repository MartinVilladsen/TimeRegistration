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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Assuming you have a service or repository to manage employees
        private List<MedarbejderDTO> medarbejdere;
        private List<AfdelingDTO> afdelinger;

        public MainWindow()
        {
            InitializeComponent();
            LoadAfdelinger();
            LoadMedarbejdere();
        }

        private void LoadAfdelinger()
        {
            // Load departments from BLL or repository
            afdelinger = AfdelingBLL.GetAllAfdelinger();
            cmbAfdeling.ItemsSource = afdelinger;
            cmbAfdeling.DisplayMemberPath = "Navn"; // Display the name of the department
            cmbAfdeling.SelectedValuePath = "Id";   // Use the department ID as value
            cmbSagAfdeling.ItemsSource = afdelinger;
            cmbSagAfdeling.DisplayMemberPath = "Navn";
        }

        private void LoadMedarbejdere()
        {
            // Load employees from BLL or repository
            medarbejdere = MedarbejderBLL.GetAllMedarbejder();
            dgMedarbejdere.ItemsSource = medarbejdere;
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            // Get values from input fields
            string initial = txtInitial.Text;
            string cprNummer = txtCPR.Text;
            string navn = txtNavn.Text;
            AfdelingDTO selectedAfdeling = cmbAfdeling.SelectedItem as AfdelingDTO;

            if (selectedAfdeling == null || string.IsNullOrEmpty(initial) || string.IsNullOrEmpty(cprNummer) || string.IsNullOrEmpty(navn))
            {
                MessageBox.Show("Please fill in all fields and select an Afdeling.");
                return;
            }

            // Create a new employee
            var newEmployee = new MedarbejderDTO
            {
                Initial = initial,
                CprNummer = cprNummer,
                Navn = navn,
                Afdeling = selectedAfdeling
            };

            MedarbejderBLL.CreateMedarbejder(newEmployee.Initial, newEmployee.CprNummer, newEmployee.Navn, newEmployee.Afdeling);
            LoadMedarbejdere(); // Refresh the employee list
        }

        private void AddSag_Click(object sender, RoutedEventArgs e)
        {
            // Adding sag logic
            if (cmbSagAfdeling.SelectedItem is AfdelingDTO selectedAfdeling)
            {
                if (int.TryParse(txtSagsnr.Text, out int sagsnr))
                {
                    var newSag = new SagDTO
                    {
                        Sagsnr = sagsnr,
                        Overskrift = txtOverskrift.Text,
                        Beskrivelse = txtBeskrivelse.Text,
                        Afdeling = selectedAfdeling
                    };

                    SagBLL.CreateSag(newSag.Sagsnr, newSag.Overskrift, newSag.Beskrivelse, selectedAfdeling);
                    MessageBox.Show($"Sag '{newSag.Overskrift}' added successfully.");
                }
                else
                {
                    MessageBox.Show("Invalid Sagsnr. Please enter a valid number.");
                }
            }
        }

       

        private void EditSag_Click(object sender, RoutedEventArgs e)
        {
            // Load all sager
            var sager = SagBLL.GetAllSager();

            // Open the edit window with the list of sager
            var editWindow = new EditSagWindow(sager);
            editWindow.Show();
        }


        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (dgMedarbejdere.SelectedItem is MedarbejderDTO selectedMedarbejder)
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {selectedMedarbejder.Navn}?", "Delete Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    MedarbejderBLL.DeleteMedarbejder(selectedMedarbejder.Id); // Assuming you have a delete method in BLL
                    LoadMedarbejdere(); // Refresh the employee list
                }
            }
        }

        private void ShowTimeRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (dgMedarbejdere.SelectedItem is MedarbejderDTO selectedMedarbejder)
            {
                var timeRegistrationWindow = new TimeRegistrationWindow(selectedMedarbejder); // Open new window for time registration
                timeRegistrationWindow.Show();
            }
        }
    }
}
