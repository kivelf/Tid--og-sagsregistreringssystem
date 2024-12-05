using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class Sag
    {
        [Key]
        public int SagID { get; set; }
        public string Overskrift { get; set; }
        public string Beskrivelse { get; set; }
        public int AfdelingID { get; set; } // foreign key


        // 'tom' Constructor for EntityFramework
        public Sag() { }
        public Sag(string overskrift, string beskrivelse, int afdelingID)
        {
            Overskrift = overskrift;
            Beskrivelse = beskrivelse;
            AfdelingID = afdelingID;
        }

        public Sag(int sagsNummer, string overskrift, string beskrivelse, int afdelingID)
        {
            SagID = sagsNummer;
            Overskrift = overskrift;
            Beskrivelse = beskrivelse;
            AfdelingID = afdelingID;
        }

        public override string ToString()
        {
            return $"Sag {SagID}: {Overskrift}";
        }
    }
}
