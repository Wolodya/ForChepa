using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForChepaDAL.Entities;
namespace ForChepaDAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Cities> Cities { get; }
        IRepository<Countries> Countries { get; }
        IRepository<Third> Third { get; }
        void Save();
    }
}
