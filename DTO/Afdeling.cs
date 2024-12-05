using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Afdeling
    {
        public string Navn {  get; set; }
        [Key]
        public int AfdelingID { get; set; }
        public string Virksomhed { get; set; }

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
