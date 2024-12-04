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
    /// Interaction logic for TimeRegistrationWindow.xaml
    /// </summary>
    public partial class TimeRegistrationWindow : Window
    {
        private MedarbejderDTO _medarbejder;

        public TimeRegistrationWindow(MedarbejderDTO medarbejder)
        {
            InitializeComponent();
            _medarbejder = medarbejder;
            LoadTidsregistreringer();
        }

        private void LoadTidsregistreringer()
        {
            // Fetch time registrations for the given employee
            var tidsregistreringer = TidsregistreringBLL.GetTidsregistreringerForMedarbejder(_medarbejder.Id);

            // Calculate the duration for each time registration and prepare it for display
            var tidsregistreringWithDuration = tidsregistreringer.Select(tr => new
            {
                tr.StartTid,
                tr.SlutTid,
                tr.Medarbejder,
                SagOverskrift = tr.Sag?.Overskrift ?? "Ingen sag",
                Duration = $"{(int)(tr.SlutTid - tr.StartTid).TotalHours:D2}:{(tr.SlutTid - tr.StartTid).Minutes:D2}:{(tr.SlutTid - tr.StartTid).Seconds:D2}"
            }).ToList();

            // Bind the list to the DataGrid
            dgTidsregistreringer.ItemsSource = tidsregistreringWithDuration;

            // Calculate total registered hours for this employee
            var totalRegisteredHours = tidsregistreringer.Sum(tr => (tr.SlutTid - tr.StartTid).TotalHours);

            // Calculate remaining hours (starting from 37)
            double hoursLeft = 37 - totalRegisteredHours;

            // Update the TextBlock to show the remaining hours
            txtHoursLeft.Text = $"{hoursLeft:F2} timer tilbage at registrere";
        }
    }
}
