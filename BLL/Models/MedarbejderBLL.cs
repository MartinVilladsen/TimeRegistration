using DAL.Repositories;
using DTO.Models;
using System.Collections.Generic;


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
