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
using System.Linq.Expressions;

namespace ForChepaBLL.Services
{
    public class CitiesService : ITopographyService
    {
        IUnitOfWork db { get; set; }
        public CitiesService(IUnitOfWork uow)
        {
            db = uow;
        }

        public IEnumerable<CitiesDTO> GetAll()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Cities, CitiesDTO>());
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

            Mapper.Initialize(cfg => cfg.CreateMap<Func<CitiesDTO, bool>, Func<Cities, bool>>());

            var exp = Mapper.Map<Func<Cities, bool>>(predicate);
            //var cityPredicate = Mapper.Map<Func<CitiesDTO, bool>, Func<Cities, bool>>(predicate);
            var cities = db.Cities.Find(exp);
            var citiesDTO = Mapper.Map<IEnumerable<Cities>, IEnumerable<CitiesDTO>>(cities);
            return citiesDTO;
        }

        public void Create(CitiesDTO item)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CitiesDTO, Cities>());

            var city = Mapper.Map<CitiesDTO, Cities>(item);
            db.Cities.Create(city);


        }

        public void Update(CitiesDTO item)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Cities, CitiesDTO>());
            var city = Mapper.Map<CitiesDTO, Cities>(item);
            db.Cities.Update(city);

        }

        public void Delete(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Cities, CitiesDTO>());
            db.Cities.Delete(id);

        }
    }
}
