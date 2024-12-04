using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Afdeling
    {
        public string Navn {  get; set; }
        public int Nummer { get; set; }
        public string Virksomhed { get; set; }
        public List<Medarbejder> Medarbejdere { get; set; } = new List<Medarbejder>();
        public List<Sag> Sager { get; set; } = new List<Sag>();

        public Afdeling(string navn, int nummer) 
        { 
            Navn = navn;
            Nummer = nummer;
            Virksomhed = "Heimdall Sikring";
        }

        public override string ToString() 
        {
            return $"{Nummer}) {Navn}";
        }
    }
}
