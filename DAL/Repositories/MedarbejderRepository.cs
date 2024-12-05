using DAL.Mappers;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class MedarbejderRepository
    {
        public static void DeleteMedarbejder(int id)
        {
            using (var context = new Context())
            {
                var medarbejder = context.Medarbejdere.Where(m => m.Id == id).FirstOrDefault();

                if (medarbejder == null)
                {
                    throw new Exception("Medarbejder ikke fundet.");
                }

                context.Medarbejdere.Remove(medarbejder);
                context.SaveChanges();
            }
        }

        public static MedarbejderDTO GetMedarbejderById(int id)
        {
            using (Context context = new Context())
            {
                return MedarbejderMapper.Map(context.Medarbejdere.Find(id)) ?? null;
            }
        }

        public static List<MedarbejderDTO> GetMedarbejdere()
        {
            using (Context context = new Context())
            {
                return context.Medarbejdere.ToList().Select(m => MedarbejderMapper.Map(m)).ToList();
            }
        }

        public static MedarbejderDTO AddMedarbejder(MedarbejderDTO medarbejderDTO)
        {
            using (Context context = new Context())
            {
                var eksisterendeAfdeling = context.Afdelinger.FirstOrDefault(a => a.Id == medarbejderDTO.Afdeling.Id);
                var nyMedarbejder = MedarbejderMapper.Map(medarbejderDTO);
                nyMedarbejder.Afdeling = eksisterendeAfdeling;

                context.Medarbejdere.Add(nyMedarbejder);
                context.SaveChanges();
            }
            return medarbejderDTO;

        }

        public static List<MedarbejderDTO> GetMedarbejdereForAfdeling(int afdelingnummer)
        {
            using (var context = new Context())
            {
                var afdeling = context.Afdelinger.Include(a => a.Medarbejdere).FirstOrDefault(a => a.Nummer == afdelingnummer);
                return afdeling != null ? afdeling.Medarbejdere.Select(MedarbejderMapper.Map).ToList() : new List<MedarbejderDTO>();
            }
        }
    }
}
