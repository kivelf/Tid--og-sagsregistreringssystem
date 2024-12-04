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
        [ForeignKey("Afdeling")]
        public int AfdelingID { get; set; } // foreign key
        public virtual Afdeling Afdeling { get; set; }

        public virtual List<Tidsregistrering> Tidsregistreringer { get; set; } = new List<Tidsregistrering>();

        // 'tom' Constructor for EntityFramework
        public Sag() { }
        public Sag(string overskrift, string beskrivelse, Afdeling afdeling, List<Tidsregistrering> tidsregistreringer)
        {
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
