using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int AfdelingID { get; set; } // foreign key

        // 'tom' Constructor for EntityFramework
        public Medarbejder() { }

        public Medarbejder(string navn, string initialer, string cprNr, int afdelingID)
        {
            Navn = navn;
            Initialer = initialer;
            CprNr = cprNr;
            AfdelingID = afdelingID;
        }

        public Medarbejder(int medarbejderID, string navn, string initialer, string cprNr, int afdelingID)
        {
            MedarbejderID = medarbejderID;
            Navn = navn;
            Initialer = initialer;
            CprNr = cprNr;
            AfdelingID = afdelingID;
        }

        public override string ToString()
        {
            return $"{Navn} ({Initialer})";
        }
    }
}
