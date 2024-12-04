using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class RegistreringssystemMapper
    {
        // Afdeling mappers
        public static DTO.Afdeling Map(Afdeling afdeling) 
        {
            if (afdeling != null)
            {
                return new DTO.Afdeling(afdeling.Navn, afdeling.AfdelingID);
            }
            else
                return null;
        }

        public static Afdeling Map(DTO.Afdeling afdeling) 
        {
            if (afdeling != null)
            {
                // vi opretter ikke nye afdelinger i GUI,
                // derfor finder blot fra de eksisterende i DB'en
                using (Database context = new Database())
                {
                    // returnerer null hvis ikke fundet
                    return context.Afdelinger.Where(a => a.AfdelingID == afdeling.Nummer).First();
                }
            }
            else
                return null;
        }

        public static List<DTO.Afdeling> Map(List<Afdeling> afdelinger)
        {
            List<DTO.Afdeling> retur = new List<DTO.Afdeling>();
            foreach (Afdeling a in afdelinger)
            {
                retur.Add(RegistreringssystemMapper.Map(a));
            }
            return retur;
        }

        internal static void Update(DTO.Afdeling afdeling, Afdeling dataAfdeling) 
        {
            if (afdeling != null) 
            { 
                dataAfdeling.Medarbejdere = RegistreringssystemMapper.Map(afdeling.Medarbejdere);
                dataAfdeling.Sager = Map(afdeling.Sager);
            }
            else
                dataAfdeling = null;
        }


        //---------------------------------------
        // Medarbejder mappers
        public static DTO.Medarbejder Map(Medarbejder medarbejder) 
        {
            if (medarbejder != null) 
            {
                return new DTO.Medarbejder(medarbejder.MedarbejderID, medarbejder.Navn, medarbejder.Initialer, medarbejder.CprNr, RegistreringssystemMapper.Map(medarbejder.Afdeling));
            }
            else
                return null;
        }

        public static Medarbejder Map(DTO.Medarbejder medarbejder) 
        {
            if (medarbejder != null) 
            {
                return new Medarbejder(medarbejder.MedarbejderID, medarbejder.Navn, medarbejder.Initialer, medarbejder.CprNr, Map(medarbejder.Afdeling));
            }
            else 
                return null;
        }

        public static List<DTO.Medarbejder> Map(List<Medarbejder> medarbejdere) 
        { 
            List<DTO.Medarbejder> retur = new List<DTO.Medarbejder>();
            foreach (Medarbejder m in medarbejdere) 
            {
                retur.Add(RegistreringssystemMapper.Map(m));
            }
            return retur;
        }

        public static List<Medarbejder> Map(List<DTO.Medarbejder> medarbejdere) 
        { 
            List<Medarbejder> retur = new List<Medarbejder> ();
            foreach (DTO.Medarbejder m in medarbejdere) 
            {
                retur.Add(RegistreringssystemMapper.Map(m));
            }
            return retur;
        }

        internal static void Update(DTO.Medarbejder medarbejder, Medarbejder dataMedarbejder)
        {
            if (medarbejder != null)
            {
                dataMedarbejder.Navn = medarbejder.Navn;
                dataMedarbejder.CprNr = medarbejder.CprNr;
                dataMedarbejder.Initialer = medarbejder.Initialer;
                dataMedarbejder.Afdeling = Map(medarbejder.Afdeling);
            }
            else
                dataMedarbejder = null;
        }


        //---------------------------------------
        // Sag mappers
        public static DTO.Sag Map(Sag sag)
        {
            if (sag != null)
            {
                return new DTO.Sag(sag.SagID, sag.Overskrift, sag.Beskrivelse, Map(sag.Afdeling), Map(sag.Tidsregistreringer));
            }
            else
                return null;
        }

        public static Sag Map(DTO.Sag sag)
        {
            if (sag != null)
            {
                return new Sag(sag.Overskrift, sag.Beskrivelse, Map(sag.Afdeling), Map(sag.Tidsregistreringer));
            }
            else
                return null;
        }

        public static List<DTO.Sag> Map(List<Sag> sager)
        {
            List<DTO.Sag> retur = new List<DTO.Sag>();
            foreach (Sag s in sager)
            {
                retur.Add(RegistreringssystemMapper.Map(s));
            }
            return retur;
        }

        public static List<Sag> Map(List<DTO.Sag> sager)
        {
            List<Sag> retur = new List<Sag>();
            foreach (DTO.Sag s in sager)
            {
                retur.Add(RegistreringssystemMapper.Map(s));
            }
            return retur;
        }

        internal static void Update(DTO.Sag sag, Sag dataSag)
        {
            if (sag != null)
            {
                dataSag.SagID = sag.SagsNummer;
                dataSag.Overskrift = sag.Overskrift;
                dataSag.Beskrivelse = sag.Beskrivelse;
                dataSag.Afdeling = Map(sag.Afdeling);
                dataSag.Tidsregistreringer = Map(sag.Tidsregistreringer);
            }
            else
                dataSag = null;
        }


        //---------------------------------------
        // Tidsregistrering mappers
        public static DTO.Tidsregistrering Map(Tidsregistrering tidsregistrering)
        {
            if (tidsregistrering != null)
            {
                return new DTO.Tidsregistrering(tidsregistrering.TidsregistreringID, tidsregistrering.StartTid, tidsregistrering.SlutTid, 
                    RegistreringssystemRepository.GetMedarbejder(tidsregistrering.Medarbejder.MedarbejderID), 
                    RegistreringssystemRepository.GetSag(tidsregistrering.Sag.SagID));
            }
            else
                return null;
        }

        public static Tidsregistrering Map(DTO.Tidsregistrering tidsregistrering)
        {
            if (tidsregistrering != null)
            {
                return new Tidsregistrering(tidsregistrering.Id, tidsregistrering.StartTid, tidsregistrering.SlutTid,
                    Map(RegistreringssystemRepository.GetMedarbejder(tidsregistrering.Medarbejder.MedarbejderID)), 
                    Map(RegistreringssystemRepository.GetSag(tidsregistrering.Sag.SagsNummer)));
            }
            else
                return null;
        }

        public static List<DTO.Tidsregistrering> Map(List<Tidsregistrering> tidsregistreringer)
        {
            List<DTO.Tidsregistrering> retur = new List<DTO.Tidsregistrering>();
            foreach (Tidsregistrering t in tidsregistreringer)
            {
                retur.Add(RegistreringssystemMapper.Map(t));
            }
            return retur;
        }

        public static List<Tidsregistrering> Map(List<DTO.Tidsregistrering> tidsregistreringer)
        {
            List<Tidsregistrering> retur = new List<Tidsregistrering>();
            foreach (DTO.Tidsregistrering t in tidsregistreringer)
            {
                retur.Add(RegistreringssystemMapper.Map(t));
            }
            return retur;
        }
    }
}
