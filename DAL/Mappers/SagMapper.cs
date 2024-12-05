using DTO.Models;

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
    }
}
