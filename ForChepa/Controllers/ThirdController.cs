using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ForChepa.Models;
using PagedList.Mvc;
using PagedList;

namespace ForChepa.Controllers
{
    public class ThirdController : Controller
    {
        TopographyContext tc = new TopographyContext();

        // GET: Third
        public ActionResult Index(int?page,string currentFilter,string filter)
        {
            if (filter!=null)
            {
                page = 1;
            }
            else
            {
                filter = currentFilter;
            }
            ViewBag.CurrentFilter = filter;
            var th = tc.Third.Include(city => city.Cities).Include(country => country.Countries);
            if (!String.IsNullOrEmpty(filter))
            {
                th = th.Where(f => f.Cities.Name.Contains(filter) || f.Countries.Name.Contains(filter));
            }
            int PageSize = 10;
            int PageNumber = (page ?? 1);
            return View(th.OrderBy(t=>t.Id).ToPagedList(PageNumber,PageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            SelectList cities = new SelectList(tc.Cities, "Id", "Name");
            SelectList countries = new SelectList(tc.Countries, "Id", "Name");
            ViewBag.Cities = cities;
            ViewBag.Countries = countries;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Third th)
        {
            tc.Third.Add(th);        
            tc.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var th = tc.Third.Include(city => city.Cities).Include(country => country.Countries).FirstOrDefault(p => p.Id == id);
            if (th != null)
            {
                SelectList cities = new SelectList(tc.Cities, "Id", "Name");
                ViewBag.Cities = cities;
                SelectList countries = new SelectList(tc.Countries, "Id", "Name");
                ViewBag.Countries = countries;
                return View(th);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Third th)
        {
            tc.Entry(th).State = EntityState.Modified;
            tc.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Third th = tc.Third.Include(city => city.Cities).Include(country => country.Countries).FirstOrDefault(p => p.Id == id);
            if (th == null)
            {
                return HttpNotFound();
            }
            SelectList countries = new SelectList(tc.Countries, "Id", "Name");
            ViewBag.Countries = countries;
            SelectList cities = new SelectList(tc.Cities, "Id", "Name");
            ViewBag.Cities = cities;
            return View(th);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Third th = tc.Third.Find(id);
            if (th == null)
            {
                return HttpNotFound();
            }
            tc.Third.Remove(th);
            tc.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Third th = tc.Third.Include(city => city.Cities).Include(country => country.Countries).FirstOrDefault(idd => idd.Id == id);
            
            if (th == null)
            {
                return HttpNotFound();
            }
          
            return View(th);
        }
    }
}