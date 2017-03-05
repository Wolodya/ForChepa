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
   public class ThirdRepository:IRepository<Third>
    {

        private TopographyContext tc;
        public ThirdRepository(TopographyContext context)
        {
            tc = context;
        }
        public void Create(Third item)
        {
            tc.Third.Add(item);
        }

        public void Delete(int id)
        {
            Third th = tc.Third.Find(id);
            if (th != null)
            {
                tc.Third.Remove(th);
            }
        }

        public IEnumerable<Third> Find(Func<Third, bool> predicate)
        {
            return tc.Third.Where(predicate).ToList();
        }

        public Third Get(int id)
        {
            return tc.Third.Find(id);
        }

        public IEnumerable<Third> GetAll()
        {
            return tc.Third;
        }

        public void Update(Third item)
        {
            tc.Entry(item).State = EntityState.Modified;
        }
    }
}
