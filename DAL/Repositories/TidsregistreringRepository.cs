using DAL.Mappers;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DAL.Repositories
{
    public class TidsregistreringRepository
    {
        public static TidsregistreringDTO GetTidsregistreringById(int id)
        {
            using (Context context = new Context())
            {

                return TidsregistreringMapper.Map(context.Tidsregistreringer.Find(id));
            }
        }

        public static List<TidsregistreringDTO> GetTidsregistreringer()
        {
            using (Context context = new Context())
            {
                return context.Tidsregistreringer.ToList().Select(t => TidsregistreringMapper.Map(t)).ToList();
            }
        }

        public static TidsregistreringDTO AddTidsregistrering(TidsregistreringDTO dto)
        {
            using (Context context = new Context())
            {
                var tidsregistrering = TidsregistreringMapper.Map(dto);

                if (tidsregistrering.Medarbejder != null)
                {
                    tidsregistrering.Medarbejder = context.Medarbejdere.Find(tidsregistrering.Medarbejder.Id);
                }

                if (tidsregistrering.Sag != null)
                {
                    tidsregistrering.Sag = context.Sager.Find(tidsregistrering.Sag.Id);
                }

                context.Tidsregistreringer.Add(tidsregistrering);
                context.SaveChanges();

                return dto;
            }
        }




        public static List<TidsregistreringDTO> GetTidsregistreringerForMedarbejder(int medarbejderId)
        {
            using (Context context = new Context())
            {
                var tidsregistreringer = context.Tidsregistreringer.Include(tr => tr.Sag).Where(tr => tr.Medarbejder.Id == medarbejderId).ToList();

                return tidsregistreringer.Select(TidsregistreringMapper.Map).ToList();
            }
        }
    }
}
