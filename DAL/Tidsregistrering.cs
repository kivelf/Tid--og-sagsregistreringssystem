using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class Tidsregistrering
    {
        public int TidsregistreringID { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }
        public virtual Medarbejder Medarbejder { get; set; }
        public virtual Sag Sag { get; set; }

        // 'tom' Constructor for EntityFramework
        public Tidsregistrering() { }
        
        public Tidsregistrering(int id, DateTime startTid, DateTime slutTid, Medarbejder medarbejder, Sag sag)
        {
            TidsregistreringID = id;
            StartTid = startTid;
            SlutTid = slutTid;
            Medarbejder = medarbejder;
            Sag = sag;
        }

        public override string ToString() 
        {
            return $"[{Medarbejder.Navn} har arbejdet på sag {Sag.SagID} " +
                $"i {(SlutTid - StartTid).TotalHours}:{(SlutTid - StartTid).TotalMinutes % 60} timer";
        }
    }
}
