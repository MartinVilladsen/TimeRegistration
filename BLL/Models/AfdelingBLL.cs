
using System.Collections.Generic;
using DTO.Models;
using DAL.Repositories;

namespace BLL
{
    public class AfdelingBLL
    {

        public static AfdelingDTO GetAfdelingById(int id)
        {
            return AfdelingRepository.GetAfdelingById(id);
        }

        public static List<AfdelingDTO> GetAllAfdelinger()
        {
            return AfdelingRepository.GetAfdelinger();
        }

        public static AfdelingDTO CreateAfdeling(string name, int number)
        {
            return AfdelingRepository.AddAfdeling(new AfdelingDTO(name, number));
        }
    }
}
