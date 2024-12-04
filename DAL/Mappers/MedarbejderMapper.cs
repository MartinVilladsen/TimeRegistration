using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public class MedarbejderMapper
    {
        public static MedarbejderDTO Map(MedarbejderDAL medarbejderDAL)
        {
            if (medarbejderDAL == null)
            {
                return null;
            }
            else
            {
                return new MedarbejderDTO
                {
                    Id = medarbejderDAL.Id,
                    Initial = medarbejderDAL.Initial,
                    CprNummer = medarbejderDAL.CprNummer,
                    Navn = medarbejderDAL.Navn,
                    Afdeling = AfdelingMapper.Map(medarbejderDAL.Afdeling),
                    Tidsregistrering = TidsregistreringMapper.Map(medarbejderDAL.Tidsregistrering),
                };
            }
        }

        public static MedarbejderDAL Map(MedarbejderDTO medarbejderDTO)
        {
            if (medarbejderDTO == null)
            {
                return null;
            }
            else
            {
                return new MedarbejderDAL
                {
                    Id = medarbejderDTO.Id,
                    Initial = medarbejderDTO.Initial,
                    CprNummer = medarbejderDTO.CprNummer,
                    Navn = medarbejderDTO.Navn,
                    Afdeling = AfdelingMapper.Map(medarbejderDTO.Afdeling),
                };
            }
        }
    }
}
