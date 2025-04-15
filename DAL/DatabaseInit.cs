using System;
using System.Data.Entity;

namespace DAL
{
    public class DatabaseInit : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context)
        {
            var marketing = new AfdelingDAL("Marketing", 2);
            var it = new AfdelingDAL("IT", 1);
            var øko = new AfdelingDAL("Økonomi", 3);
            var hr = new AfdelingDAL("HR", 4);

            context.Afdelinger.Add(marketing);
            context.Afdelinger.Add(it);
            context.Afdelinger.Add(øko);
            context.Afdelinger.Add(hr);

            var ob = new MedarbejderDAL("OB", "020299-3012", "Oscar Bom", it);
            var lah = new MedarbejderDAL("LAH", "250998-1235", "Louise Auh Hansen", marketing);
            var pt = new MedarbejderDAL("PT", "111191-0420", "Poul Time", marketing);
            var mk = new MedarbejderDAL("MK", "040495-6523", "Mikkel Knudsen", øko);
            var jd = new MedarbejderDAL("JD", "200588-1122", "Julie Damgaard", it);

            context.Medarbejdere.Add(ob);
            context.Medarbejdere.Add(lah);
            context.Medarbejdere.Add(pt);
            context.Medarbejdere.Add(mk);
            context.Medarbejdere.Add(jd);


            var sag1 = new SagDAL(12345, "Marketing Kampagne", "Firma Marketing kampagne", marketing);
            var sag2 = new SagDAL(67890, "IT System Optimering", "Optimering af nuværende IT system", it);
            var sag3 = new SagDAL(11223, "Økonomi Rapport", "Skal laves økonomirapport", øko);
            var sag4 = new SagDAL(44567, "Social Media", "Strategi for Social Media", marketing);
            var sag5 = new SagDAL(99876, "Ny Implementering af system", "Implementering af nye systemer", it);
            var sag6 = new SagDAL(55432, "Budgetanalyse", "Analyse af kommende budget", øko);

            context.Sager.Add(sag1);
            context.Sager.Add(sag2);
            context.Sager.Add(sag3);
            context.Sager.Add(sag4);
            context.Sager.Add(sag5);
            context.Sager.Add(sag6);


            var tidsregistrering1 = new TidsregistreringDAL(
                DateTime.Now.AddDays(-10).AddHours(-5),
                DateTime.Now.AddDays(-10).AddHours(-3),
                ob,
                sag2
            );

            var tidsregistrering2 = new TidsregistreringDAL(
                DateTime.Now.AddDays(-8).AddHours(-6),
                DateTime.Now.AddDays(-8).AddHours(-4),
                lah,
                sag1
            );

            var tidsregistrering3 = new TidsregistreringDAL(
                DateTime.Now.AddMonths(-1).AddDays(-2).AddHours(-4),
                DateTime.Now.AddMonths(-1).AddDays(-2).AddHours(-2),
                pt,
                sag4
            );

            var tidsregistrering4 = new TidsregistreringDAL(
                DateTime.Now.AddDays(-15).AddHours(-6),
                DateTime.Now.AddDays(-15).AddHours(-3),
                mk,
                sag6
            );

            var tidsregistrering5 = new TidsregistreringDAL(
                DateTime.Now.AddMonths(-2).AddDays(-7).AddHours(-7),
                DateTime.Now.AddMonths(-2).AddDays(-7).AddHours(-5),
                jd,
                sag5
            );

            var tidsregistrering6 = new TidsregistreringDAL(
                DateTime.Now.AddDays(-3).AddHours(-10),
                DateTime.Now.AddDays(-3).AddHours(-8),
                ob,
                sag2
            );

            var tidsregistrering7 = new TidsregistreringDAL(
                DateTime.Now.AddMonths(-1).AddHours(-6),
                DateTime.Now.AddMonths(-1).AddHours(-4),
                lah,
                sag4
            );

            var tidsregistrering8 = new TidsregistreringDAL(
                DateTime.Now.AddMonths(-3).AddDays(-5).AddHours(-9),
                DateTime.Now.AddMonths(-3).AddDays(-5).AddHours(-6),
                mk,
                sag3
            );

            var tidsregistrering9 = new TidsregistreringDAL(
                DateTime.Now.AddMonths(-1).AddDays(-1).AddHours(-5),
                DateTime.Now.AddMonths(-1).AddDays(-1).AddHours(-2),
                pt,
                sag1
            );

            context.Tidsregistreringer.Add(tidsregistrering1);
            context.Tidsregistreringer.Add(tidsregistrering2);
            context.Tidsregistreringer.Add(tidsregistrering3);
            context.Tidsregistreringer.Add(tidsregistrering4);
            context.Tidsregistreringer.Add(tidsregistrering5);
            context.Tidsregistreringer.Add(tidsregistrering6);
            context.Tidsregistreringer.Add(tidsregistrering7);
            context.Tidsregistreringer.Add(tidsregistrering8);
            context.Tidsregistreringer.Add(tidsregistrering9);


            context.SaveChanges();
        }

        private void dummy()
        {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
    }
}
