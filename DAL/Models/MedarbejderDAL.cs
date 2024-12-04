using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MedarbejderDAL
    {
        [Key]
        public int Id { get; set; }
        public string Initial { get; set; }
        public string CprNummer { get; set; }
        public string Navn { get; set; }
        public virtual AfdelingDAL Afdeling { get; set; } 

        public List<TidsregistreringDAL> Tidsregistrering { get; set; }

        public MedarbejderDAL(string initial, string cprnummer, string navn, AfdelingDAL afdeling)
        {
            Initial = initial;
            CprNummer = cprnummer;
            Navn = navn;
            Afdeling = afdeling;
            Tidsregistrering = new List<TidsregistreringDAL>();
        }

        public MedarbejderDAL() { }
    }

}

