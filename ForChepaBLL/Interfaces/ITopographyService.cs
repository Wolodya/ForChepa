using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForChepaBLL.DTO;
namespace ForChepaBLL.Interfaces
{
   public interface ITopographyService
    {
        IEnumerable<CitiesDTO> GetAll();
        CitiesDTO Get(int id);
        IEnumerable<CitiesDTO> Find(Func<CitiesDTO, bool> predicate);
        void Create(CitiesDTO item);
        void Update(CitiesDTO item);
        void Delete(int id);
    }
}
