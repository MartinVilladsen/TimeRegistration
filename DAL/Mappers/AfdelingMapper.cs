using DTO.Models;

namespace DAL.Mappers
{
    public class AfdelingMapper
    {
        public static AfdelingDTO Map(AfdelingDAL afdelingDAL)
        {
            if (afdelingDAL == null)
            {
                return null;
            }
            else
            {
                return new AfdelingDTO
                {
                    Id = afdelingDAL.Id,
                    Navn = afdelingDAL.Navn,
                    Nummer = afdelingDAL.Nummer,
                };
            }
        }

        public static AfdelingDAL Map(AfdelingDTO afdelingDTO)
        {
            if (afdelingDTO == null)
            {
                return null;
            }
            else
            {
                return new AfdelingDAL
                {
                    Id = afdelingDTO.Id,
                    Navn = afdelingDTO.Navn,
                    Nummer = afdelingDTO.Nummer
                };
            }
        }
    }
}
