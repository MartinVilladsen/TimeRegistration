using System;
using System.Collections.Generic;
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

            context.Afdelinger.Add(marketing);
            context.Afdelinger.Add(it);
            context.Afdelinger.Add(øko);

            var ob = new MedarbejderDAL("OB", "020299-3012", "Oliver Buus", it);
            var lah = new MedarbejderDAL("LAH", "250998-1235", "Lucas Andersen Holm", marketing);
            var pt = new MedarbejderDAL("PT", "111191-0420", "Patrick Tyme", marketing);
            var mk = new MedarbejderDAL("MK", "040495-6523", "Mikkel Knudsen", øko);
            var jd = new MedarbejderDAL("JD", "200588-1122", "Julie Damgaard", it);

            context.Medarbejdere.Add(ob);
            context.Medarbejdere.Add(lah);
            context.Medarbejdere.Add(pt);
            context.Medarbejdere.Add(mk);
            context.Medarbejdere.Add(jd);

            var sag1 = new SagDAL(12345, "Marketing Kampagne", "Beskrivelse af Marketing kampagne", marketing);
            var sag2 = new SagDAL(67890, "IT System Opgradering", "Beskrivelse af IT system opgradering", it);
            var sag3 = new SagDAL(11223, "Økonomi Rapport", "Beskrivelse af økonomirapport", øko);
            var sag4 = new SagDAL(44567, "Social Media Strategi", "Udvikling af strategi for sociale medier", marketing);
            var sag5 = new SagDAL(99876, "Ny Hardware Implementering", "Implementering af nye hardware systemer", it);

            context.Sager.Add(sag1);
            context.Sager.Add(sag2);
            context.Sager.Add(sag3);
            context.Sager.Add(sag4);
            context.Sager.Add(sag5);

            var tidsregistrering1 = new TidsregistreringDAL(
                DateTime.Now.AddHours(-5),
                DateTime.Now.AddHours(-3),
                ob,
                sag1
            );

            var tidsregistrering2 = new TidsregistreringDAL(
                DateTime.Now.AddHours(-8),
                DateTime.Now.AddHours(-6),
                lah,
                sag1
            );

            var tidsregistrering3 = new TidsregistreringDAL(
                DateTime.Now.AddDays(-1).AddHours(-4),
                DateTime.Now.AddDays(-1).AddHours(-2),
                pt,
                sag2
            );

            var tidsregistrering4 = new TidsregistreringDAL(
                DateTime.Now.AddDays(-2).AddHours(-6),
                DateTime.Now.AddDays(-2).AddHours(-3),
                mk,
                sag3
            );

            var tidsregistrering5 = new TidsregistreringDAL(
                DateTime.Now.AddDays(-1).AddHours(-7),
                DateTime.Now.AddDays(-1).AddHours(-4),
                jd,
                sag5
            );

            var tidsregistrering6 = new TidsregistreringDAL(
                DateTime.Now.AddHours(-10),
                DateTime.Now.AddHours(-8),
                ob,
                sag4
            );

            var tidsregistrering7 = new TidsregistreringDAL(
                DateTime.Now.AddDays(-3).AddHours(-2),
                DateTime.Now.AddDays(-3).AddHours(-1),
                lah,
                sag4
            );

            var tidsregistrering8 = new TidsregistreringDAL(
                DateTime.Now.AddDays(-5).AddHours(-9),
                DateTime.Now.AddDays(-5).AddHours(-6),
                mk,
                sag3
            );

            context.Tidsregistreringer.Add(tidsregistrering1);
            context.Tidsregistreringer.Add(tidsregistrering2);
            context.Tidsregistreringer.Add(tidsregistrering3);
            context.Tidsregistreringer.Add(tidsregistrering4);
            context.Tidsregistreringer.Add(tidsregistrering5);
            context.Tidsregistreringer.Add(tidsregistrering6);
            context.Tidsregistreringer.Add(tidsregistrering7);
            context.Tidsregistreringer.Add(tidsregistrering8);

            context.SaveChanges();
        }

        private void dummy()
        {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
    }
}
