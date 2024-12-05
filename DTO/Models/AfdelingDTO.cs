using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO.Models
{
    public class AfdelingDTO
    {
        [Key]
        public int Id { get; set; }
        public string Navn { get; set; }
        public int Nummer { get; set; }
        public List<MedarbejderDTO> Medarbejdere { get; set; }
        public List<SagDTO> Sager { get; set; }

        public AfdelingDTO(string navn, int nummer)
        {
            Navn = navn;
            Nummer = nummer;
        }
        public AfdelingDTO()
        {

        }
    }
}
