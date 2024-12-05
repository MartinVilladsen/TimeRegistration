using DAL.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;


namespace BLL.Models
{
    public class TidsregistreringBLL
    {
        public static TidsregistreringDTO GetTidsregistreringById(int id)
        {
            return TidsregistreringRepository.GetTidsregistreringById(id);
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
