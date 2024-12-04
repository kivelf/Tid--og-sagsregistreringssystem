using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Tidsregistrering
    {
        public int Id { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }
        public Medarbejder Medarbejder { get; set; }
        public Sag Sag { get; set; }

        public Tidsregistrering(DateTime startTid, DateTime slutTid, Medarbejder medarbejder, Sag sag)
        {
            Id = medarbejder.MedarbejderID + sag.SagsNummer + new Random().Next(100);
            StartTid = startTid;
            SlutTid = slutTid;
            Medarbejder = medarbejder;
            Sag = sag;
        }

        public Tidsregistrering(int id,DateTime startTid, DateTime slutTid, Medarbejder medarbejder, Sag sag)
        {
            Id = id;
            StartTid = startTid;
            SlutTid = slutTid;
            Medarbejder = medarbejder;
            Sag = sag;
        }

        public override string ToString() 
        {
            return $"[{Medarbejder.Navn} har arbejdet på sag {Sag.SagsNummer} " +
                $"i {(SlutTid - StartTid).TotalHours}:{(SlutTid - StartTid).TotalMinutes % 60} timer";
        }
    }
}
