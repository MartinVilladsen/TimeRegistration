using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public class TidsregistreringMapper
    {
        public static TidsregistreringDTO Map(TidsregistreringDAL tidsregistreringDAL)
        {
            if (tidsregistreringDAL == null)
            {
                return null;
            }
            else
            {
                return new TidsregistreringDTO
                {
                    Id = tidsregistreringDAL.Id,
                    StartTid = tidsregistreringDAL.StartTid,
                    SlutTid = tidsregistreringDAL.SlutTid,
                    Medarbejder = MedarbejderMapper.Map(tidsregistreringDAL.Medarbejder),
                    Sag = tidsregistreringDAL.Sag != null ? SagMapper.Map(tidsregistreringDAL.Sag) : null
                };
            }
        }


        public static TidsregistreringDAL Map(TidsregistreringDTO tidsregistreringDTO)
        {
            if (tidsregistreringDTO == null)
            {
                return null;
            }
            else
            {
                return new TidsregistreringDAL
                {
                    Id = tidsregistreringDTO.Id,
                    StartTid = tidsregistreringDTO.StartTid,
                    SlutTid = tidsregistreringDTO.SlutTid,
                    Medarbejder = MedarbejderMapper.Map(tidsregistreringDTO.Medarbejder),
                    Sag = tidsregistreringDTO.Sag != null ? SagMapper.Map(tidsregistreringDTO.Sag) : null
                };
            }
        }

        public static List<TidsregistreringDTO> Map(List<TidsregistreringDAL> list)
        {
            if (list == null)
            {
                return new List<TidsregistreringDTO>();
            }

            List<TidsregistreringDTO> result = new List<TidsregistreringDTO>();
            foreach (TidsregistreringDAL tidsregistrering in list)
            {
                if (tidsregistrering != null)
                {
                    result.Add(Map(tidsregistrering));
                }
            }
            return result;
        }




        public static void Update(TidsregistreringDTO tidsregistreringDTO, TidsregistreringDAL tidsregistreringDAL)
        {
            if (tidsregistreringDTO == null || tidsregistreringDAL == null) return;
            tidsregistreringDAL.StartTid = tidsregistreringDTO.StartTid;
            tidsregistreringDAL.SlutTid = tidsregistreringDTO.SlutTid;
            tidsregistreringDAL.Medarbejder = MedarbejderMapper.Map(tidsregistreringDTO.Medarbejder);
            tidsregistreringDAL.Sag = SagMapper.Map(tidsregistreringDTO.Sag);
        }

        
    }
}
