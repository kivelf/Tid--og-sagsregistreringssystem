using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RegistreringssystemRepository
    {
        // Afdeling-relaterede
        public static DTO.Afdeling GetAfdeling(int id)
        {
            using (Database context = new Database())
            {
                // returnerer null hvis ikke fundet
               return RegistreringssystemMapper.Map(context.Afdelinger.Where(a => a.AfdelingID == id).First());
            }
        }

        public static List<DTO.Afdeling> GetAlleAfdelinger() 
        {
            using (Database context = new Database())
            {
                List<Afdeling> list = new List<Afdeling>();
                list = context.Afdelinger.ToList();

                return RegistreringssystemMapper.Map(list);
            }
        }


        //---------------------------------------
        // Medarbejder-relaterede
        public static DTO.Medarbejder GetMedarbejder(int id) 
        {
            using (Database context = new Database())
            {
                // returnerer null hvis ikke fundet
                return RegistreringssystemMapper.Map(context.Medarbejdere.Find(id));
            }
        }

        public static List<DTO.Medarbejder> GetAlleMedarbejdere()
        {
            using (Database context = new Database())
            {
                List<Medarbejder> list = new List<Medarbejder>();
                list = context.Medarbejdere.ToList();

                return RegistreringssystemMapper.Map(list);
            }
        }

        public static List<DTO.Medarbejder> GetAlleMedarbejdere(int id)
        {
            using (Database context = new Database())
            {
                // returnerer null hvis ikke fundet
                List<Medarbejder> list = new List<Medarbejder>();
                foreach (Medarbejder m in context.Medarbejdere.ToList())
                {
                    if (m.AfdelingID == id)
                    {
                        list.Add(m);
                    }
                }

                return RegistreringssystemMapper.Map(list);
            }
        }

        public static void AddMedarbejder(DTO.Medarbejder medarbejder) 
        {
            using (Database context = new Database())
            {
                context.Medarbejdere.Add(RegistreringssystemMapper.Map(medarbejder));

                context.SaveChanges();
            }
        }

        public static void EditMedarbejder(DTO.Medarbejder medarbejder) 
        {
            using (Database context = new Database())
            {
                Medarbejder dataMedarbejder = context.Medarbejdere.Find(medarbejder.MedarbejderID);
                RegistreringssystemMapper.Update(medarbejder, dataMedarbejder);

                context.SaveChanges();
            }
        }


        //---------------------------------------
        // Sag-relaterede
        public static DTO.Sag GetSag(int id)
        {
            using (Database context = new Database())
            {
                // returnerer null hvis ikke fundet
                return RegistreringssystemMapper.Map(context.Sager.Find(id));
            }
        }

        public static List<DTO.Sag> GetAlleSager()
        {
            using (Database context = new Database())
            {
                List<Sag> list = new List<Sag>();
                list = context.Sager.ToList();

                return RegistreringssystemMapper.Map(list);
            }
        }

        public static List<DTO.Sag> GetAlleSager(int id)
        {
            using (Database context = new Database())
            {
                // returnerer null hvis ikke fundet
                List<Sag> list = new List<Sag>();
                foreach (Sag s in context.Sager.ToList())
                {
                    if (s.AfdelingID == id) 
                    {
                        list.Add(s);
                    }
                }

                return RegistreringssystemMapper.Map(list);
            }
        }

        public static void AddSag(DTO.Sag sag)
        {
            using (Database context = new Database())
            {
                context.Sager.Add(RegistreringssystemMapper.Map(sag));

                context.SaveChanges();
            }
        }

        public static void EditSag(DTO.Sag sag)
        {
            using (Database context = new Database())
            {
                Sag dataSag = context.Sager.Find(sag.SagID);
                RegistreringssystemMapper.Update(sag, dataSag);

                context.SaveChanges();
            }
        }


        //---------------------------------------
        // Tidsregistrering-relaterede
        public static DTO.Tidsregistrering GetTidsregistrering(int id)
        {
            using (Database context = new Database())
            {
                // returnerer null hvis ikke fundet
                return RegistreringssystemMapper.Map(context.Tidsregistreringer.Find(id));
            }
        }

        public static void AddTidsregistrering(DTO.Tidsregistrering tidsregistrering)
        {
            using (Database context = new Database())
            {
                context.Tidsregistreringer.Add(RegistreringssystemMapper.Map(tidsregistrering));

                context.SaveChanges();
            }
        }
    }
}
