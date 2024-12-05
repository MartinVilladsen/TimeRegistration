using DAL.Repositories;
using DTO.Models;
using System.Collections.Generic;


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
