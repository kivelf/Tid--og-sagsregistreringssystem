using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
            // flere sager
            context.Sager.Add(new Sag("Montage af stålgitter (Korsør)", "Stålgitter (bank)", 1));
            context.Sager.Add(new Sag("Reparation af brandjalousi (Svendborg)", "Brandjalousi (kantine)", 2));
            context.Sager.Add(new Sag("Montage af rullegitter (Vejle)", "Rullegitter (Pilgrim butik)", 3));
            context.Sager.Add(new Sag("Reparation af rullegitter (Hillerød)", "Rullegitter (Hobbii butik)", 1));
            context.Sager.Add(new Sag("Reparation af brandjalousi (Billund)", "Brandjalousi (lufthavn)", 3));

            // medarbejdere
            context.Medarbejdere.Add(new Medarbejder("Jimmy", "JDH", "010283-3245", 1));
            context.Medarbejdere.Add(new Medarbejder("Johnny", "JHD", "030588-1243", 1));
            context.Medarbejdere.Add(new Medarbejder("Lara", "LCR", "030485-3312", 1));
            context.Medarbejdere.Add(new Medarbejder("Bob", "BOB", "051690-2425", 2));
            context.Medarbejdere.Add(new Medarbejder("Bobsine", "BBS", "051691-2524", 2));
            context.Medarbejdere.Add(new Medarbejder("Jimbob", "JBB", "080888-3667", 3));
            context.Medarbejdere.Add(new Medarbejder("Pippi", "PPP", "010695-3312", 3));

            // tidsregistreringer
            // data for the past week for Jimmy
            context.Tidsregistreringer.Add(new Tidsregistrering(DateTime.Now, DateTime.Now.AddHours(15), 1, 7));
            context.Tidsregistreringer.Add(new Tidsregistrering(DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-3).AddHours(12).AddMinutes(30), 1, 1));
            // data for the past month for Jimmy
            context.Tidsregistreringer.Add(new Tidsregistrering(DateTime.Now.AddDays(-15), DateTime.Now.AddDays(-15).AddHours(30), 1, 4));
            context.Tidsregistreringer.Add(new Tidsregistrering(DateTime.Now.AddDays(-21), DateTime.Now.AddDays(-21).AddHours(20).AddMinutes(30), 1, 1));
            // data from longer back for Jimmy
            context.Tidsregistreringer.Add(new Tidsregistrering(DateTime.Now.AddDays(-90), DateTime.Now.AddDays(-90).AddHours(50), 1, 1));
            // data for the past week for Bob
            context.Tidsregistreringer.Add(new Tidsregistrering(DateTime.Now, DateTime.Now.AddHours(25), 4, 5));
            context.Tidsregistreringer.Add(new Tidsregistrering(DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-5).AddHours(5).AddMinutes(30), 4, 2));

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
