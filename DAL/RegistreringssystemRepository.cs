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
                List<Medarbejder> list = new List<Medarbejder>();
                // tager kun medarbejdere fra en bestemt afdeling
                list = context.Medarbejdere.Where(m => m.AfdelingID == id).ToList();

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
                List<Sag> list = new List<Sag>();
                // tager kun sager fra en bestemt afdeling
                list = context.Sager.Where(s => s.AfdelingID == id).ToList();

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

        public static List<DTO.Tidsregistrering> GetAlleTidsregistreringer()
        {
            using (Database context = new Database())
            {
                List<Tidsregistrering> list = new List<Tidsregistrering>();
                list = context.Tidsregistreringer.ToList();

                return RegistreringssystemMapper.Map(list);
            }
        }

        public static List<DTO.Tidsregistrering> GetAlleTidsregistreringer(int id)
        {
            using (Database context = new Database())
            {
                List<Tidsregistrering> list = new List<Tidsregistrering>();
                // tager kun tidsregistreringer på en bestemt medarbejder
                list = context.Tidsregistreringer.Where(t => t.MedarbejderID == id).ToList();

                return RegistreringssystemMapper.Map(list);
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

        // beregn arbejdstid på medarbejder
        // total
        public static double GetTotalArbejdstid(int id) 
        {
            using (Database context = new Database()) 
            {
                return context.Tidsregistreringer
                    .Where(t => t.MedarbejderID == id)
                    .ToList().Sum(t => (t.SlutTid - t.StartTid).TotalHours);
            }
        }

        // arbejdstid de sidste 30 dage
        public static double GetArbejdstidSidsteMaaned(int id)
        {
            using (Database context = new Database())
            {
                DateTime sidsteMaaned = DateTime.Now.AddDays(-30);

                return context.Tidsregistreringer
                    .Where(t => t.MedarbejderID == id && t.StartTid >= sidsteMaaned)
                    .ToList().Sum(t => (t.SlutTid - t.StartTid).TotalHours);
            }
        }

        // arbejdstid den sidste uge
        public static double GetArbejdstidSidsteUge(int id)
        {
            using (Database context = new Database())
            {
                DateTime sidsteUge = DateTime.Now.AddDays(-7);

                return context.Tidsregistreringer
                    .Where(t => t.MedarbejderID == id && t.StartTid >= sidsteUge)
                    .ToList().Sum(t => (t.SlutTid - t.StartTid).TotalHours);
            }
        }
    }
}
