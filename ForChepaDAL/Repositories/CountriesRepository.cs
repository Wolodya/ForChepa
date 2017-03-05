using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ForChepaDAL.EF;
using ForChepaDAL.Entities;
using ForChepaDAL.Interfaces;

namespace ForChepaDAL.Repositories
{
   public class CountriesRepository:IRepository<Countries>
    {

        private TopographyContext tc;
        public CountriesRepository(TopographyContext context)
        {
            tc = context;
        }
        public void Create(Countries item)
        {
            tc.Countries.Add(item);
        }

        public void Delete(int id)
        {
            Countries country = tc.Countries.Find(id);
            if (country != null)
            {
                tc.Countries.Remove(country);
            }
        }

        public IEnumerable<Countries> Find(Func<Countries, bool> predicate)
        {
            return tc.Countries.Where(predicate).ToList();
        }

        public Countries Get(int id)
        {
            return tc.Countries.Find(id);
        }

        public IEnumerable<Countries> GetAll()
        {
            return tc.Countries;
        }

        public void Update(Countries item)
        {
            tc.Entry(item).State = EntityState.Modified;
        }
    }
}
