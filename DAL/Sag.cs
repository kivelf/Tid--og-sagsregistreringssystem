using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class Sag
    {
        public int SagID { get; set; }
        public string Overskrift { get; set; }
        public string Beskrivelse { get; set; }
        public virtual Afdeling Afdeling { get; set; }
        public virtual List<Tidsregistrering> Tidsregistreringer { get; set; } = new List<Tidsregistrering>();

        // 'tom' Constructor for EntityFramework
        public Sag() { }
        public Sag(int sagsNummer, string overskrift, string beskrivelse, Afdeling afdeling, List<Tidsregistrering> tidsregistreringer)
        {
            SagID = sagsNummer;
            Overskrift = overskrift;
            Beskrivelse = beskrivelse;
            Afdeling = afdeling;
            Tidsregistreringer = tidsregistreringer;
        }

        public override string ToString()
        {
            return $"Sag {SagID}: {Overskrift}";
        }
    }
}
