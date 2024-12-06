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
                foreach (Tidsregistrering t in context.Tidsregistreringer.ToList())
                {
                    if (t.MedarbejderID == id)
                    {
                        list.Add(t);
                    }
                }

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
                double sum = 0;
                foreach (Tidsregistrering t in context.Tidsregistreringer.ToList())
                {
                    if (t.MedarbejderID == id)
                    {
                        sum += (double)((t.SlutTid - t.StartTid).TotalHours);
                    }
                }

                return sum;
            }
        }

        // arbejdstid de sidste 30 dage
        public static double GetArbejdstidSidsteMaaned(int id)
        {
            using (Database context = new Database())
            {
                double sum = 0;
                foreach (Tidsregistrering t in context.Tidsregistreringer.ToList())
                {
                    if (t.MedarbejderID == id && t.StartTid >= DateTime.Now.AddDays(-30))
                    {
                        sum += (double)((t.SlutTid - t.StartTid).TotalHours);
                    }
                }

                return sum;
            }
        }

        // arbejdstid den sidste uge
        public static double GetArbejdstidSidsteUge(int id)
        {
            using (Database context = new Database())
            {
                double sum = 0;
                foreach (Tidsregistrering t in context.Tidsregistreringer.ToList())
                {
                    if (t.MedarbejderID == id && t.StartTid >= DateTime.Now.AddDays(-7))
                    {
                        sum += (double)((t.SlutTid - t.StartTid).TotalHours);
                    }
                }

                return sum;
            }
        }
    }
}
