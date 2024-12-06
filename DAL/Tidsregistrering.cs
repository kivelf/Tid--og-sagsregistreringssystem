using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class Tidsregistrering
    {
        [Key]
        public int TidsregistreringID { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }
        public int MedarbejderID { get; set; }
        public int SagID { get; set; }

        // 'tom' Constructor for EntityFramework
        public Tidsregistrering() { }

        public Tidsregistrering(DateTime startTid, DateTime slutTid, int medarbejderID, int sagID)
        {
            StartTid = startTid;
            SlutTid = slutTid;
            MedarbejderID = medarbejderID;
            SagID = sagID;
        }
    }
}
