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
