using BLL.Models;
using DTO.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPF
{
    public partial class TidsregistreringsWindow : Window
    {
        private MedarbejderDTO Medarbejder;

        public TidsregistreringsWindow(MedarbejderDTO medarbejder)
        {
            InitializeComponent();
            Medarbejder = medarbejder;

            cmbPeriode.Visibility = Visibility.Visible;
            rbUger.Visibility = Visibility.Visible;

            LoadMåneder();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (cmbPeriode == null || rbUger == null)
                return;

            if (rbMåned.IsChecked == true)
            {
                cmbPeriode.Visibility = Visibility.Visible;
                rbUger.Visibility = Visibility.Visible;
            }
            else if (rbTotal.IsChecked == true)
            {
                cmbPeriode.Visibility = Visibility.Collapsed;
                rbUger.Visibility = Visibility.Collapsed;
                LoadTidsregistreringerForTotal();
            }
        }

        private void LoadMåneder()
        {
            var tidsregistreringer = TidsregistreringBLL.GetTidsregistreringerForMedarbejder(Medarbejder.Id);

            var måned = tidsregistreringer
                .Select(tr => new DateTime(tr.StartTid.Year, tr.StartTid.Month, 1))
                .Distinct()
                .OrderBy(d => d)
                .ToList();

            cmbPeriode.Items.Clear();
            cmbPeriode.Items.Add("Vælg et måned"); 
            foreach (var month in måned)
            {
                cmbPeriode.Items.Add(month.ToString("MMMM yyyy")); 
            }
            cmbPeriode.SelectedIndex = 0; 
        }

        private void LoadUger(DateTime selectedUge)
        {
            rbUger.Items.Clear();
            rbUger.Items.Add("Vælg en uge"); 

            var firstDayOfMåned = new DateTime(selectedUge.Year, selectedUge.Month, 1);
            var ugeInMåned = Enumerable.Range(0, (DateTime.DaysInMonth(selectedUge.Year, selectedUge.Month) + 6) / 7)
                .Select(uge => firstDayOfMåned.AddDays(uge * 7))
                .TakeWhile(ugeStart => ugeStart.Month == selectedUge.Month);

            foreach (var uge in ugeInMåned)
            {
                var ugeNumber = GetUge(uge);
                rbUger.Items.Add($"Uge {ugeNumber}");
            }
            rbUger.SelectedIndex = 0; 
        }

        private void cmbPeriode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbPeriode.SelectedIndex > 0 && DateTime.TryParseExact(cmbPeriode.SelectedItem.ToString(), "MMMM yyyy", null, System.Globalization.DateTimeStyles.None, out var selectedMåned))
            {
                LoadUger(selectedMåned);
                LoadTidsregistreringer(selectedMåned, null);
            }
        }

        private void cmbUger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (rbUger.SelectedIndex > 0 && cmbPeriode.SelectedIndex > 0 && DateTime.TryParseExact(cmbPeriode.SelectedItem.ToString(), "MMMM yyyy", null, System.Globalization.DateTimeStyles.None, out var selectedMåned))
            {
                var selectedUge = rbUger.SelectedItem.ToString();
                var uge = int.Parse(selectedUge.Split(' ')[1]);
                var startOfUge = GetStartenOfUge(selectedMåned, uge);
                LoadTidsregistreringer(selectedMåned, startOfUge);
            }
        }

        private void LoadTidsregistreringer(DateTime selectedMåned, DateTime? ugeStart)
        {
            var tidsregistreringer = TidsregistreringBLL.GetTidsregistreringerForMedarbejder(Medarbejder.Id);

            var førsteDagIMåned = new DateTime(selectedMåned.Year, selectedMåned.Month, 1);
            var sidsteDagIMåned = new DateTime(selectedMåned.Year, selectedMåned.Month, DateTime.DaysInMonth(selectedMåned.Year, selectedMåned.Month));

            var startDate = ugeStart ?? førsteDagIMåned;
            var slutDate = ugeStart.HasValue ? ugeStart.Value.AddDays(6) : sidsteDagIMåned;

            var filteredRegistreringer = tidsregistreringer
                .Where(tr => tr.StartTid >= startDate && tr.StartTid <= slutDate)
                .ToList();

            dgTidsregistreringer.ItemsSource = filteredRegistreringer.Select(tr => new
            {
                tr.StartTid,
                tr.SlutTid,
                SagOverskrift = tr.Sag?.Overskrift ?? "Ingen sag",
                TidBrugt = $"{(int)(tr.SlutTid - tr.StartTid).TotalHours:D2}:{(tr.SlutTid - tr.StartTid).Minutes:D2}:{(tr.SlutTid - tr.StartTid).Seconds:D2}"
            }).ToList();

            txtRegistreretTimer.Text = $"Total registrerede timer: {filteredRegistreringer.Sum(tr => (tr.SlutTid - tr.StartTid).TotalHours):F2}";
        }

        private void LoadTidsregistreringerForTotal()
        {
            var tidsregistreringer = TidsregistreringBLL.GetTidsregistreringerForMedarbejder(Medarbejder.Id);

            var tidbrugt = tidsregistreringer.Select(tr => new
            {
                tr.StartTid,
                tr.SlutTid,
                SagOverskrift = tr.Sag?.Overskrift ?? "Ingen sag",
                TidBrugt = $"{(int)(tr.SlutTid - tr.StartTid).TotalHours:D2}:{(tr.SlutTid - tr.StartTid).Minutes:D2}:{(tr.SlutTid - tr.StartTid).Seconds:D2}"
            }).ToList();

            dgTidsregistreringer.ItemsSource = tidbrugt;

            txtRegistreretTimer.Text = $"Total registrerede timer: {tidsregistreringer.Sum(tr => (tr.SlutTid - tr.StartTid).TotalHours):F2}";
        }

        private int GetUge(DateTime date)
        {
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        private DateTime GetStartenOfUge(DateTime SelectedMåned, int uge)
        {
            var førsteDagIMåned = new DateTime(SelectedMåned.Year, SelectedMåned.Month, 1);
            return CultureInfo.CurrentCulture.Calendar.AddWeeks(førsteDagIMåned, uge - GetUge(førsteDagIMåned));
        }
    }
}
