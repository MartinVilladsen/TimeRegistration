using BLL.Models;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace WPF
{
    public partial class EditSagWindow : Window
    {
        private List<SagDTO> Sager;
        private SagDTO SelectedSag;

        public EditSagWindow(List<SagDTO> sager)
        {
            InitializeComponent();
            Sager = sager;

            cmbSelectSag.ItemsSource = Sager;
            cmbSelectSag.DisplayMemberPath = "Overskrift";
        }

        private void cmbSelectSag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSelectSag.SelectedItem is SagDTO selectedSag)
            {
                SelectedSag = selectedSag;
                txtEditOverskrift.Text = SelectedSag.Overskrift;
                txtEditBeskrivelse.Text = SelectedSag.Beskrivelse;
            }
        }

        private void UpdateSag_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedSag == null)
            {
                MessageBox.Show("Vælg en sag at redigere", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEditOverskrift.Text))
            {
                MessageBox.Show("Overskrift må ikke være tom.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEditBeskrivelse.Text))
            {
                MessageBox.Show("Beskrivelse må ikke være tom.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SelectedSag.Overskrift = txtEditOverskrift.Text;
            SelectedSag.Beskrivelse = txtEditBeskrivelse.Text;

            try
            {
                SagBLL.UpdateSag(SelectedSag);
                MessageBox.Show($"Sag '{SelectedSag.Overskrift}' opdateret.", "Yay", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der opstod en fejl under opdatering: {ex.Message}", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
