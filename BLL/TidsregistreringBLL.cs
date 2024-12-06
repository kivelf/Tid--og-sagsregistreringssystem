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

        public List<DTO.Tidsregistrering> GetAlleTidsregistreringer()
        {
            return RegistreringssystemRepository.GetAlleTidsregistreringer();
        }

        // overloaded method -- returnerer alle tidsregistreringer på en bestemt medarbejder
        public List<DTO.Tidsregistrering> GetAlleTidsregistreringer(int id)
        {
            return RegistreringssystemRepository.GetAlleTidsregistreringer(id);
        }

        public void AddTidsregistrering(DTO.Tidsregistrering tidsregistrering)
        {
            RegistreringssystemRepository.AddTidsregistrering(tidsregistrering);
        }

        public double GetTotalArbejdstid(int id) 
        {
            return RegistreringssystemRepository.GetTotalArbejdstid(id);
        }

        public double GetArbejdstidSidsteMaaned(int id)
        {
            return RegistreringssystemRepository.GetArbejdstidSidsteMaaned(id);
        }

        public double GetArbejdstidSidsteUge(int id)
        {
            return RegistreringssystemRepository.GetArbejdstidSidsteUge(id);
        }
    }
}
