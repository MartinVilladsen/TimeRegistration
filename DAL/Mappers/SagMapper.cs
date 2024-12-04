using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public class SagMapper
    {
        public static SagDTO Map(SagDAL sagDAL)
        {
            if (sagDAL == null)
            {
                return null;
            }
            else
            {
                return new SagDTO
                {
                    Id = sagDAL.Id,
                    Sagsnr = sagDAL.Sagsnr,
                    Overskrift = sagDAL.Overskrift,
                    Beskrivelse = sagDAL.Beskrivelse,
                    Afdeling = AfdelingMapper.Map(sagDAL.Afdeling),
                };
            }
        }

        public static SagDAL Map(SagDTO sagDTO)
        {
            if (sagDTO == null)
            {
                return null;
            }
            else
            {
                return new SagDAL
                {
                    Id = sagDTO.Id,
                    Sagsnr = sagDTO.Sagsnr,
                    Overskrift = sagDTO.Overskrift,
                    Beskrivelse = sagDTO.Beskrivelse,
                    Afdeling = AfdelingMapper.Map(sagDTO.Afdeling),
                };
            }
        }

        public static List<SagDAL> MapSagerListe(List<SagDTO> list)
        {
            List<SagDAL> result = new List<SagDAL>();
            foreach (SagDTO sager in list)
            {
                result.Add(Map(sager));
            }
            return result;
        }

        internal static void Update(SagDTO sagDTO, SagDAL sagDAL)
        {
            if (sagDTO == null || sagDAL == null) return;
            sagDAL.Sagsnr = sagDTO.Sagsnr;
            sagDAL.Overskrift = sagDTO.Overskrift;
            sagDAL.Beskrivelse = sagDTO.Beskrivelse;
            sagDAL.Afdeling = AfdelingMapper.Map(sagDTO.Afdeling);
        }
    }
}
