using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Sag
    {
        public int SagsNummer { get; set; }
        public string Overskrift { get; set; }
        public string Beskrivelse { get; set; }
        public Afdeling Afdeling { get; set; }
        public List<Tidsregistrering> Tidsregistreringer { get; set; } = new List<Tidsregistrering>();

        public Sag(int sagsNummer, string overskrift, string beskrivelse, Afdeling afdeling, List<Tidsregistrering> tidsregistreringer)
        {
            SagsNummer = sagsNummer;
            Overskrift = overskrift;
            Beskrivelse = beskrivelse;
            Afdeling = afdeling;
            Tidsregistreringer = tidsregistreringer;
        }

        public override string ToString()
        {
            return $"Sag {SagsNummer}: {Overskrift}";
        }
    }
}
