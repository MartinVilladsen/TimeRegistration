using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class TidsregistreringDTO
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }
        public SagDTO Sag { get; set; }
        public MedarbejderDTO Medarbejder { get; set; }

        public TidsregistreringDTO(DateTime starttid, DateTime sluttid, MedarbejderDTO medarbejder, SagDTO sag = null)
        {
            StartTid = starttid;
            SlutTid = sluttid;
            Sag = sag;
            Medarbejder = medarbejder;
        }
        public TidsregistreringDTO() { }
    }
}
