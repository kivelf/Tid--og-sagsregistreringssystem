using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class AfdelingBLL
    {
        public DTO.Afdeling GetAfdeling(int id)
        {
            if (id <= 0) throw new IndexOutOfRangeException();
            return RegistreringssystemRepository.GetAfdeling(id);
        }

        public List<DTO.Afdeling> GetAlleAfdelinger() 
        {
            return RegistreringssystemRepository.GetAlleAfdelinger();
        }
    }
}
