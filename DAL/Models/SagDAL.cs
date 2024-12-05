using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DAL
{
    public class SagDAL
    {
        [Key]
        public int Id { get; set; }
        public int Sagsnr { get; set; }
        public string Overskrift { get; set; }
        public string Beskrivelse { get; set; }
        public AfdelingDAL Afdeling { get; set; }
        public List<TidsregistreringDAL> Tidsregistrering { get; set; }

        public SagDAL(int sagsnr, string overskrift, string beskrivelse, AfdelingDAL afdeling)
        {
            Sagsnr = sagsnr;
            Overskrift = overskrift;
            Beskrivelse = beskrivelse;
            Afdeling = afdeling;
            Tidsregistrering = new List<TidsregistreringDAL>();

        }
        public SagDAL() { }
    }
}
