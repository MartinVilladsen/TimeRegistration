using DAL.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MedarbejderBLL
    {

        public static MedarbejderDTO GetMedarbejderById(int id)
        {
            return MedarbejderRepository.GetMedarbejderById(id);
        }

        public static void DeleteMedarbejder(int id)
        {
            MedarbejderRepository.DeleteMedarbejder(id);
        }
        public static List<MedarbejderDTO> GetAllMedarbejder()
        {
            return MedarbejderRepository.GetMedarbejdere();
        }

        public static MedarbejderDTO CreateMedarbejder(string initial, string cprnummer, string navn, AfdelingDTO afdeling)
        {
            return MedarbejderRepository.AddMedarbejder(new MedarbejderDTO(initial, cprnummer, navn, afdeling));
        }

        public static List<MedarbejderDTO> GetMedarbejdereForAfdeling(int afdelingId)
        {
            return MedarbejderRepository.GetMedarbejdereForAfdeling(afdelingId);
        }
    }
}
