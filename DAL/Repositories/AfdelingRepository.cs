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
    public class AfdelingRepository
    {

        public static AfdelingDTO GetAfdelingById(int id)
        {
            using (Context context = new Context())
            {
                return AfdelingMapper.Map(context.Afdelinger.Find(id)) ?? null;
            }
        }

        public static List<AfdelingDTO> GetAfdelinger()
        {
            using (Context context = new Context())
            {
                return context.Afdelinger.ToList().Select(a => AfdelingMapper.Map(a)).ToList();
            }
        }

        public static AfdelingDTO AddAfdeling(AfdelingDTO afdelingDTO)
        {
            using (Context context = new Context())
            {
                context.Afdelinger.Add(AfdelingMapper.Map(afdelingDTO));
                context.SaveChanges();
                return afdelingDTO;
            }
        }
    }
}
