using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DTO.Models
{
    public class MedarbejderDTO
    {
        [Key]
        public int Id { get; set; }
        public string Initial { get; set; }
        public string CprNummer { get; set; }
        public string Navn { get; set; }
        public AfdelingDTO Afdeling { get; set; }
        public List<TidsregistreringDTO> Tidsregistrering { get; set; }

        public MedarbejderDTO(string initial, string cprnummer, string navn, AfdelingDTO afdeling)
        {
            Initial = initial;
            CprNummer = cprnummer;
            Navn = navn;
            Afdeling = afdeling;
            Tidsregistrering = new List<TidsregistreringDTO>();

        }
        public MedarbejderDTO() { }
    }
}
