using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace ForChepa.Models
{
    public class TopoInitializer:DropCreateDatabaseAlways<TopographyContext>
    {
        protected override void Seed(TopographyContext context)
        {
            context.Cities.Add(new Cities { Name = "Dnipro" });
            context.Cities.Add(new Cities { Name = "Berduchyv" });
            context.Cities.Add(new Cities { Name = "New-York" });
            context.Cities.Add(new Cities { Name = "Bejin" });
            context.Countries.Add(new Countries{ Name = "Ukraine" });
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
            base.Seed(context); 
        }
    }
}