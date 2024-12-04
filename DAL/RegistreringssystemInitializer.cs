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
