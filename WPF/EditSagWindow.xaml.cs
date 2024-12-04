using BLL.Models;
using DTO.Models;
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
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for EditSagWindow.xaml
    /// </summary>
    public partial class EditSagWindow : Window
    {
        private List<SagDTO> _sager;
        private SagDTO _selectedSag;

        public EditSagWindow(List<SagDTO> sager)
        {
            InitializeComponent();
            _sager = sager;

            // Load the list of sager into the ComboBox
            cmbSelectSag.ItemsSource = _sager;
            cmbSelectSag.DisplayMemberPath = "Overskrift";
        }

        private void cmbSelectSag_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // When a sag is selected, load its details into the textboxes
            if (cmbSelectSag.SelectedItem is SagDTO selectedSag)
            {
                _selectedSag = selectedSag;
                txtEditOverskrift.Text = _selectedSag.Overskrift;
                txtEditBeskrivelse.Text = _selectedSag.Beskrivelse;
            }
        }

        private void UpdateSag_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedSag != null)
            {
                // Update the sag details based on user input
                _selectedSag.Overskrift = txtEditOverskrift.Text;
                _selectedSag.Beskrivelse = txtEditBeskrivelse.Text;

                // Update in the database
                SagBLL.UpdateSag(_selectedSag);

                MessageBox.Show($"Sag '{_selectedSag.Overskrift}' updated successfully.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a Sag to edit.");
            }
        }
    }
}

