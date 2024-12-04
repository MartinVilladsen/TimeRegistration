using DAL.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class TidsregistreringBLL
    {
        public static TidsregistreringDTO GetTidsregistreringById(int id)
        {
            return TidsregistreringRepository.GetTidsregistreringById(id);
        }

        public static List<TidsregistreringDTO> GetAllTidsregistreringer()
        {
            return TidsregistreringRepository.GetTidsregistreringer();
        }

        public static TidsregistreringDTO CreateTidsregistrering(DateTime starttid, DateTime sluttid, MedarbejderDTO medarbejder, SagDTO sag = null)
        {
            var tidsregistreringDTO = new TidsregistreringDTO(starttid, sluttid, medarbejder, sag);
            return TidsregistreringRepository.AddTidsregistrering(tidsregistreringDTO);
        }



        public static List<TidsregistreringDTO> GetTidsregistreringerForMedarbejder(int medarbejderId)
        {
            return TidsregistreringRepository.GetTidsregistreringerForMedarbejder(medarbejderId);
        }



    }
}
