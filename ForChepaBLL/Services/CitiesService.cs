using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForChepaDAL.Entities;
using ForChepaDAL.Interfaces;
using ForChepaBLL.DTO;
using ForChepaBLL.Interfaces;
using AutoMapper;
namespace ForChepaBLL.Services
{
    class CitiesService:ITopographyService<CitiesDTO>
    {
        IUnitOfWork db { get; set; }
        public CitiesService(IUnitOfWork uow)
        {
            db = uow;
        }

        public IEnumerable<CitiesDTO> GetAll()
        {  Mapper.Initialize(cfg => cfg.CreateMap<Cities, CitiesDTO>());
                return Mapper.Map<IEnumerable<Cities>, List<CitiesDTO>>(db.Cities.GetAll());
           
            
        }

        public CitiesDTO Get(int id)
        {

            var city = db.Cities.Get(id);
            Mapper.Initialize(cfg => cfg.CreateMap<Cities, CitiesDTO>());
            return Mapper.Map<Cities, CitiesDTO>(city);
        }

        public IEnumerable<CitiesDTO> Find(Func<CitiesDTO, bool> predicate)
        {
           
            //Mapper.Initialize(cfg => cfg.CreateMap<Cities, CitiesDTO>());

            //return Mapper.Map<Cities, CitiesDTO>(db.Cities.Find(predicate));
          
        }

        public void Create(Cities item)
        {
           
           Mapper.Initialize(cfg => cfg.CreateMap<Cities, CitiesDTO>());

           
        }

        public void Update(CitiesDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
