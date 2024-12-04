using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class Medarbejder
    {
        [Key]
        public int MedarbejderID { get; set; }
        public string Navn { get; set; }
        public string Initialer { get; set; }
        public string CprNr { get; set; }
        public virtual Afdeling Afdeling { get; set; }

        // 'tom' Constructor for EntityFramework
        public Medarbejder() { }

        public Medarbejder(int medarbejderID, string navn, string initialer, string cprNr, Afdeling afdeling) 
        { 
            MedarbejderID = medarbejderID;
            Navn = navn;
            Initialer = initialer;
            CprNr = cprNr;
            Afdeling = afdeling;
        }

        public override string ToString()
        {
            return $"{Navn} ({Afdeling})";
        }
    }
}
