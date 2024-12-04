using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class Afdeling
    {
        [Key]
        public int AfdelingID { get; set; }
        public string Navn {  get; set; }
        
        public string Virksomhed { get; set; }
        public virtual List<Medarbejder> Medarbejdere { get; set; } = new List<Medarbejder>();
        public virtual List<Sag> Sager { get; set; } = new List<Sag>();


        // 'tom' Constructor for EntityFramework
        public Afdeling() { }

        public Afdeling(string navn, int nummer) 
        { 
            Navn = navn;
            AfdelingID = nummer;
            Virksomhed = "Heimdall Sikring";
        }

        public override string ToString() 
        { 
            return $"{AfdelingID}) {Navn}";
        }
    }
}
