using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ForChepa.Models;
using ForChepaBLL.DTO;
using ForChepaBLL.Interfaces;
using ForChepaBLL.Infrastructure;
using AutoMapper;
namespace ForChepa.Controllers
{
    public class HomeController : Controller
    {
        //TopographyContext tc = new TopographyContext();
        ITopographyService topo;
        public HomeController(ITopographyService service)
        {
            topo = service;
        }
        public ActionResult Index()
        {
            IEnumerable<CitiesDTO> c = topo.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<CitiesDTO, CityViewModel>());
            var cities = Mapper.Map<IEnumerable<CitiesDTO>, List<CityViewModel>>(c);
            return View(cities);
           // IEnumerable<Cities> c = tc.Cities;
            //return View(c.ToList());
        }
        [HttpGet]
        public ActionResult Edit(int ?id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CitiesDTO, CityViewModel>());
            if (id==null)
            {
                return HttpNotFound();
            }

            //CitiesDTO cDTO = topo.Find(city => city.Id == id).First();

           var c= topo.Find(city=>city.Id==id);
            
            if (c!=null)
            {
                var cView = Mapper.Map<IEnumerable<CitiesDTO>, CityViewModel>(c);
                return View(cView);
            }
            return HttpNotFound();

        }
        [HttpPost]
        public ActionResult Edit(CityViewModel c)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CityViewModel,CitiesDTO>());
            var cDTO = Mapper.Map<CityViewModel, CitiesDTO>(c);
            topo.Update(cDTO);
           // tc.Entry(c).State = EntityState.Modified;
           // tc.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CityViewModel c)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CityViewModel,CitiesDTO >());
            var city = Mapper.Map<CityViewModel,CitiesDTO>(c);

            topo.Create(city);
         
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            //Cities c = tc.Cities.Find(id);
            //if (c == null)
            //{
            //    return HttpNotFound();
            //}
           return View();
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            //Cities c = tc.Cities.Find(id);
            
          ////  if (c == null)
           // {
            //    return HttpNotFound();
           // }
         //   tc.Cities.Remove(c);
           // tc.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }
            //Cities ck = tc.Cities.Find(id);

            //if (ck == null)
            //{
            //    return HttpNotFound();
            //}
            return View();

        }
    }
}