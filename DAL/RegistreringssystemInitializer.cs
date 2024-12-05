using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class RegistreringssystemInitializer : CreateDatabaseIfNotExists<Database>
    {
        protected override void Seed(Database context)
        {
            // afdelinger
            context.Afdelinger.Add(new Afdeling("Sjælland", 1));
            context.Afdelinger.Add(new Afdeling("Fyn", 2));
            context.Afdelinger.Add(new Afdeling("Jylland", 3));

            // 'default' sager
            context.Sager.Add(new Sag("Adminstrativ tid (Sjælland)", "Til ad-hoc opgaver på Sjælland", 1));
            context.Sager.Add(new Sag("Adminstrativ tid (Fyn)", "Til ad-hoc opgaver på Fyn", 2));
            context.Sager.Add(new Sag("Adminstrativ tid (Jylland)", "Til ad-hoc opgaver i Jylland", 3));

            // medarbejdere
            context.Medarbejdere.Add(new Medarbejder("Jimmy", "JDH", "010283-3245", 1));
            context.Medarbejdere.Add(new Medarbejder("Johnny", "JHD", "030588-1243", 1));
            context.Medarbejdere.Add(new Medarbejder("Lara", "LCR", "030485-3312", 1));
            context.Medarbejdere.Add(new Medarbejder("Bob", "BOB", "051690-2425", 2));
            context.Medarbejdere.Add(new Medarbejder("Bobsine", "BBS", "051691-2524", 2));
            context.Medarbejdere.Add(new Medarbejder("Jimbob", "JBB", "080888-3667", 3));
            context.Medarbejdere.Add(new Medarbejder("Pippi", "PPP", "010695-3312", 3));

            context.SaveChanges();
            
            base.Seed(context);
        }

        // denne funktion må ikke kaldes
        private void dummy() 
        {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
    }
}
