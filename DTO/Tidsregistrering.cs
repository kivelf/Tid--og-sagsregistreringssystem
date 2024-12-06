using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Tidsregistrering
    {
        [Key]
        public int TidsregistreringID { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }
        public int MedarbejderID { get; set; }
        public int SagID { get; set; }

        public Tidsregistrering(DateTime startTid, DateTime slutTid, int medarbejderID, int sagID)
        {
            StartTid = startTid;
            SlutTid = slutTid;
            MedarbejderID = medarbejderID;
            SagID = sagID;
        }

        public Tidsregistrering(int id, DateTime startTid, DateTime slutTid, int medarbejderID, int sagID)
        {
            TidsregistreringID = id;
            StartTid = startTid;
            SlutTid = slutTid;
            MedarbejderID = medarbejderID;
            SagID = sagID;
        }

        public override string ToString() 
        {
            // pænere formattering af minutterne
            string mins = ((SlutTid - StartTid).TotalMinutes % 60).ToString();
            if (mins.Equals("0")) 
            {
                mins += "0";
            }

            return $"Medarbejder: {MedarbejderID}, d.{StartTid.Day}/{StartTid.Month}/{StartTid.Year} -> {(int)(SlutTid - StartTid).TotalHours}:{mins} timer";
        }
    }
}
