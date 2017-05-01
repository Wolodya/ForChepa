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
   public class CitiesRepository : IRepository<Cities>
    {
        private TopographyContext tc;
        public CitiesRepository(TopographyContext context)
        {
            tc = context;
        }
        public void Create(Cities item)
        {
            tc.Cities.Add(item);
            tc.SaveChanges();
        }

        public void Delete(int id)
        {
            Cities city = tc.Cities.Find(id);
            if (city!=null)
            {
                tc.Cities.Remove(city);
            }
        }

        public IEnumerable<Cities> Find(Func<Cities, bool> predicate)
        {
            return tc.Cities.Where(predicate).ToList();
        }

        public Cities Get(int id)
        {
            return tc.Cities.Find(id);
        }

        public IEnumerable<Cities> GetAll()
        {
            return tc.Cities;
        }

        public void Update(Cities item)
        {
            tc.Entry(item).State = EntityState.Modified;
            tc.SaveChanges();
        }
    }
}
