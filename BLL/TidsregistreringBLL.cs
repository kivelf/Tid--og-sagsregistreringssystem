using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TidsregistreringBLL
    {
        public DTO.Tidsregistrering GetTidsregistrering(int id)
        {
            if (id <= 0) throw new IndexOutOfRangeException();
            return RegistreringssystemRepository.GetTidsregistrering(id);
        }

        public void AddTidsregistrering(DTO.Tidsregistrering tidsregistrering)
        {
            RegistreringssystemRepository.AddTidsregistrering(tidsregistrering);
        }
    }
}
