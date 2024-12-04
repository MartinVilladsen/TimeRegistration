
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO.Models;
using DAL.Repositories;
using DAL.Mappers;

namespace BLL
{
    public class AfdelingBLL
    {

        public static AfdelingDTO GetAfdeling(int id)
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
