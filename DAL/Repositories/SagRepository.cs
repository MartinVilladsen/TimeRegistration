using DAL.Mappers;
using DTO.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace DAL.Repositories
{
    public class SagRepository
    {
        public static SagDTO GetSag(int id)
        {
            using (Context context = new Context())
            {

                return SagMapper.Map(context.Sager.FirstOrDefault(s => s.Id == id)) ?? null;
            }
        }


        public static List<SagDTO> GetSagerForAfdeling(int afdelingNummer)
        {
            using (var context = new Context())
            {
                var afdeling = context.Afdelinger.Include(a => a.Sager).FirstOrDefault(a => a.Nummer == afdelingNummer);

                return afdeling != null ? afdeling.Sager.Select(SagMapper.Map).ToList() : new List<SagDTO>();
            }
        }

        public static List<SagDTO> GetSager()
        {
            using (Context context = new Context()) 
            { 
                return context.Sager.ToList().Select(s => SagMapper.Map(s)).ToList();
            }
        }

        public static SagDTO AddSag(SagDTO sagDTO) 
        {
            using (Context context = new Context()) 
            {
                var eksisterendeAfdeling = context.Afdelinger.FirstOrDefault(a => a.Id == sagDTO.Afdeling.Id);
                var nySag = SagMapper.Map(sagDTO);
                nySag.Afdeling = eksisterendeAfdeling;

                context.Sager.Add(nySag);
                context.SaveChanges();
            }
            return sagDTO;
        }

        public static SagDTO Update(SagDTO sagDTO)
        {
            using (Context context = new Context())
            {
                SagDAL sag = context.Sager.Find(sagDTO.Id);
                if (sag != null)
                {
                    sag.Overskrift = sagDTO.Overskrift;
                    sag.Beskrivelse = sagDTO.Beskrivelse;

                    context.SaveChanges();
                }
                return sagDTO;
            }
        }
    }
}
