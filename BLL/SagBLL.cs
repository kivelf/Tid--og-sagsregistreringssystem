using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SagBLL
    {
        public DTO.Sag GetSag(int id)
        {
            if (id <= 0) throw new IndexOutOfRangeException();
            return RegistreringssystemRepository.GetSag(id);
        }

        public List<DTO.Sag> GetAlleSager()
        {
            return RegistreringssystemRepository.GetAlleSager();
        }

        // overloaded method -- returnerer alle sager fra en bestemt Afdeling
        public List<DTO.Sag> GetAlleSager(int id)
        {
            return RegistreringssystemRepository.GetAlleSager(id);
        }

        public void AddSag(DTO.Sag sag)
        {
            RegistreringssystemRepository.AddSag(sag);
        }

        public void EditSag(DTO.Sag sag)
        {
            RegistreringssystemRepository.EditSag(sag);
        }
    }
}
