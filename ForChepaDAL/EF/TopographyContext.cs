using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ForChepaDAL.Entities;

namespace ForChepaDAL.EF
{
   public  class TopographyContext:DbContext
    {
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Third> Third { get; set; }

        static TopographyContext()
        {
            Database.SetInitializer<TopographyContext>(new TopoInitializer());
        }

        public TopographyContext(string connString):base(connString)
        {

        }

    }

    public class TopoInitializer : DropCreateDatabaseAlways<TopographyContext>
    {
       
        protected override void Seed(TopographyContext context)
        {
            context.Cities.Add(new Cities { Name = "Dnipro" });
            context.Cities.Add(new Cities { Name = "Berduchyv" });
            context.Cities.Add(new Cities { Name = "New-York" });
            context.Cities.Add(new Cities { Name = "Bejin" });
            context.Countries.Add(new Countries { Name = "Ukraine" });
            context.Countries.Add(new Countries { Name = "Nepal" });
            context.Countries.Add(new Countries { Name = "China" });
            context.Countries.Add(new Countries { Name = "Russia" });
            context.Third.Add(new Third { CitiesId = 1, CountriesId = 2 });
            context.Third.Add(new Third { CitiesId = 2, CountriesId = 2 });
            context.Third.Add(new Third { CitiesId = 3, CountriesId = 3 });
            context.Third.Add(new Third { CitiesId = 3, CountriesId = 4 });
            context.Third.Add(new Third { CitiesId = 4, CountriesId = 1 });
            context.Third.Add(new Third { CitiesId = 2, CountriesId = 4 });
            context.Third.Add(new Third { CitiesId = 1, CountriesId = 2 });
            context.Third.Add(new Third { CitiesId = 2, CountriesId = 2 });
            context.Third.Add(new Third { CitiesId = 3, CountriesId = 3 });
            context.Third.Add(new Third { CitiesId = 3, CountriesId = 4 });
            context.Third.Add(new Third { CitiesId = 4, CountriesId = 1 });
            context.Third.Add(new Third { CitiesId = 2, CountriesId = 4 });
            context.Third.Add(new Third { CitiesId = 1, CountriesId = 2 });
            context.Third.Add(new Third { CitiesId = 2, CountriesId = 2 });
            context.Third.Add(new Third { CitiesId = 3, CountriesId = 3 });
            context.Third.Add(new Third { CitiesId = 3, CountriesId = 4 });
            context.Third.Add(new Third { CitiesId = 4, CountriesId = 1 });
            context.Third.Add(new Third { CitiesId = 2, CountriesId = 4 });
            context.SaveChanges();
            //base.Seed(context);
        }
    }
}
