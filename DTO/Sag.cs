using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Sag
    {
        [Key]
        public int SagsNummer { get; set; }
        public string Overskrift { get; set; }
        public string Beskrivelse { get; set; }
        [ForeignKey("Afdeling")]
        public int AfdelingID { get; set; } // foreign key
        public Afdeling Afdeling { get; set; }
        public List<Tidsregistrering> Tidsregistreringer { get; set; } = new List<Tidsregistrering>();

        public Sag(int sagsNummer, string overskrift, string beskrivelse, Afdeling afdeling, List<Tidsregistrering> tidsregistreringer)
        {
            SagsNummer = sagsNummer;
            Overskrift = overskrift;
            Beskrivelse = beskrivelse;
            AfdelingID = afdeling.Nummer;
            Afdeling = afdeling;
            Tidsregistreringer = tidsregistreringer;
        }

        public override string ToString()
        {
            return $"Sag {SagsNummer}: {Overskrift}";
        }
    }
}
