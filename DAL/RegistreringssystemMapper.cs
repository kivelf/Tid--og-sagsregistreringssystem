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

        public static List<DTO.Afdeling> Map(List<Afdeling> afdelinger)
        {
            List<DTO.Afdeling> retur = new List<DTO.Afdeling>();
            foreach (Afdeling a in afdelinger)
            {
                retur.Add(RegistreringssystemMapper.Map(a));
            }
            return retur;
        }


        //---------------------------------------
        // Medarbejder mappers
        public static DTO.Medarbejder Map(Medarbejder medarbejder) 
        {
            if (medarbejder != null) 
            {
                return new DTO.Medarbejder(medarbejder.MedarbejderID, medarbejder.Navn, medarbejder.Initialer, medarbejder.CprNr, medarbejder.AfdelingID);
            }
            else
                return null;
        }

        public static Medarbejder Map(DTO.Medarbejder medarbejder) 
        {
            if (medarbejder != null) 
            {
                return new Medarbejder(medarbejder.MedarbejderID, medarbejder.Navn, medarbejder.Initialer, medarbejder.CprNr, medarbejder.AfdelingID);
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

        internal static void Update(DTO.Medarbejder medarbejder, Medarbejder dataMedarbejder)
        {
            if (medarbejder != null)
            {
                dataMedarbejder.Navn = medarbejder.Navn;
                dataMedarbejder.CprNr = medarbejder.CprNr;
                dataMedarbejder.Initialer = medarbejder.Initialer;
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
                return new DTO.Sag(sag.SagID, sag.Overskrift, sag.Beskrivelse, sag.AfdelingID);
            }
            else
                return null;
        }

        public static Sag Map(DTO.Sag sag)
        {
            if (sag != null)
            {
                return new Sag(sag.Overskrift, sag.Beskrivelse, sag.AfdelingID);
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

        internal static void Update(DTO.Sag sag, Sag dataSag)
        {
            if (sag != null)
            {
                dataSag.Overskrift = sag.Overskrift;
                dataSag.Beskrivelse = sag.Beskrivelse;
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
                return new DTO.Tidsregistrering(tidsregistrering.StartTid, tidsregistrering.SlutTid, 
                    tidsregistrering.MedarbejderID, tidsregistrering.SagID);
            }
            else
                return null;
        }

        public static Tidsregistrering Map(DTO.Tidsregistrering tidsregistrering)
        {
            if (tidsregistrering != null)
            {
                return new Tidsregistrering(tidsregistrering.StartTid, tidsregistrering.SlutTid,
                    tidsregistrering.MedarbejderID, tidsregistrering.SagID);
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
    }
}
