using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MedarbejderBLL
    {
        public DTO.Medarbejder GetMedarbejder(int id) 
        {
            if (id <= 0) throw new IndexOutOfRangeException();
            return RegistreringssystemRepository.GetMedarbejder(id);
        }

        public List<DTO.Medarbejder> GetAlleMedarbejdere()
        {
            return RegistreringssystemRepository.GetAlleMedarbejdere();
        }

        // overloaded method -- returnerer alle medarbejdere fra en bestemt Afdeling
        public List<DTO.Medarbejder> GetAlleMedarbejdere(int id)
        {
            return RegistreringssystemRepository.GetAlleMedarbejdere(id);
        }

        public void AddMedarbejder(DTO.Medarbejder medarbejder) 
        {
            RegistreringssystemRepository.AddMedarbejder(medarbejder);
        }

        public void EditMedarbejder(DTO.Medarbejder medarbejder)
        {
            RegistreringssystemRepository.EditMedarbejder(medarbejder);
        }
    }
}
