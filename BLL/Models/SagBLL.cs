using DAL.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class SagBLL
    {

        public static SagDTO GetSagById(int id)
        {
            return SagRepository.GetSag(id);
        }

        public static List<SagDTO> GetAllSager()
        {
            return SagRepository.GetSager();
        }

        public static SagDTO CreateSag(int sagsnr, string overskrift, string beskrivelse, AfdelingDTO afdeling)
        {
            return SagRepository.AddSag(new SagDTO(sagsnr, overskrift, beskrivelse, afdeling));
        }

        public static SagDTO UpdateSag(SagDTO sagDTO)
        {
            return SagRepository.Update(sagDTO);
        }

        public static List<SagDTO> GetSagerForAfdeling(int afdelingNummer)
        {
            return SagRepository.GetSagerForAfdeling(afdelingNummer); 
        }
    }
}
