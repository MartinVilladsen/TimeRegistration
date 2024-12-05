using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO.Models
{
    public class SagDTO
    {
        [Key]
        public int Id { get; set; }
        public int Sagsnr { get; set; }
        public string Overskrift { get; set; }
        public string Beskrivelse { get; set; }
        public AfdelingDTO Afdeling { get; set; }
        public List<TidsregistreringDTO> Tidsregistrering { get; set; }


        public SagDTO(int sagsnr, string overskrift, string beskrivelse, AfdelingDTO afdeling)
        {
            Sagsnr = sagsnr;
            Overskrift = overskrift;
            Beskrivelse = beskrivelse;
            Afdeling = afdeling;
            Tidsregistrering = new List<TidsregistreringDTO>();
        }
        public SagDTO() { }
    }
}
